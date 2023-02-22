using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _07_EF_example.Entities
{
    class Flight
    {
        public int Number { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivelTime { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivelCity { get; set; }
        public int? Rating { get; set; }
        public int AirplaneId { get; set; }
        //Navigation properties
        public Airplane Airplane { get; set; }
        public ICollection<Client> Clients { get; set; }


    }
}
