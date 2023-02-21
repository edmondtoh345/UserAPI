using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserAPI.Models
{
    // Ignore this model (as of 21/2)
    public class CreditCard
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Email { get; set; }
        public string CreditCardName { get; set; }
        public string CreditCardNumber { get; set; }
        public DateTime CreditCardExpiryDate { get; set; }
    }
}
