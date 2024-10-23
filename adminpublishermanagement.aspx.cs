using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELibraryManagement
{
    public partial class adminpublishermanagement : System.Web.UI.Page
    {
        String strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            if (CheckIfPubExists())
            {
                getPubByID();
            }
            else
            {
                Response.Write("<script>alert('Publisher ID does not exist');</script>");
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckIfPubExists())
            {
                Response.Write("<script>alert('Publisher Already Exists, please enter a new ID');</script>");
            }
            else
            {
                AddNewPub();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckIfPubExists())
            {
                UpdatePub();
            }
            else
            {
                Response.Write("<script>alert('Publisher ID does not exist');</script>");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (CheckIfPubExists())
            {
                DeletePub();
            }
            else
            {
                Response.Write("<script>alert('Publisher ID does not exist. Please enter a different ID');</script>");
            }
        }

        //User defined methods

        bool CheckIfPubExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                { con.Open(); }

                SqlCommand cmd = new SqlCommand("SELECT * FROM publisher_master_tbl WHERE publisher_id='"+txtID.Text.Trim()+"'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)  
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
                return false;
            }
        }

        void AddNewPub()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO publisher_master_tbl(publisher_id, publisher_name) VALUES (@publisher_id, @publisher_name)", con);
                cmd.Parameters.AddWithValue("@publisher_id", txtID.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", txtName.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Publisher Added Successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void UpdatePub()
        {
            try 
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                { con.Open(); }
                SqlCommand cmd = new SqlCommand("UPDATE publisher_master_tbl SET publisher_name=@publisher_name WHERE publisher_id='"+txtID.Text.Trim()+"'", con);
                cmd.Parameters.AddWithValue("@publisher_name", txtName.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Publisher Successfully Updated');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void DeletePub()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM publisher_master_tbl WHERE publisher_id='"+txtID.Text.Trim()+"'", con);
                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Deleted Publisher Successfully.');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void clearForm()
        {
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
        }

        void getPubByID()
        {
            try 
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                { con.Open(); }
                SqlCommand cmd = new SqlCommand("SELECT * FROM publisher_master_tbl WHERE publisher_id = '"+txtID.Text.Trim()+"'", con);
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    txtName.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Publisher ID');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}