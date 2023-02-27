using data_access_entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace _07_EF_example.Entities
{
    public class Client
    {
        /// <summary>
        /// public int Id { get; set; }
        /// </summary>
        public int CredentialsId { get; set; }//primary key and foreign key
        public string Name { get; set; }  
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }
        //Navigation properties
        public ICollection<Flight> Flights { get; set; }

        public Credentials Credentials { get; set; }
    }
}
