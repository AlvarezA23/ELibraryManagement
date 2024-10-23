<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminpublishermanagement.aspx.cs" Inherits="ELibraryManagement.adminpublishermanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $('.table').prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container">
    <div class="row">
        <div class="col-md-5">
            <div class="card">
                <div class="card-body">

                    <div class="row">
                        <div class="col">
                            <center>
                                <h3>Publisher Details</h3>
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <center>
                                <img src="images/publisher.png" width="100"/>
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
                        <div class="col-md-4">
                            <label>Publisher ID</label>
                            <div class="form-group">
                                <div class="input-group">
                                    <asp:TextBox ID="txtID" runat="server" CssClass="form-control" placeholder="ID"></asp:TextBox>
                                    <asp:Button ID="btnGo" runat="server" Text="Go" CssClass="btn btn-primary btn-sm" OnClick="btnGo_Click" />
                                </div>
                            </div>
                    </div>

                    <div class="col-md-8">
                            <label>Publisher Name</label>
                            <div class="form-group">
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Publisher Name"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <br />

                    <center>
                        <div class="row">
                            <div class="col-md-4">
                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-success btn-lg" OnClick="btnAdd_Click" />
                            </div>

                            <div class="col-md-4">
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary btn-lg" OnClick="btnUpdate_Click" />
                            </div>

                            <div class="col-md-4">
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger btn-lg" OnClick="btnDelete_Click" />
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
                                <h3>Publisher List</h3>
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
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [publisher_master_tbl]"></asp:SqlDataSource>
                        <div class="col">
                            <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" DataKeyNames="publisher_id" DataSourceID="SqlDataSource1">
                                <Columns>
                                    <asp:BoundField DataField="publisher_id" HeaderText="publisher_id" ReadOnly="True" SortExpression="publisher_id" />
                                    <asp:BoundField DataField="publisher_name" HeaderText="publisher_name" SortExpression="publisher_name" />
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
