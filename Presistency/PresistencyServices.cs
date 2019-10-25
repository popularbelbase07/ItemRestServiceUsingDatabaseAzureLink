using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ItemLibraryProject;

namespace ItemRestServiceUsingDatabaseAzure.Presistency
{
    public class PresistencyServices
    {
        private const string Get_ALL = "select * from Items";

        private const string ConnectionString =
            @"Server=tcp:jaefserver.database.windows.net,1433;Initial Catalog=HotelDataBaseF2018;Persist Security Info=False;User ID=jaef;Password=JAM2003eft
                                                ;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        //Get all data from database
        public IEnumerable<Item> Get()
        {
            List<Item> ItemList = new List<Item>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = Get_ALL;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                Item item = new Item();
                                item.Id = reader.GetInt32(0);
                                item.Name = reader.GetString(1);
                                item.Quality = reader.GetString(2);
                                item.Quantity = reader.GetDouble(3);
                                ItemList.Add(item);
                            }

                        }
                    }
                }
            }

            return ItemList;
        }
        //Search by id
        public Item Get(int id)
        {
            Item item = new Item();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Select * from Items Where Id = @Param";
                        cmd.Parameters.AddWithValue("@Param", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {

                                item.Id = reader.GetInt32(0);
                                item.Name = reader.GetString(1);
                                item.Quality = reader.GetString(2);
                                item.Quantity = reader.GetDouble(3);

                            }

                        }
                    }
                }
            }

            return item;
        }

        //Update the table of database content


        //Insert the data in database


        //Delete the data from database
       
        }
}


