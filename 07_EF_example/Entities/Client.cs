using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _07_EF_example.Entities
{
    class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }  
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }
        //Navigation properties
        public ICollection<Flight> Flights { get; set; }
    }
}
