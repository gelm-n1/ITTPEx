
using ITTPEx.Domain.Common.Interfaces;

namespace ITTPEx.Domain.Common
{
    public class BaseEntity : IEntity
    {
        public Guid Id { get; set; }
    }
}
