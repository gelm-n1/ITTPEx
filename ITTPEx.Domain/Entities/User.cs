
using System.ComponentModel.DataAnnotations.Schema;
using ITTPEx.Domain.Common;
using ITTPEx.Domain.Enumerations;

namespace ITTPEx.Domain.Entities
{
    [Table("users")]
    public class User : BaseAuditableEntity
    {
        public User(Guid id,
            string login,
            string hashPassword,
            string name,
            Gender gender,
            DateTime? birthday,
            Guid roleId,
            string createdBy)
        {
            Id = id;
            Login = login;
            HashPassword = hashPassword;
            Name = name;
            Gender = gender;
            Birthday = birthday;
            RoleId = roleId;
            CreatedBy = createdBy;
        }

        public string Login { get; set; }
        public string HashPassword { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public Guid RoleId { get; set; }
        public DateTime? RevokedOn { get; set; }
        public string? RevokedBy { get; set; }

        public Role Role { get; set; }

    }
}
