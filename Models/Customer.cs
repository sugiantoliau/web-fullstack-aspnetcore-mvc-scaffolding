using System;
using System.ComponentModel.DataAnnotations;



namespace web_fullstack_aspnetcore_mvc.Models

{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Join Date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Join Date")]
        public DateTime JoinDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Enroll Name is required")]
        [Display(Name = "Enroll Name")]
        public string EnrollName { get; set; } = string.Empty;

       
        [Required(ErrorMessage = "Mobile Number is required")]
        [Phone(ErrorMessage = "Invalid Mobile Number")]
        [Display(Name = "Mobile No")]
        public string MobileNo { get; set; } = string.Empty;


        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = string.Empty;


        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; } = string.Empty;

    }
}

