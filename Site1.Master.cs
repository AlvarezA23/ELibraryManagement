using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELibraryManagement
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"].Equals(""))
                {
                    LinkButton1.Visible = true; //Login
                    LinkButton2.Visible = true; //Sign up

                    LinkButton3.Visible = false; //logout
                    LinkButton7.Visible = false; //hello user link

                    LinkButton6.Visible = true; //admin login

                    LinkButton11.Visible = false; //author mgmt
                    LinkButton12.Visible = false; //publisher mgmt
                    LinkButton8.Visible = false; //book inventory
                    LinkButton9.Visible = false; //book issuing
                    LinkButton10.Visible = false; //user mgmt
                }
                else if (Session["role"].Equals("user"))
                {
                    LinkButton1.Visible = false; //Login
                    LinkButton2.Visible = false; //Sign up

                    LinkButton3.Visible = true; //logout
                    LinkButton7.Visible = true; //hello user link
                    LinkButton7.Text = "Hello " + Session["username"].ToString();

                    LinkButton6.Visible = true; //admin login

                    LinkButton11.Visible = false; //author mgmt
                    LinkButton12.Visible = false; //publisher mgmt
                    LinkButton8.Visible = false; //book inventory
                    LinkButton9.Visible = false; //book issuing
                    LinkButton10.Visible = false; //user mgmt
                }
                else if (Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = false; //Login
                    LinkButton2.Visible = false; //Sign up

                    LinkButton3.Visible = true; //logout
                    LinkButton7.Visible = true; //hello user link
                    LinkButton7.Text = "Hello " + Session["username"].ToString();

                    LinkButton6.Visible = false; //admin login

                    LinkButton11.Visible = true; //author mgmt
                    LinkButton12.Visible = true; //publisher mgmt
                    LinkButton8.Visible = true; //book inventory
                    LinkButton9.Visible = true; //book issuing
                    LinkButton10.Visible = true; //user mgmt
                }
            }
            catch(Exception ex)
            {

            }
            
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminauthormanagement.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminpublishermanagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookinventory.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookissuing.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminusermanagement.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            //view books link
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");

        }

        protected void LinkButton4_Click1(object sender, EventArgs e)
        {
            Response.Redirect("viewbooks.aspx");

        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";
            Session["status"] = "";
            LinkButton1.Visible = true; //Login
            LinkButton2.Visible = true; //Sign up

            LinkButton3.Visible = false; //logout
            LinkButton7.Visible = false; //hello user link

            LinkButton6.Visible = true; //admin login

            LinkButton11.Visible = false; //author mgmt
            LinkButton12.Visible = false; //publisher mgmt
            LinkButton8.Visible = false; //book inventory
            LinkButton9.Visible = false; //book issuing
            LinkButton10.Visible = false; //user mgmt

            Response.Redirect("homepage.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("userprofile.aspx");
        }
    }
}