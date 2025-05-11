
using ITTPEx.Domain.Common.Interfaces;

namespace ITTPEx.Domain.Common
{
    public class BaseAuditableEntity : BaseEntity, IAuditableEntity
    {
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; } 
        public string? ModifiedBy { get; set; }
    }
}
