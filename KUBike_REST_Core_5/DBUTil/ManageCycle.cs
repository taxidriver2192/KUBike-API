using System.Collections.Generic;
using System.Data.SqlClient;
using lib;

namespace KUBike_REST_Core_5.DBUTil
{
    public class ManageCycle
    {
        private const string connString =
            @"Server=tcp:mort-db-server.database.windows.net;Initial Catalog=mort-db;User ID=mort-admin;Password=Secret1!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private const string GET_ALL_SQL = "select * from Cycles";

        public IList<Cycle> HentAlle()
        {
            IList<Cycle> cycles = new List<Cycle>();

            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(GET_ALL_SQL, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read()) cycles.Add(ReadNextCycle(reader));
                }
            }

            return cycles;
        }

        private Cycle ReadNextCycle(SqlDataReader reader)
        {
            var c = new Cycle();

            c.Cycle_id = reader.GetInt32(0);
            c.Cycle_name = reader.GetString(1);
            c.Cycle_coordinates = reader.GetString(2);
            c.Cycle_status_id = reader.GetInt32(3);


            return c;
        }
    }
}