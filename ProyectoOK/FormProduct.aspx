<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormProduct.aspx.cs" Inherits="ProyectoOK.FormProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
       <link href="Content/bootstrap.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
        <div class="container">

<div class="col">

    <asp:TextBox ID="txtProduct" runat="server"></asp:TextBox>

</div>

 <div class="col">

    <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>

 </div>

 <div class="col">

    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>

 </div>

 <div class="col">

    <asp:CheckBox ID="chkAvailable" runat="server" />

 </div>

 <div class="col">

    <asp:TextBox ID="txtCant" runat="server"></asp:TextBox>

 </div>

 <div class="col">

     <asp:FileUpload ID="fileImagen" runat="server" AllowMultiple="true"/>
     <asp:Button  for="fileImagen" runat="server" Text="+" />

 </div>

 <div class="col">

     <asp:Image ID="imgImage" runat="server" />

 </div>

 <div class="row">

   

  <asp:Button ID="btnSaveProduct" runat="server" Text="Button" OnClick="btnSaveProduct_Click"/>



</div>

 </div>

    </form>
</body>
</html>
