using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CommentDetail : IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string User { get; set; }
        public DateTime WrittenDate { get; set; }
        public int BlogId { get; set; }
        public string Blog { get; set; }
        public string Content { get; set; }
    }
}
