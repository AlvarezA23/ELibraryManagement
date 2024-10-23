<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminusermanagement.aspx.cs" Inherits="ELibraryManagement.adminusermanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
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
                                <h3>User Details</h3>
                            </center>
                        </div>
                    </div>

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
                                <hr/>
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-3">
                                <label>Member ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtMemberID" runat="server" CssClass="form-control" placeholder="ID"></asp:TextBox>
                                        <asp:Button ID="btnMemID" OnClick="btnMemID_Click" runat="server" Text="Go" CssClass="btn btn-primary btn-sm" />
                                    </div>
                                </div>
                        </div>
                        <div class="col-md-3">
                                <label>Full Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" placeholder="User Name" ReadOnly="true"></asp:TextBox>
                                </div>
                        </div>
                        <div class="col-md-6">
                            <label>Account Status</label>
                            <div class="form-group">
                                <div class="input-group">
                                    <asp:TextBox ID="txtAccountStatus" runat="server" CssClass="form-control" placeholder="Status" ReadOnly="true"></asp:TextBox>
                                    <asp:LinkButton onClick="btnApprove_Click" class="btn btn-success mr-1" ID="btnApprove" runat="server"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                    <asp:LinkButton onClick="btnPending_Click" class="btn btn-warning mr-1" ID="btnPending" runat="server"><i class="far fa-pause-circle"></i></asp:LinkButton>
                                    <asp:LinkButton onClick="btnDeny_Click" class="btn btn-danger mr-1" ID="btnDeny" runat="server"><i class="fas fa-times-circle"></i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>

                    <br />

                    <div class="row">
                        <div class="col-md-3">
                            <label>DOB</label>
                            <div class="form-group">
                                <asp:TextBox ID="txtDOB" CssClass="form-control" placeholder="dd-mm-yyy" runat="server" ReadOnly="True" TextMode="Date"></asp:TextBox>
                            </div>                        
                        </div>
                        <div class="col-md-4">
                            <label>Contact No.</label>
                            <div class="form-group">
                                <asp:TextBox ID="txtPhone" CssClass="form-control" placeholder="(___) --- ----" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-5">
                            <label>Email Address</label>
                            <div class="form-group">
                                <asp:TextBox ID="txtEmail" CssClass="form-control" placeholder="Email" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <br />

                    <div class="row">
                        <div class="col-md-4">
                            <label>State</label>
                            <div class="form-group">
                                <asp:TextBox ID="txtState" runat="server" CssClass="form-control" placeholder="State" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>City</label>
                            <div class="form-group">
                                <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" placeholder="City" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>Zip Code</label>
                            <div class="form-group">
                                <asp:TextBox ID="txtZIP" CssClass="form-control" placeholder="12345" runat="server" ReadOnly="true" TextMode="Number"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <br />

                    <div class="row">
                        <div class="col">
                            <label>Full Postal Address</label>
                            <div class="form-group">
                                <asp:TextBox ID="txtAddress" runat="server" placeholder="Address" CssClass="form-control" ReadOnly="true" Rows="2" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <br />

                    <center>
                        <div class="row">
                            <div class="col">
                                <asp:Button ID="btnDeleteUser" runat="server" Text="Delete User Permanently" CssClass="btn btn-danger btn-lg" OnClick="btnDeleteUser_Click" />
                            </div>
                        </div>
                    </center>

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
                                <h3>User(s) List</h3>
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
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT [full_name], [dob], [contact_no], [email], [state], [city], [zipcode], [full_address], [member_id], [account_status] FROM [member_master_tbl]"></asp:SqlDataSource>
                        <div class="col">
                            <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" DataKeyNames="member_id" DataSourceID="SqlDataSource1">
                                <Columns>
                                    <asp:BoundField DataField="member_id" HeaderText="Member ID" ReadOnly="True" SortExpression="member_id" />
                                    <asp:BoundField DataField="full_name" HeaderText="Name" SortExpression="full_name" />
                                    <asp:BoundField DataField="account_status" HeaderText="Account Status" SortExpression="account_status" />
                                    <asp:BoundField DataField="contact_no" HeaderText="Phone" SortExpression="contact_no" />
                                    <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                                    <asp:BoundField DataField="state" HeaderText="State" SortExpression="state" />
                                    <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>

                </div>
            </div>

        </div>
    </div>
</div>

</asp:Content>
