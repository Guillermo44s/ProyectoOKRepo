using StoreOK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StoreOK;
using DominioOK;

namespace ProyectoOK
{
    public partial class FormProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSaveProduct_Click(object sender, EventArgs e)
        {          
            TheProcedures theProcedures = new TheProcedures();
            TheProduct theProduct = new TheProduct();
            //FileUpload file = (FileUpload)FindControl("fileImagen");
            HttpFileCollection fileCollection = Request.Files;
            try
            {
                
                theProduct.Product = txtProduct.Text;
                theProduct.Description = txtDescription.Text;
                theProduct.Price = Decimal.Parse(txtPrice.Text);
                theProduct.Available = chkAvailable.Checked;
                theProduct.Cant = int.Parse(txtCant.Text); 
                //theProcedures.AddProduct(theProduct);            
                SaveImageFile(fileCollection, theProcedures.AddProduct(theProduct)); //Llamamos al metodo AddProduct para agregar un producto y obtener el id producto para guardar la imagen.
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void ShowSelectedImages(int idProduct)
        {
            TheImages theImages = new TheImages();
            List<string> listUrlImages = theImages.GetUrlImagesProduct(idProduct);
            try
            {
                //Image image = (Image)Page.FindControl("imgImage");
                foreach (string obj in listUrlImages)
                {
                    Image image = new Image();
                    image.ID = "imgImage";
                    image.ImageUrl = "~\\Image\\" + obj;
                    Page.Controls.Add(image);
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        private void SaveImageFile(HttpFileCollection fileCollection,int idProduct)
        {
            string path = Server.MapPath(@"~\Image\");         
            TheImages theImages = new TheImages();   
            List<string> listFileName = new List<string>(); 
            try
            {
                for(int i = 0; i < fileCollection.Count; i++) 
                {
                HttpPostedFile file = fileCollection[i];                
                 string fileName = file.FileName;
                if (file.ContentType.Contains("image/jpeg") || file.ContentType.Contains("image/png"))
                {
                    string pathToCheck = path + "/" + fileName;
                    string tempFileName = "";
                    if (System.IO.File.Exists(pathToCheck))
                    {
                        int counter = 2;
                        while (System.IO.File.Exists(pathToCheck))
                        {
                            tempFileName = counter.ToString() + "-" + fileName;
                            pathToCheck = path + tempFileName;
                            counter++;
                        }
                        fileName = tempFileName;
                    }
                    listFileName.Add(fileName);                  
                    file.SaveAs(path + fileName);
                    theImages.SaveProductImages(fileName, idProduct);
                    fileName = "";
                }
                }
                ShowSelectedImages(idProduct);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}