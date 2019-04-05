using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class DataEngine
    {
        public string ObjectCode { get; set; }

        public IEnumerable<PriceModel> DataConnectWithOutParams(string dataCennika)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BI_Arch"].ConnectionString;
            List<PriceModel> modelList = new List<PriceModel>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "Select top 10 [From booking date], [Object Code], [Room code], [From date], [Departure], [Rola_osoby], [okres_7_14], [Service], "
                    + "CASE "
                        + "WHEN ([nr_progu] = 1) THEN [Cena1] "
                        + "WHEN ([nr_progu] = 2) THEN [Cena2] "
                        + "WHEN ([nr_progu] = 3) THEN [Cena3] "
                        + "WHEN ([nr_progu] = 4) THEN [Cena4] "
                        + "WHEN ([nr_progu] = 5) THEN [Cena5] "
                        + "WHEN ([nr_progu] = 6) THEN [Cena6] "
                        + "WHEN ([nr_progu] = 7) THEN [Cena7] "
                        + "WHEN ([nr_progu] = 8) THEN [Cena8] "
                        + "WHEN ([nr_progu] = 9) THEN [Cena9] "
                        + "WHEN ([nr_progu] = 10) THEN [Cena10] "
                        + "WHEN ([nr_progu] = 11) THEN [Cena11] "
                        + "WHEN ([nr_progu] = 12) THEN [Cena12] "
                        + "WHEN ([nr_progu] = 13) THEN [Cena13] "
                        + "WHEN ([nr_progu] = 14) THEN [Cena14] "
                        + "END AS [Cena], "

                    + "CASE "
                        + "WHEN ([nr_progu] = 1) THEN [typ_cennika]+[Kat1] "
                        + "WHEN ([nr_progu] = 2) THEN [typ_cennika]+[Kat2] "
                        + "WHEN ([nr_progu] = 3) THEN [typ_cennika]+[Kat3] "
                        + "WHEN ([nr_progu] = 4) THEN [typ_cennika]+[Kat4] "
                        + "WHEN ([nr_progu] = 5) THEN [typ_cennika]+[Kat5] "
                        + "WHEN ([nr_progu] = 6) THEN [typ_cennika]+[Kat6] "
                        + "WHEN ([nr_progu] = 7) THEN [typ_cennika]+[Kat7] "
                        + "WHEN ([nr_progu] = 8) THEN [typ_cennika]+[Kat8] "
                        + "WHEN ([nr_progu] = 9) THEN [typ_cennika]+[Kat9] "
                        + "WHEN ([nr_progu] = 10) THEN [typ_cennika]+[Kat10] "
                        + "WHEN ([nr_progu] = 11) THEN [typ_cennika]+[Kat11] "
                        + "WHEN ([nr_progu] = 12) THEN [typ_cennika]+[Kat12] "
                        + "WHEN ([nr_progu] = 13) THEN [typ_cennika]+[Kat13] "
                        + "WHEN ([nr_progu] = 14) THEN [typ_cennika]+[Kat14] "
                        + "END AS [Kat] "

                    + "from " + dataCennika;

                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    PriceModel priceModel = new PriceModel();
                    priceModel.FromBookingDate = dataReader.GetDateTime(0);
                    priceModel.ObjectCode = dataReader.GetString(1);
                    priceModel.RoomCode = dataReader.GetString(2);
                    priceModel.FromDate = dataReader.GetDateTime(3);
                    priceModel.Departure = dataReader.GetString(4);
                    priceModel.RolaOsoby = dataReader.GetString(5);
                    priceModel.okres_7_14 = dataReader.GetString(6);
                    priceModel.Service = dataReader.GetString(7);
                    priceModel.Cena = dataReader.GetInt32(8);
                    priceModel.Kat = dataReader.GetString(9);

                    modelList.Add(priceModel);
                }

                return modelList;

            }
        }


        public IEnumerable<PriceModel> DataConnectWithParams(string dataCennika, string searchKodHotel, string searchRolaOsoby, DateTime? searchDataCennika, DateTime? searchDataPobytu, string searchAirport, string searchKodPokoju, string searchOkres, string searchWyzywienie)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BI_Arch"].ConnectionString;
            
            List<PriceModel> modelList = new List<PriceModel>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "Select top 10 [From booking date], [Object Code], [Room code], [From date], [Departure], [Rola_osoby], [okres_7_14], [Service], "
                    + "CASE "
                        + "WHEN ([nr_progu] = 1) THEN [Cena1] "
                        + "WHEN ([nr_progu] = 2) THEN [Cena2] "
                        + "WHEN ([nr_progu] = 3) THEN [Cena3] "
                        + "WHEN ([nr_progu] = 4) THEN [Cena4] "
                        + "WHEN ([nr_progu] = 5) THEN [Cena5] "
                        + "WHEN ([nr_progu] = 6) THEN [Cena6] "
                        + "WHEN ([nr_progu] = 7) THEN [Cena7] "
                        + "WHEN ([nr_progu] = 8) THEN [Cena8] "
                        + "WHEN ([nr_progu] = 9) THEN [Cena9] "
                        + "WHEN ([nr_progu] = 10) THEN [Cena10] "
                        + "WHEN ([nr_progu] = 11) THEN [Cena11] "
                        + "WHEN ([nr_progu] = 12) THEN [Cena12] "
                        + "WHEN ([nr_progu] = 13) THEN [Cena13] "
                        + "WHEN ([nr_progu] = 14) THEN [Cena14] "
                        + "END AS [Cena], "

                    + "CASE "
                        + "WHEN ([nr_progu] = 1) THEN [typ_cennika]+[Kat1] "
                        + "WHEN ([nr_progu] = 2) THEN [typ_cennika]+[Kat2] "
                        + "WHEN ([nr_progu] = 3) THEN [typ_cennika]+[Kat3] "
                        + "WHEN ([nr_progu] = 4) THEN [typ_cennika]+[Kat4] "
                        + "WHEN ([nr_progu] = 5) THEN [typ_cennika]+[Kat5] "
                        + "WHEN ([nr_progu] = 6) THEN [typ_cennika]+[Kat6] "
                        + "WHEN ([nr_progu] = 7) THEN [typ_cennika]+[Kat7] "
                        + "WHEN ([nr_progu] = 8) THEN [typ_cennika]+[Kat8] "
                        + "WHEN ([nr_progu] = 9) THEN [typ_cennika]+[Kat9] "
                        + "WHEN ([nr_progu] = 10) THEN [typ_cennika]+[Kat10] "
                        + "WHEN ([nr_progu] = 11) THEN [typ_cennika]+[Kat11] "
                        + "WHEN ([nr_progu] = 12) THEN [typ_cennika]+[Kat12] "
                        + "WHEN ([nr_progu] = 13) THEN [typ_cennika]+[Kat13] "
                        + "WHEN ([nr_progu] = 14) THEN [typ_cennika]+[Kat14] "
                        + "END AS [Kat] "

                    + "from " + dataCennika + " where [Object Code] = @searchKodHotel"
                    + ((searchRolaOsoby != "") ? " and [Rola_osoby] = @searchRolaOsoby" : " ")
                    + (!(searchDataCennika.Equals("") || searchDataCennika == null) ? " and [From booking date] = @searchDataCennika" : " ")
                    + (!(searchDataPobytu.Equals("") || searchDataPobytu == null) ? " and [From date] = @searchDataPobytu" : " ")
                    + ((searchAirport != "") ? " and [Departure] = @searchAirport" : " ")
                    + ((searchKodPokoju != "") ? " and [Room code] = @searchKodPokoju" : " ")
                    + ((searchOkres != "") ? " and [okres_7_14] = @searchOkres" : " ")
                    + ((searchWyzywienie != "") ? " and [Service] = @searchWyzywienie" : " ") + " ";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@searchKodHotel", searchKodHotel);
                command.Parameters.AddWithValue("@searchRolaOsoby", searchRolaOsoby);
                if (!(searchDataCennika.Equals("") || searchDataCennika == null)) {command.Parameters.AddWithValue("@searchDataCennika", searchDataCennika); }
                if (!(searchDataPobytu.Equals("") || searchDataPobytu == null)) { command.Parameters.AddWithValue("@searchDataPobytu", searchDataPobytu); }
                command.Parameters.AddWithValue("@searchAirport", searchAirport);
                command.Parameters.AddWithValue("@searchKodPokoju", searchKodPokoju);
                command.Parameters.AddWithValue("@searchOkres", searchOkres);
                command.Parameters.AddWithValue("@searchWyzywienie", searchWyzywienie);

                conn.Open();

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    PriceModel priceModel = new PriceModel();
                    priceModel.FromBookingDate = dataReader.GetDateTime(0);
                    priceModel.ObjectCode = dataReader.GetString(1);
                    priceModel.RoomCode = dataReader.GetString(2);
                    priceModel.FromDate = dataReader.GetDateTime(3);
                    priceModel.Departure = dataReader.GetString(4);
                    priceModel.RolaOsoby = dataReader.GetString(5);
                    priceModel.okres_7_14 = dataReader.GetString(6);
                    priceModel.Service = dataReader.GetString(7);
                    priceModel.Cena = dataReader.GetInt32(8);
                    priceModel.Kat = dataReader.GetString(9);

                    modelList.Add(priceModel);
                }

                return modelList;

            }

        }
    }
}
