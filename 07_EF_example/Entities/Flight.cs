using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _07_EF_example.Entities
{
    class Flight
    {
        [Key]//set primary key
        public int Number { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivelTime { get; set; }
        [Required, MaxLength(100)]
        public string DepartureCity { get; set; }
        [Required, MaxLength(100)]
        public string ArrivelCity { get; set; }
        //Relationship type : one to many
        //Foreighn key : RelatedEntityName + RelatedEntityPrimaryKeyName
        public int? Rating { get; set; }
        public int AirplaneId { get; set; }
        //Navigation properties
        public Airplane Airplane { get; set; }
        public ICollection<Client> Clients { get; set; }

    }
}
