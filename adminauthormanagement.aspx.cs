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
    public partial class adminauthormanagement : System.Web.UI.Page
    {
        String strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckIfAuthExists())
            {
                Response.Write("<script>alert('Author ID Already Exists, please enter a Different ID');</script>");
            }
            else
            {
                addNewAuthor();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if(CheckIfAuthExists())
            {
                updateAuthor();
            }
            else
            {
                Response.Write("<script>alert('Author ID does not exist, cannot update');</script>");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (CheckIfAuthExists())
            {
                deleteAuthor();
            }
            else
            {
                Response.Write("<script>alert('Author does not Exist');</script");
            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            if (CheckIfAuthExists())
            {
                getAuthorByID();
            }
            else
            {
                Response.Write("<script>alert('Author does not exist.');</script>");
            }
        }


        //user defined methods

        bool CheckIfAuthExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM author_master_tbl WHERE author_id='"+txtID.Text.Trim()+"'", con);
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
                Response.Write("<script>alert('"+ex.Message+"');</script>");
                return false;
            }
        }

        void addNewAuthor()
        {
            try 
            {
                SqlConnection con = new SqlConnection(strcon);
                if( con.State == ConnectionState.Closed ) 
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tbl(author_id, author_name) VALUES (@author_id, @author_name)", con);
                cmd.Parameters.AddWithValue("@author_id", txtID.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", txtName.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Author Added Successfully.');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
            }
        }

        void updateAuthor()
        {
            try 
            {
                SqlConnection con = new SqlConnection(strcon);
                if( con.State == ConnectionState.Closed )
                { con.Open(); }
                SqlCommand cmd = new SqlCommand("UPDATE author_master_tbl SET author_name=@author_name WHERE author_id='"+ txtID.Text.Trim() +"'", con);

                cmd.Parameters.AddWithValue("@author_name", txtName.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author Updated Successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex) 
            {
                Response.Write("<script>alert('"+ ex.Message +"');</script");
            }
        }

        void deleteAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if( con.State == ConnectionState.Closed )
                { con.Open(); }
                SqlCommand cmd = new SqlCommand("DELETE from author_master_tbl WHERE author_id='"+txtID.Text.Trim()+"'", con);
                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Author Deleted Successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ ex.Message +"');</script>");
            }
        }

        void clearForm()
        {
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
        }

        void getAuthorByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand("SELECT * FROM author_master_tbl WHERE author_id='"+txtID.Text.Trim()+"'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if(dt.Rows.Count > 0 )
                {
                    txtName.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Author ID');</script>");
                }

                
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
            }
        }

    }
}