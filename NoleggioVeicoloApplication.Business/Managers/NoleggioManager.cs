using System;
using System.Collections.Generic;
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

        public bool InsertNoleggio(Models.NoleggioModel noleggioModel)
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
                    if (string.IsNullOrEmpty(noleggioModel.NomeCliente))
                    {
                        sqlCommand.Parameters.AddWithValue("@NomeCliente", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@NomeCliente", noleggioModel.NomeCliente);
                    }

                    var numRigheInserite = sqlCommand.ExecuteNonQuery();
                }
            }
            return isInserito;
        }
        //public bool UpdateStatoNoleggio(Models.NoleggioModel noleggioModel)
        //{
        //    bool isUpdate = false;
        //    var sb = new StringBuilder();
        //    sb.AppendLine("UPDATE [dbo].[SAVeicoli] ");
        //    sb.AppendLine("SET");
        //    sb.AppendLine("[StatoNoleggio]=@StatoNoleggio");
        //    sb.AppendLine(",[Modello]=@Modello");
        //    sb.AppendLine(",[Targa]=@Targa");
        //    sb.AppendLine(",[DataImmatricolazione]=@DataImmatricolazione");
        //    sb.AppendLine(",[IdAlimentazione]=@IdAlimentazione");
        //    sb.AppendLine(",[Note]=@Note");
        //    sb.AppendLine("WHERE Id=@Id");

        //    using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
        //    {
        //        sqlConnection.Open();
        //        using (SqlCommand sqlCommand = new SqlCommand(sb.ToString(), sqlConnection))
        //        {
        //            sqlCommand.Parameters.AddWithValue("@Id", noleggioModel.Id);

        //            if (noleggioModel.IdMarca > 0)
        //            {
        //                sqlCommand.Parameters.AddWithValue("@IdMarca", veicoloModel.IdMarca);
        //            }
        //            else
        //            {
        //                sqlCommand.Parameters.AddWithValue("@IdMarca", DBNull.Value);
        //            }
        //            if (string.IsNullOrEmpty(veicoloModel.Modello))
        //            {
        //                sqlCommand.Parameters.AddWithValue("@Modello", DBNull.Value);
        //            }
        //            else
        //            {
        //                sqlCommand.Parameters.AddWithValue("@Modello", veicoloModel.Modello);
        //            }
        //            if (string.IsNullOrEmpty(veicoloModel.Targa))
        //            {
        //                sqlCommand.Parameters.AddWithValue("@Targa", DBNull.Value);
        //            }
        //            else
        //            {
        //                sqlCommand.Parameters.AddWithValue("@Targa", veicoloModel.Targa);
        //            }
        //            if (veicoloModel.DataImmatricolazione.HasValue)
        //            {
        //                sqlCommand.Parameters.AddWithValue("@DataImmatricolazione", veicoloModel.DataImmatricolazione);
        //            }
        //            else
        //            {
        //                sqlCommand.Parameters.AddWithValue("@DataImmatricolazione", DBNull.Value);
        //            }
        //            if (veicoloModel.IdTipoAlimentazione > 0)
        //            {
        //                sqlCommand.Parameters.AddWithValue("@IdAlimentazione", veicoloModel.IdTipoAlimentazione);
        //            }
        //            else
        //            {
        //                sqlCommand.Parameters.AddWithValue("@IdAlimentazione", DBNull.Value);
        //            }
        //            if (string.IsNullOrEmpty(veicoloModel.Note))
        //            {
        //                sqlCommand.Parameters.AddWithValue("@Note", DBNull.Value);
        //            }
        //            else
        //            {
        //                sqlCommand.Parameters.AddWithValue("@Note", veicoloModel.Note);
        //            }
        //            var numRigheModificate = sqlCommand.ExecuteNonQuery();
        //        }

        //    }
        //    return isUpdate;
        //}
    }
}
