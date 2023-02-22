using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _07_EF_example.Entities
{
    class Airplane
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int MaxPassangers { get; set; }
        //Navigation properties
        public ICollection<Flight> Flights { get; set; }

    }
}
