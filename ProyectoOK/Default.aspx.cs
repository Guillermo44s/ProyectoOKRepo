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
    public partial class Default : System.Web.UI.Page
    {
    public List<TheProduct> listproduct {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {          
                TheList thelist = new TheList();
                listproduct = thelist.getListProduct();          
        }
    }
}