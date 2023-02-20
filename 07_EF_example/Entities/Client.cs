using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _07_EF_example.Entities
{
    [Table("Passengers")]
    class Client
    {
        //Primary key naming : Id/id/ID/ EntityName + Id
        public int Id { get; set; }
        [Required, MaxLength(100)]//not null nvarchar(100)
        [Column("FirstName")]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }
        //Navigation properties
        public ICollection<Flight> Flights { get; set; }
    }
}
