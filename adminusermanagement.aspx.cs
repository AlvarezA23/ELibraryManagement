using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELibraryManagement
{
    public partial class adminusermanagement : System.Web.UI.Page
    {
        String strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void btnMemID_Click(object sender, EventArgs e)
        {
            if (checkIDExists())
            {
                getMemByID();
            }
            else
            {
                Response.Write("<script>alert('ID Does Not Exist. Please try a different ID');</script>");
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            if (checkIDExists())
            {
                updateStatusByID("approved");
            }
            else 
            {
                Response.Write("<script>alert('Invalid ID, Please try a different ID');</script>");
            }
        }


        protected void btnPending_Click(object sender, EventArgs e) 
        {
            if (checkIDExists())
            {
                updateStatusByID("pending");
            }
            else
            {
                Response.Write("<script>alert('Invalid ID, Please try a different ID');</script>");
            }
        }

        protected void btnDeny_Click(object sender, EventArgs e) 
        {
            if (checkIDExists())
            {
                updateStatusByID("denied");
            }
            else
            {
                Response.Write("<script>alert('Invalid ID, Please try a different ID');</script>");
            }
        }

        protected void btnDeleteUser_Click(object sender, EventArgs e) 
        {
            if (checkIDExists())
            {
                deleteUser();
            }
            else
            {
                Response.Write("<script>alert('Invalid ID, Please try a different ID');</script>");
            }
        
        }


        bool checkIDExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id='"+txtMemberID.Text.Trim()+"'", con);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);

                if(dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ ex.Message +"');</script>");
                return false;
            }
        }

        void getMemByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id = '"+ txtMemberID.Text.Trim() +"'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                     while (dr.Read())
                        {
                        txtFullName.Text = dr.GetValue(0).ToString();
                        txtAccountStatus.Text = dr.GetValue(10).ToString().ToUpper();
                        txtDOB.Text = dr.GetValue(1).ToString();
                        txtPhone.Text = dr.GetValue(2).ToString();
                        txtEmail.Text = dr.GetValue(3).ToString();
                        txtState.Text = dr.GetValue(4).ToString();
                        txtCity.Text = dr.GetValue(5).ToString();
                        txtZIP.Text = dr.GetValue(6).ToString();
                        txtAddress.Text = dr.GetValue(7).ToString();
                        } 
                }

            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ ex.Message +"');</script>");
            }
        }

        void updateStatusByID(string status)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET account_status = '"+ status +"' WHERE member_id = '"+ txtMemberID.Text.Trim() +"'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Account Status Successfully updated');</script>");
                GridView1.DataBind();
                txtAccountStatus.Text = status.ToUpper();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ ex.Message +"');</script>");
            }
        }

        void deleteUser()
        {
            try 
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM member_master_tbl WHERE member_id = '"+ txtMemberID.Text.Trim() +"'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('User deleted Successfully');</script>");
                GridView1.DataBind();
                clearForm();
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ ex.Message +"');</script>");
            }
        }

        void clearForm()
        {
            txtFullName.Text = string.Empty;
            txtAccountStatus.Text= string.Empty;
            txtMemberID.Text = string.Empty;
            txtDOB.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtState.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtZIP.Text = string.Empty;
            txtAddress.Text = string.Empty;
        }
    }
}