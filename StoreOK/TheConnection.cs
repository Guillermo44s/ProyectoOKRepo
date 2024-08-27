using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace StoreOK
{
    internal class TheConnection
    {
      //  string stringConecction = "Data Source=DESKTOP-ICI6NND\\SQLEXPRESS;Initial Catalog=BD_ProyectoOK;User=sa;Password=esea";
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;
        public SqlDataReader Reader
        {
            get { return reader; }
        }
        
        internal TheConnection()
        {
            connection = new SqlConnection("Data Source=DESKTOP-ICI6NND\\SQLEXPRESS;Initial Catalog=BD_ProyectoOK;User=sa;Password=esea");
            command = new SqlCommand();
        }

        internal void SetQuery(string query)
        {
            command.CommandText = query;
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;
        }

  
        internal void SetParameters(string name, object value)
        {
            command.Parameters.AddWithValue(name, value);
        }

        internal void ExecuteAction()
        {
            command.Connection.Open();
            command.ExecuteNonQuery();
        }

        internal int ExecuteActionScalar()
        {
             int id;
             command.Connection.Open();
            /*
               id = int.Parse(command.ExecuteScalar().ToString()); //DEVUELVE EL RESULTADO DE LA PRIMER FILA.
               return id;
            */
            return id = int.Parse(command.ExecuteScalar().ToString());
        }

        internal void ExecuteQuery()
        {
            command.Connection.Open();
            reader = command.ExecuteReader();
        }

        internal void CloseConnection()
        {
            if(reader != null)
            {
                reader.Close();
                connection.Close();
            }
        }
    }
}
