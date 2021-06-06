using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HogwartsRegistration.Entities
{
    [Table("inscription_request")]
    public class InscriptionRequest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(0,9999999999, 
            ErrorMessage = "The filed hogwartsId cannot be more than 10 digits long")]
        public long HogwartsId { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "FirstName field must be shorter than 20 characters")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "LastName field must be shorter than 20 characters")]
        public string LastName { get; set; }

        [Required]
        [Range(0, 99, 
            ErrorMessage = "The filed Age cannot be more than 2 digits long")]
        public int Age { get; set; }

        [Required]
        [Range(0, 3,
            ErrorMessage = "the field houses cannot contain values grater than 3 nor lower than 0 ")]
        public HousesEnum Houses { get; set; }

    }

    public enum HousesEnum
    {
       Gryffindor,
       Hufflepuff,
       Revanclaw,
       Slytherin
    }
}
