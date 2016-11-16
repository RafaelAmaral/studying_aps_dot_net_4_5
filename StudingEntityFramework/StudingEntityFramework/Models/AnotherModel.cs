using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudingEntityFramework.Models
{
    public class AnotherModel
    {
        public int Id { get; set; }
        [Required]
        public string Field { get; set; }
    }
}