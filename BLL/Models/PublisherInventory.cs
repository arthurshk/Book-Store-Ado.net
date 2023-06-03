using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
   public class PublisherInventory
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string publisherName { get; set; }
        [Required]
        public int publishingYear { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string bookType { get; set; }
        
        [Key]
        public int publishingId { get; set; }
    }
}
