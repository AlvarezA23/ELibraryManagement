<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminauthormanagement.aspx.cs" Inherits="ELibraryManagement.adminauthormanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        $(document).ready(function () {
            $("#<%=GridView1.ClientID%>").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
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
                                <h3>Author Details</h3>
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <center>
                                <img src="images/writer.png" width="100"/>
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
                            <label>Author ID</label>
                            <div class="form-group">
                                <div class="input-group">
                                    <asp:TextBox ID="txtID" runat="server" CssClass="form-control" placeholder="ID"></asp:TextBox>
                                    <asp:Button ID="btnGo" runat="server" Text="Go" CssClass="btn btn-primary btn-sm" OnClick="btnGo_Click" />
                                </div>
                            </div>
                    </div>

                    <div class="col-md-8">
                            <label>Author Name</label>
                            <div class="form-group">
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Author Name"></asp:TextBox>
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
                                <h3>Author List</h3>
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
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" ProviderName="<%$ ConnectionStrings:elibraryDBConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [author_master_tbl]"></asp:SqlDataSource>
                        <div class="col">
                            <asp:GridView ID="GridView1" runat="server" class="table table-striped table-bordered" AutoGenerateColumns="False" DataKeyNames="author_id" DataSourceID="SqlDataSource1">
                                <Columns>
                                    <asp:BoundField DataField="author_id" HeaderText="author_id" ReadOnly="True" SortExpression="author_id" />
                                    <asp:BoundField DataField="author_name" HeaderText="author_name" SortExpression="author_name" />
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
