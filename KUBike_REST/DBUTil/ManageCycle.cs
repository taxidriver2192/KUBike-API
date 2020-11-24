using lib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace KUBike_REST.DBUTil
{
    public class ManageCycle
    {
        private const string connString = @"Server=tcp:mort-db-server.database.windows.net,1433;Initial Catalog = mort - db; Persist Security Info=False;User ID = mort - admin; Password=Secret1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";

        private const string GET_ALL_SQL = "select * from Cycles";
        public IList<Cycle> HentAlle()
        {
            IList<Cycle> cycles = new List<Cycle>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(GET_ALL_SQL, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cycles.Add(ReadNextCycle(reader));
                    }
                }

            }
            return cycles;
        }
        private Cycle ReadNextCycle(SqlDataReader reader)
        {
            Cycle c = new Cycle();

            c.Cycle_id = reader.GetInt32(0);
            c.Cycle_name = reader.GetString(1);
            c.Cycle_coordinates = reader.GetString(2);
            c.Cycle_status_id = reader.GetInt32(3);
            


            return c;
        }
    }
}
