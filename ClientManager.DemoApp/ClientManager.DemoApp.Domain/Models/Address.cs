using ClientManager.DemoApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientManager.DemoApp.Domain.Models
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string AddressName { get; set; }
        [Required]
        public AddressType AddressType { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public string GetInfo()
        {
            return $"This address is of type {AddressType} and it is located {AddressName}";
        }
    }
}
