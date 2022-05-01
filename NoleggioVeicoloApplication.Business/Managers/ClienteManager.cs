using NoleggioVeicoloApplication.Business.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioVeicoloApplication.Business.Managers
{
    public class ClienteManager
    {
        public ClienteManager(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        public string ConnectionString { get; set; }

        public bool UpdateDatiCliente(ClienteModel clienteModel)
        {
            bool isUpdate = false;
            var sb = new StringBuilder();
            sb.AppendLine("UPDATE [dbo].[SAClienti] ");
            sb.AppendLine("SET");
            sb.AppendLine("[CodiceFiscale]=@CodiceFiscale");
            sb.AppendLine(",[DataNascita]=@DataNascita");
            sb.AppendLine(",[Email]=@Email");
            sb.AppendLine(",[Telefono]=@Telefono");
            sb.AppendLine(",[NumeroPatente]=@NumeroPatente");
            sb.AppendLine(",[Nazione]=@Nazione");
            sb.AppendLine(",[Provincia]=@Provincia");
            sb.AppendLine(",[Citta]=@Citta");
            sb.AppendLine(",[Indirizzo]=@Indirizzo");
            sb.AppendLine("WHERE NomeCliente=@NomeCliente");

            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString(), sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@NomeCliente", clienteModel.NomeCliente);

                    if (!string.IsNullOrEmpty(clienteModel.CodiceFiscale))
                    {
                        sqlCommand.Parameters.AddWithValue("@CodiceFiscale", clienteModel.CodiceFiscale);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@CodiceFiscale", DBNull.Value);
                    }
                    if (clienteModel.DataNascita.HasValue)
                    {
                        sqlCommand.Parameters.AddWithValue("@DataNascita", clienteModel.DataNascita);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@DataNascita", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(clienteModel.Email))
                    {
                        sqlCommand.Parameters.AddWithValue("@Email", clienteModel.Email);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Email", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(clienteModel.Telefono))
                    {
                        sqlCommand.Parameters.AddWithValue("@Telefono", clienteModel.Telefono);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Telefono", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(clienteModel.NumeroPatente))
                    {
                        sqlCommand.Parameters.AddWithValue("@NumeroPatente", clienteModel.NumeroPatente);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@NumeroPatente", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(clienteModel.Nazione))
                    {
                        sqlCommand.Parameters.AddWithValue("@Nazione", clienteModel.Nazione);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Nazione", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(clienteModel.Provincia))
                    {
                        sqlCommand.Parameters.AddWithValue("@Provincia", clienteModel.Provincia);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Provincia", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(clienteModel.Citta))
                    {
                        sqlCommand.Parameters.AddWithValue("@Citta", clienteModel.Citta);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Citta", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(clienteModel.Indirizzo))
                    {
                        sqlCommand.Parameters.AddWithValue("@Indirizzo", clienteModel.Indirizzo);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Indirizzo", DBNull.Value);
                    }
                    var numRigheModificate = sqlCommand.ExecuteNonQuery();
                }
            }
            return isUpdate;
        }
    }
}
