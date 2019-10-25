using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KPITDemoTest.Models
{    
    [MetadataType(typeof(Employee_metadata))]
    public partial class Employee
    {
        public class Employee_metadata
        {
            public int Employee_ID { get; set; }

            [Required(ErrorMessage = "Please enter Name")]
            [Display(Name = "Employee Name")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Please enter Age")]
            [Display(Name = "Age")]
            public int Age { get; set; }

            [Required(ErrorMessage = "Please select Maritial status")]
            [Display(Name = "Marital Status")]
            public int Marital_Status { get; set; }            
        }
    }
}