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
    public class NoleggioManager
    {
        public NoleggioManager(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        public string ConnectionString { get; set; }
        public NoleggioModel GetNoleggio(int? id)
        {
            var noleggioModel = new NoleggioModel();
            var sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("SAVeicoli.[Id]");
            sb.AppendLine(",SAClienti.[IdVeicolo]");
            sb.AppendLine(",SAClienti.[NomeCliente]");
            sb.AppendLine(",SAVeicoli.[IdMarca]");
            sb.AppendLine(",SAMarche.[Marca]");
            sb.AppendLine(",SAVeicoli.[Modello]");
            sb.AppendLine(",SAVeicoli.[Targa]");
            sb.AppendLine(",SAVeicoli.[IdCliente]");
            sb.AppendLine(",SAVeicoli.[StatoNoleggio]");
            sb.AppendLine("FROM [dbo].[SAVeicoli]");
            sb.AppendLine("LEFT JOIN SAClienti ON SAVeicoli.Id=SAClienti.IdVeicolo AND SAVeicoli.IdCliente=SAClienti.Id");
            sb.AppendLine("LEFT JOIN SAMarche ON SAVeicoli.IdMarca=SAMarche.Id");
            sb.AppendLine("WHERE SAVeicoli.Id=@Id");

            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString()))
                {
                    using (var sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlCommand.Parameters.AddWithValue("@Id", id);

                        sqlDataAdapter.SelectCommand = sqlCommand;
                        sqlDataAdapter.SelectCommand.Connection = sqlConnection;
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
                        if (dataTable.Rows.Count == 0)
                        {
                            return null;
                        }
                        DataRow row = dataTable.Rows[0];
                        noleggioModel.IdVeicolo = row.Field<int>("Id");
                        noleggioModel.Marca = row.Field<string>("Marca");
                        noleggioModel.Modello = row.Field<string>("Modello");
                        noleggioModel.Targa = row.Field<string>("Targa");
                        noleggioModel.StatoNoleggio = row.Field<string>("StatoNoleggio");
                        noleggioModel.NomeCliente = row.Field<string>("NomeCliente");
                        noleggioModel.IdCliente = row.Field<int?>("IdCliente");
                    }
                    return noleggioModel;
                }
            }
        }
        public bool InsertNoleggio(NoleggioModel noleggioModel)
        {
            bool isInserito = false;
            int? idInserito = null;
            var sb = new StringBuilder();
            sb.AppendLine("INSERT INTO [dbo].[SAClienti] (");
            sb.AppendLine("[IdVeicolo]");
            sb.AppendLine(",[NomeCliente]");
            sb.AppendLine(") VALUES (");
            sb.AppendLine("@IdVeicolo");
            sb.AppendLine(",@NomeCliente");
            sb.AppendLine(")");
            sb.AppendLine(" SELECT SCOPE_IDENTITY()");

            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString(), sqlConnection))
                {
                   
                        sqlCommand.Parameters.AddWithValue("@IdVeicolo", noleggioModel.IdVeicolo);
                        sqlCommand.Parameters.AddWithValue("@NomeCliente", noleggioModel.NomeCliente);
                  
                    object value = sqlCommand.ExecuteScalar();
                    if (value != null && value != DBNull.Value)
                    {
                        idInserito = Convert.ToInt32(value);
                        noleggioModel.IdCliente = idInserito.Value;
                    }
                }
            }
            return isInserito; ;
        }
        public bool UpdateNoleggio(NoleggioModel noleggioModel)
        {
            var sb = new StringBuilder();
            sb.AppendLine("UPDATE [dbo].[SAVeicoli] ");
            sb.AppendLine("SET");
            sb.AppendLine("IdCliente=@IdCliente");
            sb.AppendLine(",StatoNoleggio=@StatoNoleggio");
            sb.AppendLine("WHERE SAVeicoli.Id=@Id");

            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString(), sqlConnection))
                {
                    string statoNoleggio = noleggioModel.StatoNoleggio == "Si" ? "No" : "Si";

                    sqlCommand.Parameters.AddWithValue("@Id", noleggioModel.IdVeicolo);
                    sqlCommand.Parameters.AddWithValue("@StatoNoleggio", statoNoleggio);
                    if (noleggioModel.StatoNoleggio == "No")
                    {
                        if (noleggioModel.IdCliente.HasValue)
                        {
                            sqlCommand.Parameters.AddWithValue("@IdCliente", noleggioModel.IdCliente);
                        }
                        else
                        {
                            sqlCommand.Parameters.AddWithValue("@IdCliente", DBNull.Value);
                        }
                    }
                    else
                    {
                        if (noleggioModel.IdCliente.HasValue)
                        {
                            sqlCommand.Parameters.AddWithValue("@IdCliente", DBNull.Value);
                        }
                        else
                        {
                            sqlCommand.Parameters.AddWithValue("@IdCliente", noleggioModel.IdCliente);
                        }
                    }
                    var numRigheModificate = sqlCommand.ExecuteNonQuery();
                }
            }
            return true;
        }
        public bool DeleteNoleggio(NoleggioModel noleggioModel)
        {
            bool isDelete = false;
            var sb = new StringBuilder();
            sb.AppendLine("Delete");
            sb.AppendLine("FROM [dbo].[SAClienti]");
            sb.AppendLine("WHERE Id=@Id");

            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString(), sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@Id", noleggioModel.IdCliente);
                    var numRigheModificate = sqlCommand.ExecuteNonQuery();
                }
            }
            return isDelete;
        }
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
            sb.AppendLine("WHERE [NomeCliente]=@NomeCliente");

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
