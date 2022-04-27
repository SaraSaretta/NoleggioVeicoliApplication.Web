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
        public NoleggioModel GetCliente(int? id)
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
            sb.AppendLine("LEFT JOIN SAClienti on SAVeicoli.Id=SAClienti.IdVeicolo");
            sb.AppendLine("LEFT JOIN SAMarche on SAVeicoli.IdMarca=SAMarche.Id");
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
                        //noleggioModel.IdCliente = row.Field<int>("IdCliente");


                    }
                    return noleggioModel;
                }
            }
        }
        public bool InsertCliente(NoleggioModel noleggioModel)
        {
            bool isInserito = false;
            var sb = new StringBuilder();
            sb.AppendLine("INSERT INTO [dbo].[SAClienti] (");
            sb.AppendLine("[IdVeicolo]");
            sb.AppendLine(",[NomeCliente]");
            sb.AppendLine(") VALUES (");
            sb.AppendLine("@IdVeicolo");
            sb.AppendLine(",@NomeCliente");
            sb.AppendLine(")");

            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString(), sqlConnection))
                {

                    if (noleggioModel.IdVeicolo > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@IdVeicolo", noleggioModel.IdVeicolo);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@IdVeicolo", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(noleggioModel.NomeCliente))
                    {
                        sqlCommand.Parameters.AddWithValue("@NomeCliente", noleggioModel.NomeCliente);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@NomeCliente", DBNull.Value);
                    }

                    var numRigheInserite = sqlCommand.ExecuteNonQuery();
                }
            }
            return isInserito;
        }
        public bool UpdateStatoNoleggioCliente(NoleggioModel noleggioModel)
        {
            bool isUpdate = false;
            var sb = new StringBuilder();
            sb.AppendLine("UPDATE [dbo].[SAVeicoli] ");
            sb.AppendLine("SET");
            sb.AppendLine("[SAVeicoli].[IdCliente]=[SAClienti].[Id]");
            sb.AppendLine(",StatoNoleggio=@StatoNoleggio");
            sb.AppendLine("FROM [SAVeicoli]");
            sb.AppendLine("INNER JOIN SAClienti");
            sb.AppendLine("ON SAVeicoli.Id=SAClienti.IdVeicolo");
            sb.AppendLine("WHERE SAVeicoli.Id=@Id");

            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString(), sqlConnection))
                {
                    
                    sqlCommand.Parameters.AddWithValue("@Id",noleggioModel.IdVeicolo);
                    //sqlCommand.Parameters.AddWithValue("@StatoNoleggio", noleggioModel.StatoNoleggio.Equals("No"));


                    if (noleggioModel.StatoNoleggio.Equals("Si"))
                    {
                        sqlCommand.Parameters.AddWithValue("@StatoNoleggio", noleggioModel.StatoNoleggio.Equals("No"));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@StatoNoleggio", noleggioModel.StatoNoleggio.Equals("Si"));
                    }
                    if (noleggioModel.IdCliente > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@IdCliente", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@IdCliente", noleggioModel.StatoNoleggio);
                    }

                    var numRigheModificate = sqlCommand.ExecuteNonQuery();
                }

            }
            return isUpdate;
        }
       
    }
}
