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
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="container">

            <div class="col">
                <asp:TextBox ID="txtIdProduct" runat="server"></asp:TextBox>
            </div>

<div class="col">

    <asp:Label ID="lblProduct" runat="server" Text="Product"></asp:Label>
    <asp:TextBox ID="txtProduct" runat="server"></asp:TextBox>

</div>

 <div class="col">

     <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
    <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>

 </div>

 <div class="col">

     <asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label>
    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>

 </div>

 <div class="col">

     <asp:Label ID="lblAvailable" runat="server" Text="Available"></asp:Label>
    <asp:CheckBox ID="chkAvailable" runat="server" />

 </div>

 <div class="col">

    <asp:Label ID="lblCant" runat="server" Text="Cant"></asp:Label>
    <asp:TextBox ID="txtCant" runat="server"></asp:TextBox>

 </div>

<div>

    <asp:FileUpload ID="fileInputImageCover" runat="server"/>

</div>

<div>

     <div id="imagePreviewCover">

         <h2>Cover Image</h2>
         <asp:Image ID="imgProductCover"  ImageUrl="" runat="server" />

    </div>

</div>

            <div class="col">

                <asp:FileUpload ID="fileInputProductImages" runat="server"  AllowMultiple="true"/>

            </div>

            <div class="col" id="imagePreview">
         
                 <h2>Product Images</h2>
                <asp:Panel ID="containerProductImagen" runat="server"></asp:Panel>

            </div>

     <div>

 <div class="row">
  
  <asp:Button ID="btnSaveProduct" runat="server" Text="Button" OnClick="btnSaveProduct_Click"/>

</div>

 </div>

    </form>

 <script src="Script/ShowImagesSelected.js" defer> </script>

</body>
</html>
