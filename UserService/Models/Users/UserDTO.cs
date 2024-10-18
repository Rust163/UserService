namespace UserService.Models.Users {
    public class UserDTO {
        public int Id { get; set; }
        public string FirstName { get; set; } //Имя
        public string LastName { get; set; } //Фамилия
        public string MiddleName { get; set; }  //Отчество
        public string Email { get; set; } //Почта
        public string Phone { get; set; } //Номер телефона
        public string ProfilePicturePath { get; set; } //фото профиля
    }
}
