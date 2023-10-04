using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    [MetadataType(typeof(CustomerMetadata))]
    public partial class Customer
    {
        public class CustomerMetadata
        {
            public string CustomerID { get; set; }
            [Required(ErrorMessage = "required.")]
            [Display(Name = "公司名稱")]
            public string CompanyName { get; set; }
        }
    }
}