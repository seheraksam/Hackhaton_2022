using Hackathon.Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace Hackathon.WebClient.Models
{
    public class Transaction
    {
        public string RecipientTCKN { get; set; }
        [Required]
        [Range(0,int.MaxValue)]
        public int Amount { get; set; }
    }
}
