using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopApp.Models
{
    public class ShopModel
    {
        public int Id { get; set; }

        [Display(Name = "Shop Name:")]
        [Required(ErrorMessage = "The name is required.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "The length must be in the range from 5 to 20 chars.")]
        public string Name { get; set; }

        public List<ShopItemModel> ShopItems { get; set; }

        public bool IsDeleted { get; set; } = false;
        // kaip jum mano challenge'as? :D aint bad. nes vizualiai atrodo viskas kaip ir ok. ai, ar bandėte perkrauti įrenginį? :D
        // ne, nes sako, kad paskui blogai laika paskaitos fiksduoja :) ten minute viena tai px. vis tiek gale bus valandomis neatitikimai.
        // ok, bandau tada perkraut :)pala da. 
    }
}