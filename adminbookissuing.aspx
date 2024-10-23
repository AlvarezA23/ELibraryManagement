<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminbookissuing.aspx.cs" Inherits="ELibraryManagement.adminbookissuing" %>
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
                                <h3>Book Issuing</h3>
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <center>
                                <img src="images/books.png" width="100"/>
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
                        <div class="col-md-6">
                                <label>Member ID</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtUserID" runat="server" CssClass="form-control" placeholder="MemberID"></asp:TextBox>
                                </div>
                        </div>
                        <div class="col-md-6">
                                <label>Book ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBookID" runat="server" CssClass="form-control" placeholder="ID"></asp:TextBox>
                                        <asp:Button ID="btnGo" runat="server" Text="Go" CssClass="btn btn-primary btn-sm" OnClick="btnGo_Click" />
                                    </div>
                                </div>
                        </div>
                    </div>

                    <br />

                    <div class="row">
                        <div class="col-md-6">
                            <label>Member Name</label>
                            <div class="form-group">
                                <asp:TextBox ID="txtMemberName" CssClass="form-control" placeholder="Name" runat="server" ReadOnly="True"></asp:TextBox>
                            </div>                        
                        </div>
                        <div class="col-md-6">
                            <label>Book Name</label>
                            <div class="form-group">
                                <asp:TextBox ID="txtTitle" CssClass="form-control" placeholder="Book Name" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <br />

                    <div class="row">
                        <div class="col-md-6">
                            <label>Start Date</label>
                            <div class="form-group">
                                <asp:TextBox ID="txtIssueDate" runat="server" CssClass="form-control" placeholder="dd-mm-yyyy" TextMode="Date" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label>End Date</label>
                            <div class="form-group">
                                <asp:TextBox ID="txtDueDate" runat="server" CssClass="form-control" placeholder="dd-mm-yyyy" TextMode="Date" ></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <br />

                    <center>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Button ID="btnIssue" runat="server" Text="Issue" CssClass="btn btn-success btn-lg" OnClick="btnIssue_Click" />
                            </div>

                            <div class="col-md-6">
                                <asp:Button ID="btnReturn" runat="server" Text="Return" CssClass="btn btn-primary btn-lg" OnClick="btnReturn_Click" />
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
                                <h3>Issued Book(s) List</h3>
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
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [book_issue_tbl]"></asp:SqlDataSource>
                        <div class="col">
                            <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="member_id" HeaderText="Member ID" SortExpression="member_id" />
                                    <asp:BoundField DataField="member_name" HeaderText="Member Name" SortExpression="member_name" />
                                    <asp:BoundField DataField="book_id" HeaderText="Book ID" SortExpression="book_id" />
                                    <asp:BoundField DataField="book_name" HeaderText="Book Title" SortExpression="book_name" />
                                    <asp:BoundField DataField="issue_date" HeaderText="Issue Date" SortExpression="issue_date" />
                                    <asp:BoundField DataField="due_date" HeaderText="Due Date" SortExpression="due_date" />
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
