using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRevConnect.Data.Models
{
    public class timedEmail
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string? emailAddress { get; set; }
        [Required]
        public DateTime? time { get; set; }
        public string? emailBody { get; set; }
        [Required]
        public string? emailHeader { get; set; }
        public string? ipAddress { get; set; }
        public DateTime? createdAt { get; set; } = DateTime.Now;
        public DateTime? updatedAt { get; set; } = DateTime.Now;

    }
}
