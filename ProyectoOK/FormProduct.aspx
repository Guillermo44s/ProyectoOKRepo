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
    
        <!-- PROBANDO DISEÑO NUEVO... --> 

        <div class="container mt-5">

            <h2 class="text-center mb-4">Form Prouct and Details</h2>

            <div class="row">

            <div class="col-md-6 mb-3"">
                <asp:Label ID="lblIdProduct" runat="server" CssClass="form-label" Text="ID"></asp:Label>
                <asp:TextBox ID="txtIdProduct" CssClass="form-control" runat="server"></asp:TextBox>

            </div>

<div class="col-md-6 mb-3"">

    <asp:Label ID="lblProduct" CssClass="form-label" runat="server" Text="Product"></asp:Label>
    <asp:TextBox ID="txtProduct" CssClass="form-control" runat="server"></asp:TextBox>

</div>

 <div class="col-md-6 mb-3">

     <asp:Label ID="lblDescription" CssClass="form-label" runat="server" Text="Description"></asp:Label>
    <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server"></asp:TextBox>

 </div>

 <div class="col-md-6 mb-3">

     <asp:Label ID="lblPrice" CssClass="form-label" runat="server" Text="Price"></asp:Label>
    <asp:TextBox ID="txtPrice" CssClass="form-control" runat="server"></asp:TextBox>

 </div>

 <div class="col-md-6 mb-3 d-flex align-items-center">

     <asp:Label ID="lblAvailable"  CssClass="form-label me-2" runat="server" Text="Available"></asp:Label>
    <asp:CheckBox ID="chkAvailable" CssClass="form-check-input" runat="server" />

 </div>

 <div class="col-md-6 mb-3">

    <asp:Label ID="lblCant" CssClass="form-label" runat="server" Text="Cant"></asp:Label>
    <asp:TextBox ID="txtCant" runat="server"></asp:TextBox>

 </div>
                </div>


            </div>
   

        <!-- FIN DISEÑO NUEVO -->

        <div class="container mt-4">

            <div class="row mb-4">

                 <div class="col-md-6">

    <asp:FileUpload ID="fileInputImageCover" CssClass="form-control" runat="server"/>

     <div id="imagePreviewCover" class="mt-3">

         <h2>Cover Image</h2>
         <asp:Image ID="imgProductCover" CssClass="img-fluid" runat="server" />

    </div>
                     </div>

                 <div class="col-md-6">

                <asp:FileUpload ID="fileInputProductImages" runat="server"  CssClass="form-control" AllowMultiple="true"/>
                 <h2>Product Image</h2>

                      <div  id="imagePreview" class="d-flex flex-wrap">
                <asp:Panel ID="containerProductImagen" CssClass="d-flex flex-wrap" runat="server"></asp:Panel>

                          </div>

                     </div>

                </div>

            </div>

<div>

</div>

   <!--         <div class="col" id="imagePreview"></div> -->


        <div class="container mt-4">

   <asp:ScriptManager ID="ScriptManagerPopupWindow" runat="server"></asp:ScriptManager>   
            
             <div class="row mb-3">
        <div class="col text-center">

  <asp:Button ID="btnSaveProduct" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSaveProduct_Click"/>

            </div>

                 </div>


        <div class="row mb-3">
        <div class="col text-center">

         <asp:Button ID="btnDeleteProduct" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDeleteProduct_Click" />


            </div>
            </div>


        <div class="row mb-3">
        <div class="col text-center">

     <asp:Button ID="btnDeletePorductImageCover" runat="server" CssClass="btn btn-warning" Text="Delete Product Image Cover"/>
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
            </div>



                <div class="row mb-3">
                       <div class="col text-center">

         <asp:Button ID="btnDeleteProductImage" CssClass="btn btn-warning" runat="server" Text="Delete Product Image"/>

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
         
            </div>

    </form>

 <script src="Script/ShowImagesSelected.js" defer> </script>

             
    

</body>
</html>
