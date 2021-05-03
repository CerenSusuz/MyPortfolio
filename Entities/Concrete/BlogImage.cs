using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class BlogImage : IEntity
    {
        public BlogImage()
        {
            CreatedAt = DateTime.Now;
            IsActive = true;
        }
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        public int BlogId { get; set; }
        public string ImagePath { get; set; }
 
    }
}
