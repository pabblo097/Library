using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.DataModels
{
    public class Book
    {
        //[BindNever]
        public int Id { get; set; }

        [Required(ErrorMessage = "Proszę wprowadzić tytuł")]
        [Display(Name = "Tytuł")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę wprowadzić imię i nazwisko autora")]
        [Display(Name = "Autor")]
        [StringLength(50)]
        public string Author { get; set; }

        [Required(ErrorMessage = "Proszę wprowadzić odpowiedni rok wydania")]
        [Display(Name = "Rok wydania")]
        [Range(1, 2021, ErrorMessage = "Proszę wprowadzić odpowiedni rok wydania")]
        public int? Year { get; set; }

        [Required(ErrorMessage = "Proszę wprowadzić nazwę wydawnictwa")]
        [Display(Name = "Wydawnictwo")]
        [StringLength(50)]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "Proszę wprowadzić krótki opis")]
        [Display(Name = "Krótki opis")]
        [StringLength(400)]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Proszę wprowadzić długi opis")]
        [Display(Name = "Długi opis")]
        public string LongDescription { get; set; }

        [Required(ErrorMessage = "Proszę wprowadzić gatunek literacki")]
        [Display(Name = "Gatunek literacki")]
        [StringLength(50)]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Proszę wprowadzić ilość stron")]
        [Display(Name = "Ilość stron")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Proszę wprowadzić odpowiednią ilość stron (minimalna wartość to 1)")]
        public int? NumberOfPages { get; set; }

        [Required(ErrorMessage = "Proszę wprowadzić ilość egzemplarzy")]
        [Display(Name = "Ilość egzemplaży")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Proszę wprowadzić odpowiednią ilość egzemplarzy (minimalna wartość to 1)")]
        public int? Count { get; set; }

        [Display(Name = "Okładka książki")]
        public byte[] BookCover { get; set; }
    }
}
