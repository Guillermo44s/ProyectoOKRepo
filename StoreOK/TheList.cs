using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DominioOK;

namespace StoreOK
{
    public class TheList
    {
        public List<TheProduct> GetListProduct()
        {
                TheConnection connection = new TheConnection();
            try
            {
                connection.SetQuery("select idProduct , product , price , [description] , cant, available " +
                                    "from Product");
                connection.GetData();
                TheProduct product = new TheProduct();
                List<TheProduct> listproduct = new List<TheProduct>();
                while (connection.Reader.Read())
                {
                    product.idProduct = int.Parse(connection.Reader["idProduct"].ToString());
                    product.product = connection.Reader["product"].ToString();
                    product.price = double.Parse(connection.Reader["price"].ToString());
                    product.description = connection.Reader["description"].ToString();
                    product.cant = int.Parse(connection.Reader["cant"].ToString());
                    product.available = (bool)connection.Reader["available"];
                    listproduct.Add(product);
                }
                return listproduct;
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                connection.CloseConnection();
            }
        }
    }
}

