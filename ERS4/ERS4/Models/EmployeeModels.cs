using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERS4.Models
{
    public class EmployeeModels
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(60, MinimumLength = 1)]
        public string FIRSTNAME { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(60, MinimumLength = 1)]
        public string LASTNAME { get; set; }

        [Required]
        [Display(Name = "Username")]
        [StringLength(60, MinimumLength = 1)]
        public string USERNAME { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime STARTDATE { get; set; }

        [Required]
        [Display(Name = "Department")]
        public string DEPARTMENT { get; set; }

        [Required]
        [Display(Name = "Sales")]
        public decimal SALES { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(5)]
        [Display(Name = "Rating")]
        public string RATING { get; set; }
    }
    public class EmployeeDBContext : DbContext
    {
        public DbSet<EmployeeModels> Employee { get; set; }
    }
}