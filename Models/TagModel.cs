using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopApp.Models
{
    public class TagModel
    {
        public int Id { get; set; }

        [Display(Name = "Tag Name:")]
        [Required(ErrorMessage = "The name is required.")]
        public string Name { get; set; }
    }
}
