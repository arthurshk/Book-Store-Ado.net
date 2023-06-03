using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
  public  class BookInventory
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string authorForename { get; set; }
        [Required]
        [MaxLength(30)]
        public string AuthorSurname { get; set; }
        [Required]
        [MaxLength(50)]
        public string title { get; set; }
        [Required]
        public int pages { get; set; }
        [Required]
        public string price { get; set; }
        public PublisherInventory publisher { get; set; }
    }
}
