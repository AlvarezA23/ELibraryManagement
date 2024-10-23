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
    public partial class usersignup : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //sign up button 
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkUserExists())
            {
                Response.Write("<script>alert('Username already exists, please choose a different one and try again.')</script>");
            }
            else
            {
                signUpNewUser();
            }
            
        }


        //user defined method

        bool checkUserExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id='"+txtUsername.Text.Trim()+"'", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
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
                Response.Write("<script>alert('" + ex.Message +"'");
                return false;
            }


            
        }

        void signUpNewUser()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO member_master_tbl" +
                                                        "(full_name, dob, contact_no, email, state, city, zipcode, full_address, member_id, password, account_status)" +
                                                        "VALUES(@full_name, @dob, @contact_no, @email, @state, @city, @zipcode, @full_address, @member_id, @password, @account_status)", con);

                cmd.Parameters.AddWithValue("@full_name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", txtDOB.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", txtPhone.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@state", ddlStates.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", txtCity.Text.Trim());
                cmd.Parameters.AddWithValue("@zipcode", txtZip.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@member_id", txtUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@password", txtPass.Text.Trim());
                cmd.Parameters.AddWithValue("@account_status", "pending");

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Sign up successful. Please go to User Login to Login');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ ex.Message +"');</script>");
            }
        }

    }
}