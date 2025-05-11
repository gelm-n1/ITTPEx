
using System.ComponentModel.DataAnnotations.Schema;
using ITTPEx.Domain.Common;

namespace ITTPEx.Domain.Entities
{
    [Table("roles")]
    public class Role : BaseEntity
    {
        public Role(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
