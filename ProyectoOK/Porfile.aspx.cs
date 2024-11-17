using StoreOK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioOK;
using StoreOK;

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
            int count = 0;
           foreach(TheProduct product in listProductUserCart)
            {
                Button button = new Button();
                button.ID = "btn" + product.Product + $"{count.ToString()}";
                button.CommandArgument = product.IdProduct.ToString();
                button.Click += new EventHandler(ViewProduct);
                button.Text = product.Product;
                button.CssClass = "product-button btn btn-primary ";



                //button.CssClass = "btn btn-primary btn-sm mt-2";


                Button buttonDelete = new Button();
                buttonDelete.ID = "btnDelete" + product.Product + $"{count.ToString()}";
                buttonDelete.CommandArgument = product.IdProduct.ToString();
                buttonDelete.Click += new EventHandler(DeleteUserCart);
                buttonDelete.Text = "Delete of the cart";
                buttonDelete.CssClass = "product-button btn btn-warning ";


                //buttonDelete.CssClass = "btn btn-warning btn-sm mt-2";

                Image imageCover = new Image();
                imageCover.ImageUrl = GetImageCoverProduct(product.IdProduct);
                imageCover.CssClass = "product-image";

                //imageCover.CssClass = "img-thumbnail m-2 ";
                //imageCover.Style.Add("max-width","500px");


                showProductImageCover.Controls.Add(imageCover);
                showProductImageCover.Controls.Add(button);
                showProductImageCover.Controls.Add(buttonDelete);
                count++;
            }
        }

        private void ViewProduct(object sender, EventArgs e) //Generamos botones y agregmaos valor id al commandArgument.
        {
            Button btn = (Button)sender;
            string idProduct = btn.CommandArgument;
            Session.Add("idProduct", idProduct);
            Response.Redirect("ViewProduct.aspx");
        }

        private void DeleteUserCart(object sender, EventArgs e) //Generamos botones y agregmaos valor id al commandArgument.
        {
            Button btn = (Button)sender;
            string idProduct = btn.CommandArgument;

            TheProcedures theProcedures = new TheProcedures();
            theProcedures.DeleteUserCart(int.Parse(idProduct));
            
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