using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioOK;

namespace StoreOK
{
    public class TheImages
    {
   
        public void SaveProductImages(string urlImage, int idProduct)
        {          
            TheConnection connection = new TheConnection();
            TheImage image = new TheImage();

            try
            {
                connection.SetQuery("insert into Image (UrlImage,IdProduct) values(@UrlImage,@IdProduct)");
                connection.SetParameters("@UrlImage", urlImage);
                connection.SetParameters("@IdProduct", idProduct);
                connection.ExecuteAction();
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            finally 
            {
                //Puede que llamar a este metodo de error porque el procedimiento de arriba no da ningun valor para que la condicion del metodo CloseConnection se cumpla, atento a eso...
                connection.CloseConnection();
            }
        }

        public void DelteProductImagen(string urlImage)
        {
            TheConnection connection = new TheConnection();
            TheImage image = new TheImage();

            try
            {
                connection.SetQuery("delete Image  where UrlImage = @UrlImage");
                connection.SetParameters("@UrlImage", urlImage);             
                connection.ExecuteAction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Puede que llamar a este metodo de error porque el procedimiento de arriba no da ningun valor para que la condicion del metodo CloseConnection se cumpla, atento a eso...
                connection.CloseConnection();
            }
        }

        public List<string> GetUrlImagesProduct(int idProduct)
        {
            TheConnection connection = new TheConnection();
            TheImage theImage = new TheImage();
            List<string> urlImages = new List<string>();
            try
            {
                connection.SetQuery("Select UrlImage from Image  where IdProduct = @IdProduct");
                connection.SetParameters("@IdProduct", idProduct);
                connection.ExecuteQuery();
                while(connection.Reader.Read())
                {                  
                    theImage.UrlImage = (string)connection.Reader["UrlImage"];                 
                    urlImages.Add(theImage.UrlImage);
                }
                return urlImages;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Puede que llamar a este metodo de error porque el procedimiento de arriba no da ningun valor para que la condicion del metodo CloseConnection se cumpla, atento a eso...
                connection.CloseConnection();
            }
        }

    }
}
