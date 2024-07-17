using DominioOK;
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
    public partial class MenuAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            //TheProduct theProdct = new TheProduct();
            TheList theList = new TheList();
            dgvProduct.DataSource = theList.GetListProduct();
            dgvProduct.DataBind(); 
        }

        protected void btnGoFormProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormProduct.aspx");
        }

        protected void dgvProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idProduct = dgvProduct.SelectedDataKey.Value;
            Session["idProduct"] = idProduct;
            Response.Redirect("FormProduct.aspx");
        }
    }
}