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
            if (!IsPostBack)
            {

            }
                List<TheProduct> listAvailableProducts = GetAvailableProducts();
                foreach (TheProduct product in listAvailableProducts)
                {
                    Button button = new Button();
                    button.ID = "btn" + product.Product;
                    button.CommandArgument = product.IdProduct.ToString();
                    button.Click += new EventHandler(ViewProduct);
                    button.Text = "View " + product.Product;
                    showAvailableProduct.Controls.Add(button);
                }
            
        }

        private List<TheProduct> GetAvailableProducts()
        {
            TheList theList = new TheList();
            List<TheProduct> listProducts = theList.GetListProducts();

            Predicate<TheProduct> isAvailable = availableProduct => availableProduct.Available == true; //Predicado para filtrar los productos disponibles en expresion lambda.

            List<TheProduct> listAvailableProducts = listProducts.FindAll(isAvailable); //Recuperamos los valores que devolvio el predicado.

            return listAvailableProducts;
        }

        private void ViewProduct(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string idProduct = btn.CommandArgument;
            Session.Add("idProduct", idProduct);
            Response.Redirect("ViewProduct.aspx");
        }
    }
    }
