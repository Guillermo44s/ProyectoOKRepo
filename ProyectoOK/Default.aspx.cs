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
                    button.Click += new EventHandler(ViewProduct);

                    button.CssClass = "product-button btn btn-primary ";


                //  button.CssClass = "btn btn-primary";
                //   button.Style.Add("width", "100%");
                //  button.Style.Add("max-height", "80px");
                //button.Style.Add("display", "block");
                //  button.Style.Add("margin", "0 auto");



                    Image imageCover = new Image();
                    imageCover.ImageUrl = GetImageCoverProduct(product.IdProduct);
                    imageCover.CssClass = "product-image";


                //  imageCover.CssClass = "img-fluid";
                //imageCover.Style.Add("max-width", "100%");
                //imageCover.Style.Add("max-height", "100%");

                //imageCover.Style.Add("object-fit", "cover");
                //CssClass="d-flex flex-wrap justify-content-start gap-3" clase para el panel...
                //container-fluid
                //Style="max-width: 400px; max-height: 400px; margin: 10px;"
                //card-img-top 

                //   Panel showAvailableProduct = new Panel();
                //  showAvailableProduct.CssClass = "card";
                //   showAvailableProduct.Style.Add("max-width", "400px");
                //    showAvailableProduct.Style.Add("max-height", "1000px");

                showAvailableProduct.Controls.Add(imageCover);
                showAvailableProduct.Controls.Add(button);

        //     panel.Controls.Add(showAvailableProduct);
             


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
