namespace CollegeWepPortal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("STUDENT")]
    public partial class STUDENT
    {
        public int StudentID { get; set; }

        [StringLength(50)]
        public string StudentName { get; set; }

        [StringLength(50)]
        public string Department { get; set; }

        public int? Age { get; set; }

        public int? deleted { get; set; }

      
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Role { get; set; }
    }
}
