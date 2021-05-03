using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Project : IEntity
    {
        public Project()
        {
            CreatedAt = DateTime.Now;
            IsActive = true;
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Link { get; set; }
    }
}
