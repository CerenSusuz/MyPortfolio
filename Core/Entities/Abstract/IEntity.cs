using System;

namespace Core.Entities.Abstract
{
    public interface IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
