﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Controllers
{
    public class Student
    {
        /// <summary>
        /// Student Details
        /// </summary> 

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [StringLength(25)]
        public string LastName { get; set; }

        [Required]
        public string Dob { get; set; }

        [StringLength(2000)]
        public string Address { get; set; }

        [Required]
        [Range(1000000000, 9999999999)]
        public long PhoneNumber { get; set; }
        public string Course { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public string EnrollmentDate { get; set; }
    }
}
