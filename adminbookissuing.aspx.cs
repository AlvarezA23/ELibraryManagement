using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ELibraryManagement
{
    public partial class adminbookissuing : System.Web.UI.Page
    {
        String strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void btnIssue_Click(object sender, EventArgs e)
        {
            if (checkIfBookExists() && checkIfUserExists())
            { 
                if(checkIfIssueExists())
                {
                    Response.Write("<script>alert('This user already has this book');</script>");
                }
                else
                {
                    issueBook();
                }
                
            }
            else
            {
                    Response.Write("<script>alert('Invalid User or Book ID');</script>");
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            if (checkIfBookExists() && checkIfUserExists())
            {
                if (checkIfIssueExists())
                {
                    returnBook();
                }
                else
                {
                    Response.Write("<script>alert('Book not issued, cannot return');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid User or Book ID');</script>");
            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            getNames();
        }


        void getNames()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT book_name from book_master_tbl WHERE book_id = '"+ txtBookID.Text.Trim() +"'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if(dt.Rows.Count > 0)
                {
                    txtTitle.Text = dt.Rows[0]["book_name"].ToString();
                }
                else
                {
                    Response.Write("<scritp>alert('Wrong Book ID');</script>");
                }

                cmd = new SqlCommand("SELECT full_name FROM member_master_tbl WHERE member_id = '"+ txtUserID.Text.Trim() +"'", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                if( dt.Rows.Count > 0 )
                {
                    txtMemberName.Text = dt.Rows[0]["full_name"].ToString();
                }
                else
                {
                    Response.Write("<scritp>alert('Wrong User ID');</script>");
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ ex.Message +"');</script>");
            }
        }

        bool checkIfBookExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id = '"+ txtBookID.Text.Trim() +"' " +
                                                        "AND current_stock > 0 ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0) 
                {
                return true;
                }
                else 
                {
                    Response.Write("<script>alert('Invalid Book ID');</script>");
                    return false; 
                }
            }
            catch(Exception ex)
            {
                Response.Write("<scritp>alert('"+ ex.Message +"');</script>");
                return false;

            }
        }

        bool checkIfUserExists()
        {
            try 
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                { con.Open(); }
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id = '"+ txtUserID.Text.Trim() +"'", con);
                SqlDataAdapter da = new SqlDataAdapter( cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if(dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    Response.Write("<scritp>alert('Invalid User ID');</script>");
                    return false;

                }
            }
            catch(Exception ex)
            {
                Response.Write("<scritp>alert('"+ ex.Message +"');</script>");
                return false;
            }
        }

        void issueBook()
        {
            try 
            {
                SqlConnection con = new SqlConnection(strcon);
                if( con.State == ConnectionState.Closed )
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO book_issue_tbl(member_id, member_name, book_id, book_name, issue_date, due_date)" +
                    "VALUES(@member_id, @member_name, @book_id, @book_name, @issue_date, @due_date)", con);
                cmd.Parameters.AddWithValue("@member_id",txtUserID.Text.Trim());
                cmd.Parameters.AddWithValue("@member_name",txtMemberName.Text.Trim());
                cmd.Parameters.AddWithValue("@book_id",txtBookID.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name",txtTitle.Text.Trim());
                cmd.Parameters.AddWithValue("@issue_date",txtIssueDate.Text.Trim());
                cmd.Parameters.AddWithValue("@due_date",txtDueDate.Text.Trim());
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("UPDATE book_master_tbl SET current_stock = current_stock - 1 WHERE book_id = '"+ txtBookID.Text.Trim() +"'", con);
                cmd.ExecuteNonQuery();
                con.Close();


                Response.Write("<script>alert('Successfully Issued Book');</script>");
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<scritp>alert('"+ ex.Message +"');</script>");
            }
        }

        bool checkIfIssueExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed )
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_issue_tbl WHERE member_id = '"+ txtUserID.Text.Trim() +"'" +
                                                        "AND book_id = '"+ txtBookID.Text.Trim() +"'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    Response.Write("<scritp>alert('Invalid');</script>");
                    return false;
                }
            }

            catch (Exception ex)
            {
                Response.Write("<scritp>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        void returnBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM book_issue_tbl WHERE book_id = '" + txtBookID.Text.Trim() + "'" +
                                                        "AND member_id='" + txtUserID.Text.Trim() + "' ", con);
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    cmd = new SqlCommand("UPDATE book_master_tbl SET current_stock = current_stock + 1 WHERE book_id='" + txtBookID.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Book returned successfully');</script>");
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<scritp>alert('" + ex.Message + "');</script>");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}