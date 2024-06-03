using DominioOK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioOK;

namespace StoreOK
{
    public class TheProcedures
    {
        public int AddProduct(TheProduct theProduct)
        {
            int id; //Vendira ser el id del producto
            TheConnection connection = new TheConnection();
            try
            {
            connection.SetParameters("@Product",theProduct.Product);
            connection.SetParameters("@Description",theProduct.Description);
            connection.SetParameters("@Price",theProduct.Price);
            connection.SetParameters("@Available",theProduct.Available);
            connection.SetParameters("@Cant",theProduct.Cant);
            connection.SetQuery("insert Product(Product,Description,Price,Available,Cant) values(@Product,@Description,@Price,@Available,@Cant) select scope_identity()");
            id = connection.ExecuteActionScalar();
            return id; //Le devolvemos el id del producto recien cargado a la bd
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.CloseConnection();
            }
        }
    }
}
