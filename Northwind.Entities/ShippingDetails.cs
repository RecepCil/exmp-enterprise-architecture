using System.ComponentModel.DataAnnotations;

namespace Northwind.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage ="İsim Girilmesi zorunludur")]
        //[RegularExpression("a-z A-Z")] //Sadece harf //Validation
        [Display(Name="Ad Soyad")]
        public string Name { get; set; }

        [Required()]
        [MinLength(10)]
        [MaxLength(50)]
        public string Address1 { get; set; }

        [MaxLength(50)]
        public string Address2 { get; set; }

        [MaxLength(50)]
        
        public string Address3 { get; set; }

        [Required()]
        public string City { get; set; }
        public string Country { get; set; }
        public bool IsGift { get; set; }
    }
}