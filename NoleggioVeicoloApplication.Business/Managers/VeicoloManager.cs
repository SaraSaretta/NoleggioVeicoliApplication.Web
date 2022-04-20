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
            sb.AppendLine("\t,SAMarche.[Marca]");
            sb.AppendLine("FROM [dbo].[SAVeicoli] LEFT JOIN SATipoAlimentazione on SAVeicoli.IdAlimentazione=SATipoAlimentazione.Id");
            sb.AppendLine("\tLEFT JOIN SAMarche on SAVeicoli.IdMarca=SAMarche.Id");


            var dataSet = new DataSet();
            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString()))
                {
                    using (var sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlDataAdapter.SelectCommand = sqlCommand;
                        sqlDataAdapter.SelectCommand.Connection = sqlConnection;
                        sqlDataAdapter.Fill(dataSet);

                        var dataTable = dataSet.Tables[0];
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            var veicoloModel = new VeicoloModel();
                           
                            veicoloModel.Id = dataRow.Field<int>("Id");
                            veicoloModel.Modello = dataRow.Field<string>("Modello");
                            veicoloModel.Targa = dataRow.Field<string>("Targa");
                            veicoloModel.DataImmatricolazione = dataRow.Field<DateTime?>("DataImmatricolazione");
                            veicoloModel.Note = dataRow.Field<string>("Note");
                            veicoloModel.IdAlimentazione = dataRow.Field<int>("IdAlimentazione");
                            veicoloModel.IdMarca = dataRow.Field<int>("IdMarca");
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
            sb.AppendLine(",[Note]");
            sb.AppendLine(") VALUES (");
            sb.AppendLine("@IdMarca");
            sb.AppendLine(",@Modello");
            sb.AppendLine(",@Targa");
            sb.AppendLine(",@DataImmatricolazione");
            sb.AppendLine(",@IdAlimentazione");
            sb.AppendLine(",@Note");
            sb.AppendLine(")");

            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString(), sqlConnection))
                {
                    
                    if (veicoloModel.IdMarca>0)
                    {
                        sqlCommand.Parameters.AddWithValue("@IdMarca", veicoloModel.IdMarca);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@IdMarca", DBNull.Value);
                    }
                    if (string.IsNullOrEmpty(veicoloModel.Modello))
                    {
                        sqlCommand.Parameters.AddWithValue("@Modello", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Modello", veicoloModel.Modello);
                    }

                    if (string.IsNullOrEmpty(veicoloModel.Targa))
                    {
                        sqlCommand.Parameters.AddWithValue("@Targa", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Targa", veicoloModel.Targa);
                    }
                    if (veicoloModel.DataImmatricolazione.HasValue)
                    {
                        sqlCommand.Parameters.AddWithValue("@DataImmatricolazione", veicoloModel.DataImmatricolazione);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@DataImmatricolazione", DBNull.Value);
                    }

                    if (veicoloModel.IdAlimentazione>0)
                    {
                        sqlCommand.Parameters.AddWithValue("@IdAlimentazione", veicoloModel.IdAlimentazione);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@IdAlimentazione", DBNull.Value);
                    }
                    //if (string.IsNullOrEmpty(Convert.ToString(veicoloModel.StatoNoleggio)))
                    //{
                    //    sqlCommand.Parameters.AddWithValue("@StatoNoleggio", DBNull.Value);
                    //}
                    //else
                    //{
                    //    sqlCommand.Parameters.AddWithValue("@StatoNoleggio", veicoloModel.StatoNoleggio);
                    //}

                    if (string.IsNullOrEmpty(veicoloModel.Note))
                    {
                        sqlCommand.Parameters.AddWithValue("@Note", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Note", veicoloModel.Note);
                    }

                    var numRigheInserite = sqlCommand.ExecuteNonQuery();
                }
            }
            return isInserito;
        }

        public List<VeicoloModel> RicercaVeicolo(Models.RicercaVeicoloModel ricercaVeicoloModel)
        {
            
            var veicoloModelList = new List<VeicoloModel>();
            var sb = new StringBuilder();
            sb.AppendLine("SELECT SAVeicoli.[Id],SAMarche.[Marca],[Modello],[Targa],[DataImmatricolazione]");
            sb.AppendLine("FROM [dbo].[SAVeicoli] LEFT JOIN SAMarche on SAVeicoli.IdMarca=SAMarche.Id");
            sb.AppendLine("WHERE 1 = 1 ");

            //if (ricercaVeicoloModel.IdMarca != -1)
            //{
            //    sb.AppendLine("And IdMarca = @IdMarca");
            //}
            //if (ricercaVeicoloModel.Modello.Length>=3)
            //{
            //    sb.AppendLine("AND Modello LIKE '%" + ricercaVeicoloModel.Modello + "%' ");
            //}
            //if (ricercaVeicoloModel.DataImmatricolazione.HasValue)
            //{
            //    sb.AppendLine("And DataImmatricolazione = @DataImmatricolazione");
            //}
            //if (!string.IsNullOrEmpty(ricercaVeicoloModel.Targa))
            //{
            //    sb.AppendLine("AND Targa LIKE '%" + ricercaVeicoloModel.Targa + "%'");
            //}
            if (ricercaVeicoloModel.IdMarca != -1)
            {
                sb.AppendLine("AND IdMarca = " + ricercaVeicoloModel.IdMarca + " ");
            }
            if (ricercaVeicoloModel.Modello.Length >=3)
            {
                sb.AppendLine("AND Modello LIKE '%" + ricercaVeicoloModel.Modello + "%' ");
            }

            if (ricercaVeicoloModel.DataImmatricolazione.HasValue)
            {
                sb.AppendLine("AND DataImmatricolazione = " + ricercaVeicoloModel.DataImmatricolazione + " ");
            }

            if (!string.IsNullOrEmpty(ricercaVeicoloModel.Targa))
            {
                sb.AppendLine("AND Targa LIKE '%" + ricercaVeicoloModel.Targa + "%' ");
            }

            //if (!string.IsNullOrEmpty(ricercaVeicoloModel.StatoNoleggio))
            //{
            //    sb.AppendLine("And StatoNoleggio = @StatoNoleggio");
            //}

            var dataSet = new DataSet();
            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString()))
                {
                    //if (ricercaVeicoloModel.IdMarca!=-1)
                    //{
                    //    sqlCommand.Parameters.AddWithValue("@IdMarca", ricercaVeicoloModel.IdMarca);
                    //}
                    //if (!string.IsNullOrEmpty(ricercaVeicoloModel.Modello))
                    //{
                    //    sqlCommand.Parameters.AddWithValue("@Modello", ricercaVeicoloModel.Modello);
                    //}
                    //if (ricercaVeicoloModel.DataImmatricolazione.HasValue)
                    //{
                    //    sqlCommand.Parameters.AddWithValue("@DataImmatricolazione", ricercaVeicoloModel.DataImmatricolazione);
                    //}
                    //if (!string.IsNullOrEmpty(ricercaVeicoloModel.Targa))
                    //{
                    //    sqlCommand.Parameters.AddWithValue("@Targa", ricercaVeicoloModel.Targa);
                    //}

                    //if (!string.IsNullOrEmpty(ricercaVeicoloModel.StatoNoleggio))
                    //{
                    //    sqlCommand.Parameters.AddWithValue("@StatoNoleggio", ricercaVeicoloModel.StatoNoleggio);
                    //}
                    using (var sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlDataAdapter.SelectCommand = sqlCommand;
                        sqlDataAdapter.SelectCommand.Connection = sqlConnection;
                        sqlDataAdapter.Fill(dataSet);

                        var dataTable = dataSet.Tables[0];
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            var veicoloModel = new VeicoloModel();
                            veicoloModel.Id = dataRow.Field<int>("Id");
                            veicoloModel.Marca = dataRow.Field<string>("Marca");
                            veicoloModel.Modello = dataRow.Field<string>("Modello");
                            veicoloModel.Targa = dataRow.Field<string>("Targa");
                            veicoloModel.DataImmatricolazione = dataRow.Field<DateTime?>("DataImmatricolazione");
                            //veicoloModel.StatoNoleggio = dataRow.Field<bool>("StatoNoleggio");
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
            sb.AppendLine("\tSAVeicoli.[Id]");
            sb.AppendLine("\t,[IdMarca]");
            sb.AppendLine("\t,[Modello]");
            sb.AppendLine("\t,[Targa]");
            sb.AppendLine("\t,[DataImmatricolazione]");
            sb.AppendLine("\t,SATipoAlimentazione.[Alimentazione]");
            sb.AppendLine("\t,[IdAlimentazione]");
            sb.AppendLine("\t,SAMarche.[Marca]");
            sb.AppendLine("\t,[IdMarca]");
            sb.AppendLine("\tFROM [dbo].[SAVeicoli]");
            sb.AppendLine("\tLEFT JOIN SATipoAlimentazione on SAVeicoli.IdAlimentazione=SATipoAlimentazione.Id");
            sb.AppendLine("\tLEFT JOIN SAMarche on SAVeicoli.IdMarca=SAMarche.Id");
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
                        veicoloModel.Id = row.Field<int>("id");
                        veicoloModel.IdMarca = row.Field<int>("IdMarca");
                        veicoloModel.Modello = row.Field<string>("Modello");
                        veicoloModel.Targa = row.Field<string>("Targa");
                        veicoloModel.DataImmatricolazione = row.Field<DateTime?>("DataImmatricolazione");
                        veicoloModel.IdAlimentazione = row.Field<int>("IdAlimentazione");
                        veicoloModel.TipoAlimentazioneDesc = row.Field<string>("Alimentazione");
                       
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
                    

                    if (veicoloModel.IdMarca>0)
                    {
                        sqlCommand.Parameters.AddWithValue("@IdMarca", veicoloModel.IdMarca);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@IdMarca", DBNull.Value);
                    }
                    if (string.IsNullOrEmpty(veicoloModel.Modello))
                    {
                        sqlCommand.Parameters.AddWithValue("@Modello", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Modello", veicoloModel.Modello);
                    }
                    if (string.IsNullOrEmpty(veicoloModel.Targa))
                    {
                        sqlCommand.Parameters.AddWithValue("@Targa", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Targa", veicoloModel.Targa);
                    }
                    if (veicoloModel.DataImmatricolazione.HasValue)
                    {
                        sqlCommand.Parameters.AddWithValue("@DataImmatricolazione", veicoloModel.DataImmatricolazione);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@DataImmatricolazione", DBNull.Value);
                    }
                    if (veicoloModel.IdAlimentazione>0)
                    {
                        sqlCommand.Parameters.AddWithValue("@IdAlimentazione", veicoloModel.IdAlimentazione);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@IdAlimentazione", DBNull.Value);
                    }
                    if (string.IsNullOrEmpty(veicoloModel.Note))
                    {
                        sqlCommand.Parameters.AddWithValue("@Note", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Note", veicoloModel.Note);
                    }

                    //sqlCommand.Parameters.AddWithValue("@DataModifica", DateTime.Now);

                    var numRigheModificate = sqlCommand.ExecuteNonQuery();
                }

            }
            return isUpdate;
        }
        public List<TipoAlimentazioneModel> GetTipoAlimentazione()
        {
            var getTipoAlimentazioneModel = new List<TipoAlimentazioneModel>();
            var sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("\t[Id]");
            sb.AppendLine("\t,[Alimentazione]");
            sb.AppendLine("FROM [dbo].[SATipoAlimentazione]");

            var dataSet = new DataSet();
            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString()))
                {
                    using (var sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlDataAdapter.SelectCommand = sqlCommand;
                        sqlDataAdapter.SelectCommand.Connection = sqlConnection;
                        sqlDataAdapter.Fill(dataSet);

                        var dataTable = dataSet.Tables[0];
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            var tipoAlimentazioneModel = new TipoAlimentazioneModel();
                            //personaModel.Id = Convert.ToInt32(dataRow["Id"]);
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
            sb.AppendLine("\tSAMarche.[Id]");
            sb.AppendLine("\t,[Marca]");
            sb.AppendLine("FROM [dbo].[SAMarche]");
            sb.AppendLine("ORDER BY [Marca]");
           
            var dataSet = new DataSet();
            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString()))
                {
                    using (var sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlDataAdapter.SelectCommand = sqlCommand;
                        sqlDataAdapter.SelectCommand.Connection = sqlConnection;
                        sqlDataAdapter.Fill(dataSet);

                        var dataTable = dataSet.Tables[0];
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

        public MarcaModel GetMarca(int? id)
        {
            var marcaModel = new MarcaModel();

            var sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("\tSAVeicoli.[Id]");
            sb.AppendLine("\t,[Modello]");
            sb.AppendLine("\t,[Targa]");
            sb.AppendLine("\t,[DataImmatricolazione]");
            sb.AppendLine("\t,SAMarche.[Marca]");
            sb.AppendLine("\tFROM [dbo].[SAVeicoli]");
            sb.AppendLine("\tLEFT JOIN SAMarche on SAVeicoli.IdMarca=SAMarche.Id");
            sb.AppendLine("WHERE SAVeicoli.Id=@Id");

            //var dataSet = new DataSet();
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
                        // sqlDataAdapter.Fill(dataSet);
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
                        if (dataTable.Rows.Count == 0)
                        {
                            return null;
                        }

                        DataRow row = dataTable.Rows[0];
                        marcaModel.Id = row.Field<int>("id");
                        marcaModel.Marca = row.Field<string>("Marca");
                        
                    }
                    return marcaModel;
                }
            }
        }


    }
}

