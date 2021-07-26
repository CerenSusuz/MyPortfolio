using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Picture : IEntity
    {
        public Picture()
        {
            CreatedAt = DateTime.Now;
            IsActive = true;
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        public string ImagePath { get; set; }
    }
}
