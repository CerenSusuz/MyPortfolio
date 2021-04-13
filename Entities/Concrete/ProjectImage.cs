using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class ProjectImage : IEntity
    {
        public ProjectImage()
        {
            CreatedAt = DateTime.Now;
            IsActive = true;
            Date = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsDeleted { get; set; }
        public bool IsActive { get; set; }

        public int ProjectId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}