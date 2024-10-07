using DominioOK;
using StoreOK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoOK
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {         
                List<TheProduct> listAvailableProducts = GetAvailableProducts();
                foreach (TheProduct product in listAvailableProducts)
                {
                    Button button = new Button();
                    button.ID = "btn" + product.Product;
                    button.CommandArgument = product.IdProduct.ToString();
                    button.Click += new EventHandler(ViewProduct);
                    button.Text = product.Product;

                    Image imageCover = new Image();
                    imageCover.ImageUrl = GetImageCoverProduct(product.IdProduct);

                    showAvailableProduct.Controls.Add(imageCover);
                    showAvailableProduct.Controls.Add(button);    
                }
        }

        private List<TheProduct> GetAvailableProducts() //Traemos los productos y filtramos los disponibles.
        {
            TheList theList = new TheList();
            List<TheProduct> listProducts = theList.GetListProducts();       
            List<TheProduct> listAvailableProducts = listProducts.FindAll(x => x.Available == true); //Predicate en lambda, tomar solo productos disponibles.
            return listAvailableProducts;
        }

        private void ViewProduct(object sender, EventArgs e) //Generamos botones y agregmaos valor id al commandArgument.
        {
            Button btn = (Button)sender;
            string idProduct = btn.CommandArgument;
            Session.Add("idProduct", idProduct);
            Response.Redirect("ViewProduct.aspx");
        }

        private string GetImageCoverProduct(int idProduct)
        {
            TheImages theImages = new TheImages();
            List<string> urlImageProduct = theImages.GetUrlImagesProduct(idProduct);
            string urlImage = "";
            foreach (string obj in urlImageProduct)
            {
                string relativePath = @"~/ImageCover/";
                string physicalPath = Server.MapPath("/ImageCover/" + obj);
                if (System.IO.File.Exists(physicalPath))
                {
                    urlImage = relativePath + obj;
                }
            }
            return urlImage;
        }
    }
    }
