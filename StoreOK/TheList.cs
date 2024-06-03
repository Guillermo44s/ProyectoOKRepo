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
                connection.ExecuteQuery();
                TheProduct product = new TheProduct();
                List<TheProduct> listproduct = new List<TheProduct>();
                while (connection.Reader.Read())
                {
                    product.IdProduct = int.Parse(connection.Reader[""].ToString());
                    product.Product = connection.Reader[""].ToString();
                    product.Description = connection.Reader[""].ToString();
                    product.Price = (Decimal)connection.Reader[""];
                    product.Available = (bool)connection.Reader[""];
                    product.Cant = int.Parse(connection.Reader[""].ToString());
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

