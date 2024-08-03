<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormProduct.aspx.cs" Inherits="ProyectoOK.FormProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
       <link href="Content/bootstrap.css" rel="stylesheet" />

    <style>
        .backgroundOfTheRest
        {
         background-color: #000;
         opacity: 0.7;
         filter: alpha(opacity=70); /* IE8 y earlier, para que en los navegadores mas antiguos se vea opaco el fondo del resto.*/
        }
    </style>

    <title></title>
</head>
<body>
  
    <form id="form1" runat="server">
    
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
         
                 <h2>Product Image</h2>
                <asp:Panel ID="containerProductImagen" runat="server"></asp:Panel>

            </div>

     <div>

          <asp:ScriptManager ID="ScriptManagerPopupWindow" runat="server"></asp:ScriptManager>
  
 <div class="row">
  
  <asp:Button ID="btnSaveProduct" runat="server" Text="Save" OnClick="btnSaveProduct_Click"/>

</div>

         <div>

         <asp:Button ID="btnDeleteProduct" runat="server" Text="Delete" OnClick="btnDeleteProduct_Click" />

         </div>


         <!-- Contenido PopupWindow sobre la imagen de portada -->
<div class="col">

     <asp:Button ID="btnDeletePorductImageCover" runat="server" Text="Delete Product Image Cover"/>

     <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender2" runat="server"
    TargetControlID="btnDeletePorductImageCover"
    PopupControlID="updatePanelPopupProductImageCover"
    BackgroundCssClass="backgroundOfTheRest"> 
    </ajaxToolkit:ModalPopupExtender>

    <asp:UpdatePanel ID="updatePanelPopupProductImageCover" runat="server">

        <ContentTemplate>

       <asp:Panel ID="panelPopupWindow1" runat="server">  <!--Panel que contendrá el contenido del popup, de la imagenes portada del producto.-->

  <p>Image Cover of the Product</p>

              <asp:Panel ID="panelPopupImageCover" runat="server"></asp:Panel>  <!--En este panel se contendran las imagen portada del producto.-->
      <asp:Button ID="btnClose1" runat="server" Text="Close" OnClick="btnClose1_Click"/> 
  
     </asp:Panel> 

        </ContentTemplate>

    </asp:UpdatePanel>

</div>
         <!-- Fin contenido PopupWindow sobre imagen portada -->

<!--Contenido PopupWindow sobre las imagenes del producto-->
         <div class="col">

         <asp:Button ID="btnDeleteProductImage" runat="server" Text="Delete Product Image"/>

        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
        TargetControlID="btnDeleteProductImage"
        PopupControlID="updatePanelPopupProductImage"
        BackgroundCssClass="backgroundOfTheRest"> 
        </ajaxToolkit:ModalPopupExtender>
   
           <asp:UpdatePanel ID="updatePanelPopupProductImage" UpdateMode="Conditional" runat="server"> 

               <ContentTemplate>

       <asp:Panel ID="panelPopupWindow" runat="server">  <!--Panel que contendrá el contenido del popup, de la imagenes del producto.-->

       <p>Image of the Product</p>

                   <asp:Panel ID="panelPopupImage" runat="server"></asp:Panel>  <!--En este panel se contendran las imagenes del producto.-->
           <asp:Button ID="btnClose" runat="server" Text="Close" OnClick="btnClose_Click"/> 
       
          </asp:Panel> 

               </ContentTemplate>

               <Triggers>

               </Triggers>

           </asp:UpdatePanel>

         </div>

 </div>
            <!--Fin contenido PopupWindow sobre las imagenes del producto -->
    </form>

 <script src="Script/ShowImagesSelected.js" defer> </script>

</body>
</html>
