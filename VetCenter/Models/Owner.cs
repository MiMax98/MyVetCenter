using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VetCenter.Models
{
    /// <summary>
    /// Model właściciela
    /// </summary>
    public class Owner
    {
        /// <summary>
        /// ID właściciela
        /// </summary>
        [DisplayName("ID")]
        public int OwnerId { get; set; }
        /// <summary>
        /// Imię właściciela
        /// </summary>
        [DisplayName("Imię")]
        [Required(ErrorMessage = "{0} jest wymagane")]
        public string FirstName { get; set; }
        /// <summary>
        /// Nazwisko właściciela
        /// </summary>
        [DisplayName("Nazwisko")]
        [Required(ErrorMessage = "{0} jest wymagane")]
        public string LastName { get; set; }
        /// <summary>
        /// Lista zwierząt
        /// </summary>
        public List<Pet> Pets { get; set; }
    }
}
