
namespace ITTPEx.Domain.Common.Interfaces
{
    public interface IAuditableEntity : IEntity
    {
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
