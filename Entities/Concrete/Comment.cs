using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Comment : IEntity
    {
        public Comment()
        {
            CreatedAt = DateTime.Now;
            IsActive = true;
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        public string Content { get; set; }
        public int UserId { get; set; }
        public int BlogId { get; set; }

    }
}
