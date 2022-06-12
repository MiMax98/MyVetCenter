using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VetCenter.Models
{
    /// <summary>
    /// Model zwierzęcia
    /// </summary>
    public class Pet
    {
        /// <summary>
        /// ID zwierzęcia
        /// </summary>
        [DisplayName("ID")]
        public int PetId { get; set; }
        /// <summary>
        /// Nazwa zwierzęcia
        /// </summary>
        [DisplayName("Nazwa")]
        [Required(ErrorMessage = "{0} jest wymagana")]
        public string Name { get; set; }
        /// <summary>
        /// Gatunek
        /// </summary>
        [DisplayName("Gatunek")]
        [Required(ErrorMessage = "{0} jest wymagany")]
        public string Species { get; set; }
        /// <summary>
        /// Rasa
        /// </summary>
        [Required(ErrorMessage = "{0} jest wymagana")]
        [DisplayName("Rasa")]
        public string Breed { get; set; }
        /// <summary>
        /// Data urodzenia
        /// </summary>
        [DisplayName("Data urodzenia")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "{0} jest wymagana")]
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// ID właściciela
        /// </summary>
        [DisplayName("ID właściciela")]
        [Required(ErrorMessage = "{0} jest wymagane")]

        public int OwnerId { get; set; }
        /// <summary>
        /// Właściciel
        /// </summary>

        [DisplayName("Właściciel")]
        public Owner Owner { get; set; }
        /// <summary>
        /// Lista wizyt
        /// </summary>

        public List<Visit> Visits { get; set; }
    }
}
