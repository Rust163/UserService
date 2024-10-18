using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserService.Models.Users;

namespace UserService.Models.Role {
    [Table("Roles")]
    public class Role {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле роль является обязательным для ввода!")]
        [Column("Role")]
        public string UserRole { get; set; }
    }
}
