using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using EFDbFirstApproachExample.CustomValidations;

namespace EFDbFirstApproachExample.Models
{
    [Table("Products", Schema = "dbo")]
    public class Product
    {
        [Key]
        [Display(Name = "Product ID")]
        public long ProductID { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product Name can't be blank")]
        [RegularExpression(@"^[A-Za-z ]*$", ErrorMessage = "Alphabet Characters only")]
        [MaxLength(20, ErrorMessage = "Product name can be maximum 20 characters long")]
        [MinLength(2, ErrorMessage = "Product name should contain at least 2 characters")]
        public string ProductName { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price can't be blank")]
        [Range(0, 1000, ErrorMessage = "Price should be in between 0 to 1000")]
        [DivisibleBy10(ErrorMessage = "Price should in multiples of 10")]
        public Nullable<decimal> Price { get; set; }

        [Column("DateOfPurchase", TypeName = "datetime")]
        [Display(Name = "Date Of Purchase")]
        public Nullable<System.DateTime> DOP { get; set; }

        [Display(Name = "Availability Status")]
        [Required(ErrorMessage = "You must select an Status")]
        public string AvailabilityStatus { get; set; }

        [Display(Name = "Category ID")]
        [Required(ErrorMessage = "You must select a Category")]
        public Nullable<long> CategoryID { get; set; }

        [Display(Name = "Brand ID")]
        [Required(ErrorMessage = "You must select a brand")]
        public Nullable<long> BrandID { get; set; }

        [Display(Name = "Active")]
        public Nullable<bool> Active { get; set; }

        [Display(Name = "Photo")]
        public string Photo { get; set; }

        public Nullable<decimal> Quantity { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}