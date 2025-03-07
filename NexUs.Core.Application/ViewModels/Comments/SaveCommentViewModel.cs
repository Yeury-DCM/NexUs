using NexUs.Core.Application.Interfaces.Services;
using NexUs.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexUs.Core.Application.ViewModels.Comments
{
    public class SaveCommentViewModel : IHasId
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int? PostId { get; set; } // FK
        public int? ParentCommentId { get; set; } //FK
        public string UserId { get; set; }//fk

    }
}
