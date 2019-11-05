using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Controllers
{
    public class Course
    {
        /// <summary>
        /// Course Details
        /// </summary>
        public string Id { get; set; }
        
        [Required]
        public string Name{ get; set; }
        public int Duration { get; set; }
        public int Year { get; set; }
    }

}
