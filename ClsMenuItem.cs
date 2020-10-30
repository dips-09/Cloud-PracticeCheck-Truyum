using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TruYum_WebAPI
{
    public class ClsMenuItem
    {
        [Key]
        public int ItemId { get; set; }
        [Required(ErrorMessage ="Item Name is required")]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Display(Name ="Price")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Active state is required")]
        [Display(Name = "Active Status{Y/N}")]
        public bool Active { get; set; }
        public DateTime Date_of_Launch { get; set; }
        [Required(ErrorMessage = "Category is required")]
        [Display(Name = "Item Category")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Delivery status is required")]
        [Display(Name = "Free Delivery")]
        public string FreeDelivery { get; set; }
    }
}
