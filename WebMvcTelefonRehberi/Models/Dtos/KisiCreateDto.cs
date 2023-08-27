using System;
using System.ComponentModel.DataAnnotations;

namespace WebMvcTelefonRehberi.Models.Dtos
{
    public class KisiCreateDto
    {
        [Required(ErrorMessage = "Ad alani Boş Geçilemez")]
        [MaxLength(30, ErrorMessage = "Ad alani 30 karakterden buyuk olamaz.")]
        public string Adi { get; set; }


        [Required(ErrorMessage = "Soyad alani Boş Geçilemez")]
        [MaxLength(50, ErrorMessage = "Soyad alani 50 karakterden buyuk olamaz.")]
        public string Soyadi { get; set; }




        [MaxLength(50, ErrorMessage = "Email alani 50 karakterden buyuk olamaz.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Gsm zorunlu alandir")]
        [DataType(DataType.PhoneNumber)]
        public string Gsm { get; set; }

        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }


    }
}
