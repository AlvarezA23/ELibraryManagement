<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="ELibraryManagement.adminlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <div class="row">
        <div class="col-md-6 mx-auto">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col">
                            <center>
                                <img src="images/adminuser.png" width="150"/>
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <center>
                                <h3>Admin Login</h3>
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <center>
                                <hr/>
                            </center>
                        </div>
                    </div>


                    <div class="row">
                        <div class="col">
                            <label>Admin ID</label>
                            <div class="form-group">
                                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Admin ID"></asp:TextBox>
                            </div>

                            <label>Password</label>
                            <div class="form-group">
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
                            </div>
                            <br />
                            <center>
                            <div class="form-group">
                                <asp:Button ID="btnAdminLogin" runat="server" Text="Login" CssClass="btn btn-primary btn-lg" OnClick="btnAdminLogin_Click" />
                            </div>
                            <br />
                            </center>
                        </div>
                    </div>

                </div>
            </div>
            <a href="homepage.aspx">Back to Home</a> 
            <br />
            <br />
        </div>
    </div>
</div>


</asp:Content>
