using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace NostalgiaApp.Models
{
    
    public class Nostalgia
    {
        public Nostalgia(int id, string title, string description, DateTime createDate, DateTime nextReminderDate, byte[] image)
        {
            Id = id;
            Title = title;
            Description = description;
            CreateDate = createDate;
            NextReminderDate = nextReminderDate;
            Image = image;
        }

        public Nostalgia()
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
        public byte[] Image { get; set; }
    }
}
