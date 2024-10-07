using StoreOK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioOK;

namespace ProyectoOK
{
    public partial class Porfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {          
                lblUserName.Text = User.Identity.Name;
                LoadUserCart();         
        }

        public void LoadUserCart()
        {
           TheList theList = new TheList();
           List<TheProduct> listProductUserCart =  theList.GetProductUserCart(User.Identity.Name);
            
           foreach(TheProduct product in listProductUserCart)
            {
                Button button = new Button();
                button.ID = "btn" + product.Product;
                button.CommandArgument = product.IdProduct.ToString();
                button.Click += new EventHandler(ViewProduct);
                button.Text = product.Product;

                Image imageCover = new Image();
                imageCover.ImageUrl = GetImageCoverProduct(product.IdProduct);

                showProductImageCover.Controls.Add(imageCover);
                showProductImageCover.Controls.Add(button);
            }
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