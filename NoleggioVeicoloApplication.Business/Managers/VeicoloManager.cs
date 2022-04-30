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
    public class VeicoloManager
    {
        public VeicoloManager(string connectionString)
        {
            this.ConnectionString = connectionString;

        }
        public string ConnectionString { get; set; }

        public List<VeicoloModel> GetVeicoloList()
        {
            var veicoloModelList = new List<VeicoloModel>();
            var sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("\tSAVeicoli.[Id]");
            sb.AppendLine("\t,SAVeicoli.[Modello]");
            sb.AppendLine("\t,SAVeicoli.[Targa]");
            sb.AppendLine("\t,SAVeicoli.[DataImmatricolazione]");
            sb.AppendLine("\t,SAVeicoli.[Note]");
            sb.AppendLine("\t,SATipoAlimentazione.[Alimentazione]");
            sb.AppendLine("\t,SAVeicoli.[IdAlimentazione]");
            sb.AppendLine("\t,SAMarche.[Marca]");
            sb.AppendLine("\t,SAVeicoli.[IdMarca]");
            sb.AppendLine("FROM [dbo].[SAVeicoli] LEFT JOIN SATipoAlimentazione on SAVeicoli.IdAlimentazione=SATipoAlimentazione.Id");
            sb.AppendLine("\tLEFT JOIN SAMarche on SAVeicoli.IdMarca=SAMarche.Id");

            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString()))
                {
                    using (var sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlDataAdapter.SelectCommand = sqlCommand;
                        sqlDataAdapter.SelectCommand.Connection = sqlConnection;
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
                        if (dataTable.Rows.Count == 0)
                        {
                            return null;
                        }
                        DataRow row = dataTable.Rows[0];
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            var veicoloModel = new VeicoloModel();

                            veicoloModel.Id = dataRow.Field<int>("Id");
                            veicoloModel.IdMarca = dataRow.Field<int>("IdMarca");
                            veicoloModel.Modello = dataRow.Field<string>("Modello");
                            veicoloModel.Targa = dataRow.Field<string>("Targa");
                            veicoloModel.IdTipoAlimentazione = dataRow.Field<int>("IdAlimentazione");
                            veicoloModel.DataImmatricolazione = dataRow.Field<DateTime?>("DataImmatricolazione");
                            veicoloModel.Note = dataRow.Field<string>("Note");

                            veicoloModelList.Add(veicoloModel);
                        }
                    }
                }
            }
            return veicoloModelList;
        }
        public bool InsertVeicolo(Models.VeicoloModel veicoloModel)
        {
            bool isInserito = false;
            var sb = new StringBuilder();
            sb.AppendLine("INSERT INTO [dbo].[SAVeicoli] (");
            sb.AppendLine("[IdMarca]");
            sb.AppendLine(",[Modello]");
            sb.AppendLine(",[Targa]");
            sb.AppendLine(",[DataImmatricolazione]");
            sb.AppendLine(",[IdAlimentazione]");
            sb.AppendLine(",[StatoNoleggio]");
            sb.AppendLine(",[Note]");
            sb.AppendLine(") VALUES (");
            sb.AppendLine("@IdMarca");
            sb.AppendLine(",@Modello");
            sb.AppendLine(",@Targa");
            sb.AppendLine(",@DataImmatricolazione");
            sb.AppendLine(",@IdAlimentazione");
            sb.AppendLine(",@StatoNoleggio");
            sb.AppendLine(",@Note");
            sb.AppendLine(")");

            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString(), sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@IdMarca", veicoloModel.IdMarca);
                    sqlCommand.Parameters.AddWithValue("@Modello", veicoloModel.Modello);
                    sqlCommand.Parameters.AddWithValue("@Targa", veicoloModel.Targa);
                    sqlCommand.Parameters.AddWithValue("@DataImmatricolazione", veicoloModel.DataImmatricolazione);
                    sqlCommand.Parameters.AddWithValue("@IdAlimentazione", veicoloModel.IdTipoAlimentazione);
                    sqlCommand.Parameters.AddWithValue("@StatoNoleggio", veicoloModel.StatoNoleggio);
                    sqlCommand.Parameters.AddWithValue("@Note", veicoloModel.Note);

                    var numRigheInserite = sqlCommand.ExecuteNonQuery();
                }
            }
            return isInserito;
        }
        public List<VeicoloModel> RicercaVeicolo(Models.RicercaVeicoloModel ricercaVeicoloModel)
        {
            var veicoloModelList = new List<VeicoloModel>();
            var sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("SAVeicoli.[Id]");
            sb.AppendLine(",SAMarche.[Marca]");
            sb.AppendLine(",[Modello]");
            sb.AppendLine(",[Targa]");
            sb.AppendLine(",[IdAlimentazione]");
            sb.AppendLine(",SATipoAlimentazione.[Alimentazione]");
            sb.AppendLine(",[DataImmatricolazione]");
            sb.AppendLine(",[StatoNoleggio]");
            sb.AppendLine("FROM [dbo].[SAVeicoli] LEFT JOIN [dbo].[SAMarche] ON [dbo].[SAVeicoli].[IdMarca]= [dbo].[SAMarche].[Id]");
            sb.AppendLine("LEFT JOIN [dbo].SATipoAlimentazione ON [dbo].[SAVeicoli].[IdAlimentazione]= [dbo].[SATipoAlimentazione].[Id]");
            sb.AppendLine("WHERE 1 = 1 ");

            if (ricercaVeicoloModel.IdMarca >= 0)
            {
                sb.AppendLine("AND IdMarca=@IdMarca");
            }
            if (!string.IsNullOrEmpty(ricercaVeicoloModel.Modello))
            {
                sb.AppendLine("AND Modello LIKE  '%' +@Modello +'%' ");
            }
            if (!string.IsNullOrEmpty(ricercaVeicoloModel.Targa))
            {
                sb.AppendLine("AND Targa LIKE '%' +@Targa +'%' ");
            }
            if (ricercaVeicoloModel.IdTipoAlimentazione >= 0)
            {
                sb.AppendLine("AND IdAlimentazione=@IdAlimentazione");
            }
            if (!string.IsNullOrEmpty(ricercaVeicoloModel.StatoNoleggio) && ((ricercaVeicoloModel.StatoNoleggio.Equals("Si") || (ricercaVeicoloModel.StatoNoleggio.Equals("No")))))
            {
                sb.AppendLine("And StatoNoleggio = @StatoNoleggio");
            }
            if (ricercaVeicoloModel.DataImmatricolazioneInizio.HasValue)
            {
                sb.AppendLine("AND DataImmatricolazione >=@DataImmatricolazioneInizio");
            }
            if (ricercaVeicoloModel.DataImmatricolazioneFine.HasValue)
            {
                sb.AppendLine("AND DataImmatricolazione <=@DataImmatricolazioneFine");
            }
            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString()))
                {
                    if (ricercaVeicoloModel.IdMarca != -1)
                    {
                        sqlCommand.Parameters.AddWithValue("@IdMarca", ricercaVeicoloModel.IdMarca);
                    }
                    if (!string.IsNullOrEmpty(ricercaVeicoloModel.Modello))
                    {
                        sqlCommand.Parameters.AddWithValue("@Modello", ricercaVeicoloModel.Modello);
                    }
                    if (ricercaVeicoloModel.DataImmatricolazioneInizio.HasValue)
                    {
                        sqlCommand.Parameters.AddWithValue("@DataImmatricolazioneInizio", ricercaVeicoloModel.DataImmatricolazioneInizio);
                    }
                    if (ricercaVeicoloModel.DataImmatricolazioneFine.HasValue)
                    {
                        sqlCommand.Parameters.AddWithValue("@DataImmatricolazioneFine", ricercaVeicoloModel.DataImmatricolazioneFine);
                    }
                    if (ricercaVeicoloModel.IdTipoAlimentazione.HasValue)
                    {
                        sqlCommand.Parameters.AddWithValue("@IdAlimentazione", ricercaVeicoloModel.IdTipoAlimentazione);
                    }
                    if (!string.IsNullOrEmpty(ricercaVeicoloModel.Targa))
                    {
                        sqlCommand.Parameters.AddWithValue("@Targa", ricercaVeicoloModel.Targa);
                    }
                    if (!string.IsNullOrEmpty(ricercaVeicoloModel.StatoNoleggio) && ((ricercaVeicoloModel.StatoNoleggio.Equals("Si") || (ricercaVeicoloModel.StatoNoleggio.Equals("No")))))
                    {
                        sqlCommand.Parameters.AddWithValue("@StatoNoleggio", ricercaVeicoloModel.StatoNoleggio);
                    }
                    using (var sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlDataAdapter.SelectCommand = sqlCommand;
                        sqlDataAdapter.SelectCommand.Connection = sqlConnection;
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
                        if (dataTable.Rows.Count == 0)
                        {
                            return null;
                        }
                        DataRow row = dataTable.Rows[0];
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            var veicoloModel = new VeicoloModel();
                            veicoloModel.Id = dataRow.Field<int>("Id");
                            veicoloModel.Marca = dataRow.Field<string>("Marca");
                            veicoloModel.Modello = dataRow.Field<string>("Modello");
                            veicoloModel.Targa = dataRow.Field<string>("Targa");
                            veicoloModel.IdTipoAlimentazione = dataRow.Field<int>("IdAlimentazione");
                            veicoloModel.TipoAlimentazione = dataRow.Field<string>("Alimentazione");
                            veicoloModel.DataImmatricolazione = dataRow.Field<DateTime?>("DataImmatricolazione");
                            veicoloModel.StatoNoleggio = dataRow.Field<string>("StatoNoleggio");
                            veicoloModelList.Add(veicoloModel);
                        }
                    }
                }
            }
            return veicoloModelList;
        }
        public VeicoloModel GetVeicolo(int? id)
        {
            var veicoloModel = new VeicoloModel();

            var sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("SAVeicoli.[Id]");
            sb.AppendLine(",[IdMarca]");
            sb.AppendLine(",SAMarche.[Marca]");
            sb.AppendLine(",[Modello]");
            sb.AppendLine(",[Targa]");
            sb.AppendLine(",[DataImmatricolazione]");
            sb.AppendLine(",[IdAlimentazione]");
            sb.AppendLine(",SATipoAlimentazione.[Alimentazione]");
            sb.AppendLine(",[StatoNoleggio]");
            sb.AppendLine(",[Note]");
            sb.AppendLine("FROM [dbo].[SAVeicoli]");
            sb.AppendLine("LEFT JOIN SATipoAlimentazione on SAVeicoli.IdAlimentazione=SATipoAlimentazione.Id");
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
                        veicoloModel.Id = row.Field<int>("Id");
                        veicoloModel.IdMarca = row.Field<int>("IdMarca");
                        veicoloModel.Marca = row.Field<string>("Marca");
                        veicoloModel.Modello = row.Field<string>("Modello");
                        veicoloModel.Targa = row.Field<string>("Targa");
                        veicoloModel.DataImmatricolazione = row.Field<DateTime?>("DataImmatricolazione");
                        veicoloModel.IdTipoAlimentazione = row.Field<int>("IdAlimentazione");
                        veicoloModel.TipoAlimentazione = row.Field<string>("Alimentazione");
                        veicoloModel.StatoNoleggio = row.Field<string>("StatoNoleggio");
                        veicoloModel.Note = row.Field<string>("Note");

                    }
                    return veicoloModel;
                }
            }
        }
        public bool UpdateVeicolo(VeicoloModel veicoloModel)
        {
            bool isUpdate = false;
            var sb = new StringBuilder();
            sb.AppendLine("UPDATE [dbo].[SAVeicoli] ");
            sb.AppendLine("SET");
            sb.AppendLine("[IdMarca]=@IdMarca");
            sb.AppendLine(",[Modello]=@Modello");
            sb.AppendLine(",[Targa]=@Targa");
            sb.AppendLine(",[DataImmatricolazione]=@DataImmatricolazione");
            sb.AppendLine(",[IdAlimentazione]=@IdAlimentazione");
            sb.AppendLine(",[Note]=@Note");
            sb.AppendLine("WHERE Id=@Id");

            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString(), sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@Id", veicoloModel.Id);

                    if (veicoloModel.IdMarca > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@IdMarca", veicoloModel.IdMarca);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@IdMarca", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(veicoloModel.Modello))
                    {
                        sqlCommand.Parameters.AddWithValue("@Modello", veicoloModel.Modello);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Modello", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(veicoloModel.Targa))
                    {
                        sqlCommand.Parameters.AddWithValue("@Targa", veicoloModel.Targa);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Targa", DBNull.Value);
                    }
                    if (veicoloModel.DataImmatricolazione.HasValue)
                    {
                        sqlCommand.Parameters.AddWithValue("@DataImmatricolazione", veicoloModel.DataImmatricolazione);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@DataImmatricolazione", DBNull.Value);
                    }
                    if (veicoloModel.IdTipoAlimentazione > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@IdAlimentazione", veicoloModel.IdTipoAlimentazione);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@IdAlimentazione", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(veicoloModel.Note))
                    {
                        sqlCommand.Parameters.AddWithValue("@Note", veicoloModel.Note);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Note", DBNull.Value);
                    }
                    var numRigheModificate = sqlCommand.ExecuteNonQuery();
                }
            }
            return isUpdate;
        }
        public bool DeleteVeicolo(VeicoloModel veicoloModel)
        {
            bool isDelete = false;
            var sb = new StringBuilder();
            sb.AppendLine("Delete");
            sb.AppendLine("FROM [dbo].[SAVeicoli]");
            sb.AppendLine("WHERE Id=@Id");

            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString(), sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@Id", veicoloModel.Id);
                    var numRigheModificate = sqlCommand.ExecuteNonQuery();
                }
            }
            return isDelete;
        }
        public List<TipoAlimentazioneModel> GetTipoAlimentazione()
        {
            var getTipoAlimentazioneModel = new List<TipoAlimentazioneModel>();
            var sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("[Id]");
            sb.AppendLine(",[Alimentazione]");
            sb.AppendLine("FROM [dbo].[SATipoAlimentazione]");

            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString()))
                {
                    using (var sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlDataAdapter.SelectCommand = sqlCommand;
                        sqlDataAdapter.SelectCommand.Connection = sqlConnection;
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
                        if (dataTable.Rows.Count == 0)
                        {
                            return null;
                        }
                        DataRow row = dataTable.Rows[0];
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            var tipoAlimentazioneModel = new TipoAlimentazioneModel();
                            tipoAlimentazioneModel.Id = dataRow.Field<int>("Id");
                            tipoAlimentazioneModel.Alimentazione = dataRow.Field<string>("Alimentazione");

                            getTipoAlimentazioneModel.Add(tipoAlimentazioneModel);
                        }
                    }
                }
            }
            return getTipoAlimentazioneModel;
        }
        public List<MarcaModel> GetMarcaList()
        {
            var getMarcaList = new List<MarcaModel>();
            var sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("SAMarche.[Id]");
            sb.AppendLine(",[Marca]");
            sb.AppendLine("FROM [dbo].[SAMarche]");
            sb.AppendLine("ORDER BY [Marca]");

            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString()))
                {
                    using (var sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlDataAdapter.SelectCommand = sqlCommand;
                        sqlDataAdapter.SelectCommand.Connection = sqlConnection;
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
                        if (dataTable.Rows.Count == 0)
                        {
                            return null;
                        }
                        DataRow row = dataTable.Rows[0];
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            var marcaModel = new MarcaModel();
                            marcaModel.Id = dataRow.Field<int>("Id");
                            marcaModel.Marca = dataRow.Field<string>("Marca");

                            getMarcaList.Add(marcaModel);
                        }
                    }
                }
            }
            return getMarcaList;
        }
    }
}

