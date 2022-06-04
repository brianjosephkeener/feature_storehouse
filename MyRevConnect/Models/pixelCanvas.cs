using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRevConnect.Data.Models
{
    public class Pixel
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        public string? color { get; set; }
        public string? ipAddress { get; set; }
        public DateTime? createdAt { get; set; } = DateTime.Now;
        public DateTime? updatedAt { get; set; } = DateTime.Now;

    }
}
