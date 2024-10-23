﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="ELibraryManagement.userprofile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<script type="text/javascript">
    $(document).ready(function () {
        $('.table').prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
    });
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
    <div class="row">
        <div class="col-md-5">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col">
                            <center>
                                <img src="images/generaluser.png" width="100"/>
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <center>
                                <h3>Your Profile</h3>
                               <span>Account status - </span>
                                <asp:Label ID="Label1" runat="server" Text="Your Status" CssClass="badge text-bg-success"></asp:Label>
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <center>
                            <div class="col">

                            </div>
                        </center>
                    </div>

                    <div class="row">
                        <div class="col">
                            <center>
                                <hr/>
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <label>Full name</label>
                            <div class="form-group">
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Full name"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <label>Date of Birth</label>
                            <div class="form-group">
                                <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <label>Contact Number</label>
                            <div class="form-group">
                                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" TextMode="Phone" placeholder="(___) --- ----"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <label>Email Address</label>
                            <div class="form-group">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="Email"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <br /> 

                    <div class="row">
                        <div class="col-md-4">
                            <label>State</label>
                            <div class="form-group">
                                <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Select" Value="Select" />
                                    <asp:ListItem Text="Nebraska" Value="Nebraska"/>
                                    <asp:ListItem Text="California" Value="California"/>
                                    <asp:ListItem Text="Florida" Value="Florida"/>
                                    <asp:ListItem Text="Texas" Value="Texas"/>
                                    <asp:ListItem Text="Colorado" Value="Colorado"/>
                                    <asp:ListItem Text="Utah" Value="Utah"/>
                                    <asp:ListItem Text="Kansas" Value="Kansas"/>
                                    <asp:ListItem Text="New York" Value="New York"/>
                                    <asp:ListItem Text="North Carolina" Value="North Carolina"/>
                                    <asp:ListItem Text="Arizona" Value="Arizona"/>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>City</label>
                            <div class="form-group">
                                <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" placeholder="City" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>Zip Code</label>
                            <div class="form-group">
                                <asp:TextBox ID="txtZIP" runat="server" CssClass="form-control" placeholder="Zip Code" TextMode="Number"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <label>Home Address</label>
                            <div class="form-group">
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <br />

                    <div class="row">
                        <div class="col">
                            <center> 
                                <span class="badge text-bg-info">Login Credentials</span>
                            </center>
                        </div>
                    </div>

                    <br />

                     <div class="row">
                        <div class="col-md-4">
                            <label>Username</label>
                            <div class="form-group">
                                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Username" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-4">
                            <label>Password</label>
                            <div class="form-group">
                                <asp:TextBox ID="txtOldPass" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>

                         <div class="col-md-4">
                            <label> New Password</label>
                            <div class="form-group">
                                <asp:TextBox ID="txtNewPass" runat="server" CssClass="form-control" TextMode="Password" placeholder="New Password"></asp:TextBox>
                            </div>
                        </div>

                    </div>

                    <div class="row">
                        <div class="col">
                            <center>
                            <br />
                            <div class="form-group">
                                <a href="usersignup.aspx">
                                    <asp:Button ID="btnUpdate" CssClass="btn btn-primary btn-lg" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                                </a>
                            </div>
                            </center>
                        </div>
                    </div>

                </div>
            </div>
            <a href="homepage.aspx">Back to Home</a> 
            <br />
            <br />
        </div>
        <div class="col-md-7">

            <div class="card">
    <div class="card-body">
        <div class="row">
            <div class="col">
                <center>
                    <img src="images/books1.png" width="100"/>
                </center>
            </div>
        </div>

        <div class="row">
            <div class="col">
                <center>
                    <h3>Your Issued Books</h3>
                   <span class="badge text-bg-info">Info about book due date </span>
                </center>
            </div>
        </div>

        <div class="row">
            <center>
                <div class="col">

                </div>
            </center>
        </div>

        <div class="row">
            <div class="col">
                <center>
                    <hr/>
                </center>
            </div>
        </div>

        <div class="row">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
            <div class="col">
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered" OnRowDataBound="GridView1_RowDataBound"></asp:GridView>
            </div>
        </div>

    </div>
</div>

        </div>
    </div>
</div>


</asp:Content>
