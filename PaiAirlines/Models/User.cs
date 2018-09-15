using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaiAirlines.Models
{
    public class User
    {
        #region Properties
        public int ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Max 50 characters", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Max 50 characters", MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Max 50 characters", MinimumLength = 2)]
        public int CntryID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Max 50 characters", MinimumLength = 2)]
        public int CtyID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Max 50 characters", MinimumLength = 2)]
        public string Street { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Max 50 characters", MinimumLength = 2)]
        [Phone]
        public string Phone { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

        [Required]
        public bool IsMatmid { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        #endregion

    }
}
