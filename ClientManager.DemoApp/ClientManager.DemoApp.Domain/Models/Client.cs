using ClientManager.DemoApp.Domain.Enums;
using ClientManager.DemoApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientManager.DemoApp.Domain.Models
{
    public class Client : IClient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        public DateTime EntryDate { get; set; }
        [Required]
        public ClientType ClientType { get; set; }
        public ICollection<Address> Addresses { get; set; }

        public string GetInfo()
        {
            return $"Hello there {FirstName} {LastName}";
        }
    }
}
