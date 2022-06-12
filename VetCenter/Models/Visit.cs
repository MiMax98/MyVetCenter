using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetCenter.Models
{
    /// <summary>
    /// Model wizyt
    /// </summary>
    public class Visit
    {
        /// <summary>
        /// ID wizyty
        /// </summary>
        [DisplayName("ID")]
        public int VisitId { get; set; }
        /// <summary>
        /// Czas wizyty
        /// </summary>
        [DisplayName("Czas")]
        public DateTime Time { get; set; }
        /// <summary>
        /// Opis wizyty
        /// </summary>
        [DisplayName("Opis")]
        [Required(ErrorMessage = "{0} jest wymagany")]
        public string Description { get; set; }
        /// <summary>
        /// Opłata za wizytę
        /// </summary>
        [DisplayName("Opłata")]
        [Required(ErrorMessage = "{0} jest wymagana")]
        [Range(0,9999,ErrorMessage ="{0} musi być z zakresu {1} - {2}")]
        [Column(TypeName = "decimal(6,2)")]
        public decimal Fee { get; set; }

        public Pet Pet { get; set; }
        public int PetId { get; set; }
    }
}
