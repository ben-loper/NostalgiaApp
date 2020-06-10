using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace NostalgiaApp.Models
{
    public class NostalgiaViewModel
    {
        public NostalgiaViewModel(int id, string title, string description, DateTime createDate, DateTime nextReminderDate)
        {
            Id = id;
            Title = title;
            Description = description;
            CreateDate = createDate;
            NextReminderDate = nextReminderDate;            
        }

        public NostalgiaViewModel()
        {

        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool IsActive { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [AllowNull]
        public DateTime NextReminderDate { get; set; }
        public string Image { get; set; }
    }
}
