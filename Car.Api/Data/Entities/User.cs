using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Car.Api.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Display(Name = "Document")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(11, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [RegularExpression(@"\[0-9]{6,11}\")]
        public string Document { get; set; }
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayName("First Name")]
        public string FirtsName { get; set; }
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
    }
}
