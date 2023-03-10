using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Please select a category.")]
        public int CategoryID { get; set; }  // foreign key property

        public Category Category { get; set; }

        [Required(ErrorMessage = "Please enter a product code.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please enter a product name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a starting date.")]
        public string StartBid { get; set; }

        [Required(ErrorMessage = "Please enter a ending date.")]
        public string EndBid { get; set; }

        [Required(ErrorMessage = "Please enter a product description.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter a product condition.")]
        public string Condition { get; set; }

        [Required(ErrorMessage = "Please enter a product price.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please enter a product name.")]
        public string UserAuhtor { get; set; }

        public string Slug
        {
            get
            {
                if (Name == null)
                    return "";
                else
                    return Name.Replace(' ', '-');
            }
        }
        public string Image
        {
            get
            {
                if (Code == null)
                    return "";
                else
                    return Code + ".jpg";
            }
        }
    }
}
