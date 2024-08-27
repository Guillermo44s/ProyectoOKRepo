using StoreOK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StoreOK;
using DominioOK;
using System.IO;
using System.Reflection;
using AjaxControlToolkit.Bundling;

namespace ProyectoOK
{
    public partial class FormProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int tempId = 0;
            if (Session["idProduct"] != null)
            {
                tempId = int.Parse(Session["idProduct"].ToString());
            }

            if (!IsPostBack)
            {
                if (Session["idProduct"] != null)
                {
                    TheList theList = new TheList();
                    TheProduct theProduct = new TheProduct();
                    tempId = int.Parse((Session["idProduct"].ToString()));

                    List<TheProduct> listProduct = theList.GetListProducts(); //Obtenemos la lista de todos los productos de la BD.                
                    theProduct = listProduct.FirstOrDefault(p => p.IdProduct == int.Parse((Session["idProduct"].ToString())));  //Expresion lambda para filtrar y obtener el producto con el id correspondiente de la lista.

                    txtProduct.Text = theProduct.Product;
                    txtDescription.Text = theProduct.Description;
                    txtPrice.Text = theProduct.Price.ToString();
                    chkAvailable.Checked = theProduct.Available;
                    txtCant.Text = theProduct.Cant.ToString();
                    txtIdProduct.Text = theProduct.IdProduct.ToString();

                }
            }
            if (tempId != 0)
            {
                TheImages theImages = new TheImages();
                List<string> listUrlImage = new List<string>();
                listUrlImage = theImages.GetUrlImagesProduct(tempId); //checkea que aca iba el id del producto.
                Image imageProductCover = (Image)Page.FindControl("imgProductCover");

                //Aqui se busca y carga la imagen de portada.
                for (int i = 0; i < listUrlImage.Count; i++)
                {
                    string relativePath = @"~/ImageCover/";
                    string physicalPath = Server.MapPath("/ImageCover/" + listUrlImage[i]);
                    string imagePath = relativePath + listUrlImage[i];
                    if (System.IO.File.Exists(physicalPath))
                    {
                        imageProductCover.ImageUrl = imagePath;

                        ImageButton imageButton = new ImageButton();
                        string nameImage = listUrlImage[i];
                        imageButton.ImageUrl = imagePath;
                        imageButton.Click += (s, ev) => DelteProductImagen(s, ev, physicalPath, nameImage);
                        panelPopupImageCover.Controls.Add(imageButton);
                        break;
                    }
                }

                //Aqui se buscan y cargan las imagenes del prodcuto.
                for (int i = 0; i < listUrlImage.Count; i++)
                {
                    string relativePath = @"~/Image/";
                    string physicalPath = Server.MapPath("/Image/" + listUrlImage[i]);
                    string imagePath = relativePath + listUrlImage[i];
                    if (System.IO.File.Exists(physicalPath))
                    {
                        Image image = new Image();
                        image.ImageUrl = imagePath;
                        containerProductImagen.Controls.Add(image);

                        //Para la colocacion de imagenes botones del producto.
                        ImageButton imageButton = new ImageButton();
                        string nameImage = listUrlImage[i];
                        imageButton.ImageUrl = imagePath;
                        imageButton.ID = "imageButton"+ i;
                        imageButton.Click += (s, ev) => DelteProductImagen(s, ev, physicalPath, nameImage);
                        panelPopupImage.Controls.Add(imageButton); //Agregamos las imagenes botones al popupWindow.
                    }
                }
            }             
        }

        protected void btnSaveProduct_Click(object sender, EventArgs e)
        {
            TheProcedures theProcedures = new TheProcedures();
            TheProduct theProduct = new TheProduct();   
            FileUpload imagenProductCover = (FileUpload)FindControl("fileInputImageCover");
            HttpFileCollection fileCollection = Request.Files; //Aqui se tomas las iamgenes del "fileInputProductImages"
            try
            {
                
                theProduct.Product = txtProduct.Text;
                theProduct.Description = txtDescription.Text;
                theProduct.Price = Decimal.Parse(txtPrice.Text);
                theProduct.Available = chkAvailable.Checked;
                theProduct.Cant = int.Parse(txtCant.Text);

                //Aqui filtramos las imagenes del FileUpload "fileInputImages" del otro "FileInputCover".
                List<HttpPostedFile> listProductImages = new List<HttpPostedFile>();
                foreach(HttpPostedFile image in fileCollection.GetMultiple("fileInputProductImages"))
                {
                    listProductImages.Add(image);
                }

                if (Session["idProduct"] == null)
                {
                    int idProduct = theProcedures.AddProduct(theProduct);
                    SaveImages(imagenProductCover, listProductImages, idProduct); //Llamamos al metodo AddProduct para agregar un producto y obtener el id producto para guardar la imagen.

                    Session["idProduct"] = idProduct;
                    Response.Redirect("MenuAdmin.aspx");
                    //Response.Redirect("FormProduct.aspx");
                }
                else{
                    theProduct.IdProduct = int.Parse(Session["idProduct"].ToString());
                    theProduct.Product = txtProduct.Text;
                    theProduct.Description = txtDescription.Text;
                    theProduct.Price = Decimal.Parse(txtPrice.Text);
                    theProduct.Available = chkAvailable.Checked;
                    theProduct.Cant = int.Parse(txtCant.Text);  
                    
                    SaveImages(imagenProductCover, listProductImages, int.Parse(Session["idProduct"].ToString()));
                    theProcedures.UpdateProduct(theProduct);
                 Response.Redirect("MenuAdmin.aspx");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //HttpFileCollection 

        private void SaveImages(FileUpload imagenProductCover, List<HttpPostedFile> listProductImages, int idProduct)
        {                             
            string  pathImages = Server.MapPath(@"\Image\");  
            string pathImageCover = Server.MapPath(@"\ImageCover\");
            TheImages theImages = new TheImages();
            try
            {
                if (imagenProductCover.PostedFile.ContentType.Contains("image/jpeg") || imagenProductCover.PostedFile.ContentType.Contains("image/png"))
                {
                    string pathToCheck = pathImageCover + imagenProductCover.FileName;
                    string tempFileName = "";
                    string fileName = imagenProductCover.FileName;
                    if (System.IO.File.Exists(pathToCheck))
                    {
                        int counter = 2;
                        while (System.IO.File.Exists(pathToCheck))
                        {
                            tempFileName = counter.ToString() + "-" + fileName;
                            pathToCheck = pathImages + tempFileName;
                            counter++;
                        }
                        fileName = tempFileName;
                    }
                    imagenProductCover.SaveAs(pathImageCover + fileName);
                    theImages.SaveProductImages(fileName, idProduct);
                }
                    for (int i = 0; i < listProductImages.Count; i++)
                {
                    HttpPostedFile image = listProductImages[i];
                    string fileName = image.FileName;
                    if (image.ContentType.Contains("image/jpeg") || image.ContentType.Contains("image/png"))
                    {
                        string pathToCheck = pathImages + fileName;
                        string tempFileName = "";
                        if (System.IO.File.Exists(pathToCheck))
                        {
                            int counter = 2;
                            while (System.IO.File.Exists(pathToCheck))
                            {
                                tempFileName = counter.ToString() + "-" + fileName;
                                pathToCheck = pathImages + tempFileName;
                                counter++;
                            }
                            fileName = tempFileName;

                        }
                        image.SaveAs(pathImages + fileName);
                        theImages.SaveProductImages(fileName, idProduct);
                        fileName = "";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        private void DelteProductImagen(object sender, ImageClickEventArgs e, string physicalPhat,string nameImage)
        {
           TheImages theImages = new TheImages();
            File.Delete(physicalPhat);
                theImages.DelteProductImagen(nameImage);
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormProduct.aspx");
        }

        protected void btnClose1_Click(object sender, EventArgs e)
        {
            
          Response.Redirect("FormProduct.aspx");
        }

        protected void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            TheProcedures theProcedures = new TheProcedures();
            theProcedures.DeleteProduct(int.Parse(Session["idProduct"].ToString()));

            TheImages theImages = new TheImages();
            List<string> listUrlImage = theImages.GetUrlImagesProduct(int.Parse(Session["idProduct"].ToString()));
            for (int i = 0; i < listUrlImage.Count; i++)
            {
                string physicalPathImageCover = Server.MapPath("/ImageCover/" + listUrlImage[i]);
                if (System.IO.File.Exists(physicalPathImageCover))
                {
                    File.Delete(physicalPathImageCover);
                }
                    string physicalPath = Server.MapPath("/Image/" + listUrlImage[i]);
                if (System.IO.File.Exists(physicalPath))
                {
                    File.Delete(physicalPath);
                    theImages.DelteProductImagen(listUrlImage[i]);
                }
            }
            Response.Redirect("MenuAdmin.aspx");
        }
    }
    
}
//TODO: Se debe valiar en el formulario que solo se prodra cargar la infomracion si completo todos los campos incluso imagen de portada y demas.
//TODO: La grilla funciona mal, muestra siempre el ultimo registro que se carg, no se porque. 
