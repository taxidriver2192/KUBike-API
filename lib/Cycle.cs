using System;
using System.Collections.Generic;
using System.Text;

namespace lib
{
    public class Cycle
    {
        public Cycle()
        {
        }

        public Cycle(int cycle_id, string cycle_name, string cycle_coordinates, int cycle_status_id)
        {
            Cycle_id = cycle_id;
            Cycle_name = cycle_name;
            Cycle_coordinates = cycle_coordinates;
            Cycle_status_id = cycle_status_id;
        }

        public int Cycle_id { get; set; }
        public string Cycle_name { get; set; }
        public string Cycle_coordinates { get; set; }
        public int Cycle_status_id { get; set; }
    }
}
