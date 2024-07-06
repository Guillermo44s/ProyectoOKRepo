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

namespace ProyectoOK
{
    public partial class FormProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
               if (Session["idProduct"] != null)
               {                
                TheList theList = new TheList();    
                TheProduct theProduct = new TheProduct();
                List<TheProduct> listProduct = theList.GetListProduct(); //Obtenemos la lista de todos los productos de la BD.                
                theProduct = listProduct.FirstOrDefault(p => p.IdProduct == int.Parse(Session["idProduct"].ToString()));  //Expresion lambda para filtrar y obtener el producto con el id correspondiente de la lista.
                txtProduct.Text = theProduct.Product;
                txtDescription.Text = theProduct.Description;
                txtPrice.Text = theProduct.Price.ToString();
                chkAvailable.Checked = theProduct.Available;
                txtCant.Text = theProduct.Cant.ToString();
                txtIdProduct.Text = theProduct.IdProduct.ToString();
              
                TheImages theImages = new TheImages(); 
                List<string> listUrlImages = new List<string>();
                listUrlImages = theImages.GetUrlImagesProduct(theProduct.IdProduct);
                Image imageProductCover = (Image)Page.FindControl("imgProductCover");

                
                //Aqui se busca y carga la imagen de portada.
                for(int i = 0; i < listUrlImages.Count; i++)
                {
                string relativePath = @"~/ImageCover/";
                string physicalPath = Server.MapPath("/ImageCover/"+listUrlImages[i]);
                string imagePath = relativePath + listUrlImages[i];
                if(System.IO.File.Exists(physicalPath))
                    {
                    imageProductCover.ImageUrl = imagePath;    
                    break;
                    }
                }

                for (int i = 0; i < listUrlImages.Count; i++)
                {
                string relativePath = @"~/Image/";
                string physicalPath = Server.MapPath("/Image/" + listUrlImages[i]);
                string imagePath = relativePath + listUrlImages[i];
                    if (System.IO.File.Exists(physicalPath))
                    {
                        Image image = new Image();
                        image.ImageUrl = imagePath;
                        containerProductImagen.Controls.Add(image);
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

                int idProduct = theProcedures.AddProduct(theProduct);
                SaveImages(imagenProductCover, listProductImages, idProduct); //Llamamos al metodo AddProduct para agregar un producto y obtener el id producto para guardar la imagen.

                Session["idProduct"] = idProduct;
                Response.Redirect("FormProduct.aspx");

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
    }
}
//TODO: Se debe valiar en el formulario que solo se prodra cargar la infomracion si completo todos los campos incluso imagen de portada y demas.