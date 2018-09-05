using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Entities
{
    public class Account
    {
        public int AccountID { get; set; }

        [Required]      //Validation'larda hata döndürmesini sağlar.
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Pass { get; set; }

        public string CustomerID { get; set; }

        //[Required]
        //public string CustomerID { get; set; }

        //[ForeignKey("CustomerID")]

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }
    }
}