<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="viewbooks.aspx.cs" Inherits="ELibraryManagement.viewbooks" %>
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
        <div class="col">

             <div class="card">
    <div class="card-body">
       <div class="row">
          <div class="col">
             <center>
                <h4>Book Inventory List</h4>
             </center>
          </div>
       </div>
       <div class="row">
          <div class="col">
             <hr>
          </div>
       </div>
       <div class="row">
           <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [book_master_tbl]"></asp:SqlDataSource>
          <div class="col">
             <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1">
                 <Columns>
                     <asp:BoundField DataField="book_id" HeaderText="ID" ReadOnly="True" SortExpression="book_id" />
                    
                     <asp:TemplateField>
                         <ItemTemplate>
                             <div class="container-fluid">
                                 <div class="row">
                                     <div class="col-lg-10">
                                         <div class="row">
                                             <div class="col">
                                                 <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="True" Font-Size="Large"></asp:Label>
                                             </div>
                                         </div>
                                           <div class="row">
                                             <div class="col">

                                                 Author -
                                                 <asp:Label ID="lblAuthor" runat="server" Font-Bold="True" Text='<%# Eval("author_name") %>'></asp:Label>
                                                 &nbsp;| Genre -
                                                 <asp:Label ID="lblGenre" runat="server" Font-Bold="True" Text='<%# Eval("genre") %>'></asp:Label>
                                                 &nbsp;| Language -
                                                 <asp:Label ID="lblLanguage" runat="server" Font-Bold="True" Text='<%# Eval("language") %>'></asp:Label>

                                             </div>
                                         </div>
                                         <div class="row">
                                             <div class="col">

                                                 Publisher -
                                                 <asp:Label ID="lblPublisher" runat="server" Font-Bold="True" Text='<%# Eval("publisher_name") %>'></asp:Label>
                                                 &nbsp;| Publish Date -
                                                 <asp:Label ID="lblPubDate" runat="server" Font-Bold="True" Text='<%# Eval("publish_date") %>'></asp:Label>
                                                 &nbsp;| Pages -
                                                 <asp:Label ID="lblPages" runat="server" Font-Bold="True" Text='<%# Eval("no_of_pages") %>'></asp:Label>
                                                 &nbsp;| Edition -
                                                 <asp:Label ID="lblEdition" runat="server" Font-Bold="True" Text='<%# Eval("edition") %>'></asp:Label>

                                             </div>
                                         </div>
                                         <div class="row">
                                             <div class="col">

                                                 Cost -
                                                 <asp:Label ID="lblCost" runat="server" Font-Bold="True" Text='<%# Eval("book_cost") %>'></asp:Label>
                                                 &nbsp;| Actual Stock -
                                                 <asp:Label ID="lblActualStock" runat="server" Font-Bold="True" Text='<%# Eval("actual_stock") %>'></asp:Label>
                                                 &nbsp;| Available -
                                                 <asp:Label ID="lblCurrentStock" runat="server" Font-Bold="True" Text='<%# Eval("current_stock") %>'></asp:Label>

                                             </div>
                                         </div>
                                         <div class="row">
                                             <div class="col">

                                                 Description -
                                                 <asp:Label ID="lblDescription" runat="server" Font-Bold="True" Text='<%# Eval("book_description") %>'></asp:Label>

                                             </div>
                                         </div>
                                     </div>
                                     <div class="col-lg-2">
                                         <asp:Image class="img-fluid p-2" ID="imgBook" runat="server" ImageUrl='<%# Eval("book_img_link") %>' />
                                     </div>
                                 </div>
                             </div>
                         </ItemTemplate>
                     </asp:TemplateField>
                    
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
