using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Models.Users {
    [Table("Users")]
    public class User {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле имя является обязательным для ввода!")]
        [Column("FirstName")]
        public string FirstName { get; set; } //Имя
        [Required(ErrorMessage = "Поле фамилия является обязательным для ввода!")]
        [Column("LastName")]
        public string LastName { get; set; } //Фамилия
        [Column("MiddleName")]
        public string MiddleName { get; set; }  //Отчество
        [Required(ErrorMessage = "Поле email является обязательным для ввода!")]
        [Column("Email")]
        public string Email { get; set; } //Почта
        [Required(ErrorMessage = "Поле телефон является обязательным для ввода!")]
        [Column("Phone")]
        public string Phone { get; set; } //Номер телефона
        [Required(ErrorMessage = "Поле ввода страны является обязательным!")]
        [Column("Country")]
        public string Country {  get; set; }//Страна
        [Required(ErrorMessage = "Поле почтового индекса является обязательным!")]
        [Column("PostIndex")]
        public string PostIndex {  get; set; }//Почтовый индекс
        [Required(ErrorMessage = "Поле серия пасторта является обязательным для ввода!")]
        [Column("PassportSeries")]
        public string PassportSeries { get; set; } //Серия паспорта
        [Required(ErrorMessage = "Поле номер пасторта является обязательным для ввода!")]
        [Column("PassportNumber")]
        public string PassportNumber { get; set; } //Номер паспорта
        [Required(ErrorMessage = "Поле когда и кем выдан пасторта является обязательным для ввода!")]
        [Column("PassportIssued")]
        public string PassportIssued { get; set; } //Когда и кем выдан
        [Required(ErrorMessage = "Приложите скан паспорта")]
        [Column("DocumentPicturePath")]
        public string DocumentPicturePath { get; set; } //Скан или фото документа
        [Required(ErrorMessage = "Поле пароль является обязательным для ввода!")]
        [Column("HashPassword")]
        public string HashPassword { get; set; } //Пароль
        [Column("ProfilePicturePath")]
        public string ProfilePicturePath { get; set; } //фото профиля
    }
}
