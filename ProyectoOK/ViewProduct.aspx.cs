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
    public partial class ViewProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int idProduct = int.Parse(Session["idProduct"].ToString());

            TheList theList = new TheList();
            TheProduct theProduct = new TheProduct();
            TheImages theImages = new TheImages();

            List<TheProduct> listProducts = theList.GetListProducts();

            theProduct = listProducts.FirstOrDefault(x => x.IdProduct == idProduct);

            lblProduct.Text = theProduct.Product;
            lblDescription.Text = theProduct.Description;
            lblPrice.Text = theProduct.Price.ToString();

            List<string> listProductImages = theImages.GetUrlImagesProduct(idProduct);

            for(int i = 0; i < listProductImages.Count; i++)
            {
                string relativePath = @"~/ImageCover/";
                string physicalPath = Server.MapPath("/ImageCover/" + listProductImages[i]);
                string imagePath = relativePath + listProductImages[i];
                if (System.IO.File.Exists(physicalPath))
                {
                    Image imageCover = new Image();
                    imageCover.ImageUrl = imagePath;
                    panelShowImageCover.Controls.Add(imageCover);
                    break;
                }
            }

            for (int i = 0; i < listProductImages.Count; i++)
            {
                string relativePath = @"~/Image/";
                string physicalPath = Server.MapPath("/Image/" + listProductImages[i]);
                string imagePath = relativePath + listProductImages[i];
                if (System.IO.File.Exists(physicalPath))
                {
                    Image image = new Image();
                    image.ImageUrl = imagePath;
                    panelShowTheImagePorduct.Controls.Add(image);
                }
            }

        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            TheProcedures theProcedures = new TheProcedures();
            theProcedures.AddProductToCart(User.Identity.Name,int.Parse(Session["idProduct"].ToString()));
        }
    }
}