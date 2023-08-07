<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="GTech_MachineTest.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MemberForm</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="card bg-light col-md-3 mt-5 p-4 mx-auto">
            <h3 class="my-3 text-center text-primary bg-light">Member Form</h3>
            <br />
            <asp:Label ID="SuccessMsg"  runat="server" Text=""></asp:Label>
            <asp:Label ID="ErrorMsg"  runat="server" Text=""></asp:Label>

             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                    ControlToValidate="txtPhNum" ErrorMessage="Please add valid mobile no."
                    ValidationExpression="[0-9]{10}">
             </asp:RegularExpressionValidator>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPhNum" CssClass="fontcolor" ErrorMessage="Please enter Mobile No"></asp:RequiredFieldValidator>

            <asp:Label ID="Name" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="txtName" CssClass="form-control" placeholder="Enter Your Name" runat="server"></asp:TextBox>

            <asp:Label ID="phoneNumber" runat="server" Text="Phone Number"></asp:Label>
            <asp:TextBox ID="txtPhNum"  CssClass="form-control" placeholder="Enter Your Number" runat="server"></asp:TextBox>
            <asp:Label ID="gender" runat="server" Text="Gender"></asp:Label>
            <asp:DropDownList ID="ddlGender"  CssClass="form-control" runat="server">
                <asp:ListItem Enabled="true" Text= "Select Gender" Value= "-1"></asp:ListItem>
                <asp:ListItem Text= "Male" Value="1"></asp:ListItem> 
                <asp:ListItem Text= "Female" Value="2"></asp:ListItem>
            </asp:DropDownList>

            <asp:Label ID="Address" runat="server" Text="Address"></asp:Label>
            <asp:TextBox ID="txtAddress"  CssClass="form-control" placeholder="Enter Your Address" runat="server"></asp:TextBox>

            <asp:Label ID="uploadImage"   runat="server" Text="Upload Image">
            </asp:Label><asp:FileUpload ID="FileUpload1" CssClass="form-control" runat="server" />

            <asp:Button ID="submit" CssClass="btn btn-outline-success btn-lg mt-3" runat="server" Text="Submit" OnClick="submit_Click" />
        </div>
        <asp:GridView ID="GV" runat="server" AutoGenerateColumns="false" CellPadding="4" DataKeyNames="ID" 
            OnRowDeleting="GV_RowDeleting1">
        <Columns>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("NAME") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtGvName" runat="server" Text='<%#Eval("NAME") %>'> </asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Phone Number">
                        <ItemTemplate>
                            <asp:Label ID="lblNo" runat="server" Text='<%#Eval("PHONE_NUMBER") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtGvPhnNo" runat="server" Text='<%#Eval("PHONE_NUMBER") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Gender">
                        <ItemTemplate>
                            <asp:Label ID="lblGender" runat="server" Text='<%#Eval("GENDER") %>'></asp:Label>

                        </ItemTemplate>
                        <EditItemTemplate>
                            <%-- <asp:DropDownList ID="DropDown" runat="server"></asp:DropDownList>--%>
                            <asp:TextBox ID="txtGender" runat="server" Text='<%#Eval("GENDER") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Address">
                        <ItemTemplate>
                            <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("ADDRESS") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtGvAddress" runat="server" Text='<%#Eval("ADDRESS") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Photo">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Width="90" Height="90" ImageUrl='<%#Eval("IMAGE_PATH") %>'></asp:Image>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" HeaderText="Actions" />
        </Columns>
     </asp:GridView>
        
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
