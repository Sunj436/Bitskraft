//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bitskraft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class EmployeeRecord
    {
        public int id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9._%+-]+@gmail.com$", ErrorMessage = "Please enter abc@gamil.com")]
        public string Email { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string Qualification { get; set; }
    }
}
