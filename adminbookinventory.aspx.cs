using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Common;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace ELibraryManagement
{
    public partial class adminbookinventory : System.Web.UI.Page
    {
        String strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_filepath;
        static int global_actual_stock, global_current_stock, global_issued_books;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            fillAuthorPublisherValues();
            }
            GridView1.DataBind();
        }

        protected void btnBookID_Click(object sender, EventArgs e)
        {
            if (checkBookExists())
            {
                getBookByID();
            }
            else
            {
                Response.Write("<script>alert('Invalid ID, please try a different ID and try again.');</script>");
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkBookExists())
            {
                Response.Write("<script>alert('ID already exists, please try a different ID and try again.');</script>");
            }
            else
            {
                addBook();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (checkBookExists())
            {
                updateBook();
            }
            else
            {
                Response.Write("<script>alert('Invalid ID, please try a different ID and try again.');</script>");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e) 
        {
            if (checkBookExists())
            {
                deleteBook();
            }
            else
            {
                Response.Write("<script>alert('Invalid ID, please try a different ID and try again.');</script>");
            }
        }

        bool checkBookExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id = '"+ txtBookID.Text.Trim() +"'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if(dt.Rows.Count > 0)
                {
                    return true;
                }
                else 
                {
                    Response.Write("<script>alert('Invalid ID. Please try a different ID and try again.');</script>");
                    return false; 
                }
            }
            catch(Exception ex) 
            {
                Response.Write("<script>alert('"+ ex.Message +"');</script>");
                return false;
            }
            
        }

        void fillAuthorPublisherValues()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT author_name FROM author_master_tbl", con);
                SqlDataAdapter da = new SqlDataAdapter( cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ddlAuthorList.DataSource = dt;
                ddlAuthorList.DataValueField = "author_name";
                ddlAuthorList.DataBind();

                cmd = new SqlCommand("SELECT publisher_name FROM publisher_master_tbl", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                ddlPublisherList.DataSource = dt;
                ddlPublisherList.DataValueField = "publisher_name";
                ddlPublisherList.DataBind();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ ex.Message +"');</script>");
            }
        }

        void addBook()
        {
            try 
            {
                string genres = "";
                foreach (int i in lstGenre.GetSelectedIndices())
                {
                    genres = genres + lstGenre.Items[i] + ",";
                }
                genres = genres.Remove(genres.Length - 1);

                string filepath = "~/book_inventory/b1.jpg";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                filepath = "~book_inventory/" + filename;

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                { con.Open(); }
                SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tbl(book_id,book_name,genre,author_name,publisher_name,publish_date,language,edition,book_cost,no_of_pages,book_description,actual_stock,current_stock,book_img_link)" +
                    "VALUES(@book_id,@book_name,@genre,@author_name,@publisher_name,@publish_date,@language,@edition,@book_cost,@no_of_pages,@book_description,@actual_stock,@current_stock,@book_img_link)", con);

                cmd.Parameters.AddWithValue("@book_id", txtBookID.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", txtBookName.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);
                cmd.Parameters.AddWithValue("@author_name", ddlAuthorList.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", ddlPublisherList.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", txtPubDate.Text.Trim());
                cmd.Parameters.AddWithValue("@language", ddlLanguage.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", txtEdition.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", txtCost.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", txtPages.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", txtDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", txtActualStock.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", txtActualStock.Text.Trim());
                cmd.Parameters.AddWithValue("@book_img_link", filepath);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book Added Successfully');</script>");
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ ex.Message +"');</script>");
            }
        }

        void updateBook()
        {
            try
            {
                int actual_stock = Convert.ToInt32(txtActualStock.Text.Trim());
                int current_stock = Convert.ToInt32(txtCurrentStock.Text.Trim());

                if (global_actual_stock == actual_stock)
                {

                }
                else
                {
                    if (actual_stock < global_issued_books)
                    {
                        Response.Write("<script>alert('Actual Stock value cannot be less than the Issued books');</script>");
                        return;


                    }
                    else
                    {
                        current_stock = actual_stock - global_issued_books;
                        txtCurrentStock.Text = "" + current_stock;
                    }
                }

                string genres = "";
                foreach(int i in lstGenre.GetSelectedIndices())
                {
                    genres = genres + lstGenre.Items[i] + ",";
                }
                genres = genres.Remove(genres.Length - 1);

                string filepath = "~/book_inventory/b1";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                if (filename == "" || filename == null)
                {
                    filepath = global_filepath;
                }
                else
                {
                    FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                    filepath = "~/book_inventory/" + filename;
                }

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE book_master_tbl SET book_name=@book_name, genre=@genre, author_name=@author_name, publisher_name=@publisher_name, publish_date=@publish_date, language=@language, edition=@edition, book_cost=@book_cost, no_of_pages=@no_of_pages, book_description=@book_description, actual_stock=@actual_stock, current_stock=@current_stock, book_img_link=@book_img_link where book_id='"+ txtBookID.Text.Trim() +"'", con);
                cmd.Parameters.AddWithValue("@book_name", txtBookName.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);
                cmd.Parameters.AddWithValue("@author_name", ddlAuthorList.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", ddlPublisherList.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", txtPubDate.Text.Trim());
                cmd.Parameters.AddWithValue("@language", ddlLanguage.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", txtEdition.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", txtCost.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", txtPages.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", txtDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", actual_stock.ToString());
                cmd.Parameters.AddWithValue("@current_stock", current_stock.ToString());
                cmd.Parameters.AddWithValue("@book_img_link", filepath);

                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();
                Response.Write("<script>alert('Book Updated Successfully');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ ex.Message +"');</script>");
            }
        }
        void deleteBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM book_master_tbl WHERE book_id = '"+ txtBookID.Text.Trim() +"'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();
                Response.Write("<script>alert('Book Deleted Successfully');</script>");
            }
            catch(Exception ex) 
            {
                Response.Write("<script>alert('"+ ex.Message +"');</script>");
            }
        }

        void getBookByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id = '"+ txtBookID.Text.Trim() +"'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if(dt.Rows.Count > 0)
                {
                    txtBookName.Text = dt.Rows[0]["book_name"].ToString();
                    ddlLanguage.SelectedValue = dt.Rows[0]["language"].ToString().Trim();
                    ddlAuthorList.SelectedValue = dt.Rows[0]["author_name"].ToString().Trim();
                    ddlPublisherList.SelectedValue = dt.Rows[0]["publisher_name"].ToString().Trim();
                    txtPubDate.Text = dt.Rows[0]["publish_date"].ToString();
                    txtEdition.Text = dt.Rows[0]["edition"].ToString();
                    txtCost.Text = dt.Rows[0]["book_cost"].ToString();
                    txtPages.Text = dt.Rows[0]["no_of_pages"].ToString();
                    txtActualStock.Text = dt.Rows[0]["actual_stock"].ToString();
                    txtCurrentStock.Text = dt.Rows[0]["current_stock"].ToString();
                    //txtIssuedBooks.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString())); 
                    txtDescription.Text = dt.Rows[0]["book_description"].ToString();

                    lstGenre.ClearSelection();
                    string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(',');

                    for (int i = 0; i < genre.Length; i++)
                    {
                        for (int j = 0; j < lstGenre.Items.Count; j++)
                        {
                            if (lstGenre.Items[j].ToString() == genre[i])
                            {
                                lstGenre.Items[j].Selected = true;
                            }
                        }
                    }

                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                    global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                    global_issued_books = global_actual_stock - global_current_stock;
                    global_filepath = dt.Rows[0]["book_img_link"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Book ID');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}