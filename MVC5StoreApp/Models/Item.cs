using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MVC5StoreApp.Validation;
using System.Web.Mvc;

namespace MVC5StoreApp.Models
{
     [Bind(Exclude = "ItemId")]
    public class Item //: IValidatableObject // Self-Validating Model
    {
        [ScaffoldColumn(false)]
        public virtual int ItemId { get; set; }
        [Display(Name="Genere")]
        public virtual int GenreId { get; set; }
        [Display(Name= "Product")]
        public virtual int ProductId { get; set; }
        [StringLength(20)]
        // MaxWords attribute in Validation\MaxWords.cs
        [MaxWords(5, ErrorMessage=" There are too many words in {0}")]
        public virtual string Title { get; set; }
        [Required(ErrorMessage = "Item Price is required")]
        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString="{0:c}")]        
        public virtual decimal Price { get; set; }
        public virtual string ItemUrl { get; set; }
        public virtual Genre Genre { get; set; }       
        public virtual Product Product { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }

        // Implemented from IValidatableObject
        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (Title != null && Title.Split(' ').Length > 2)
        //    {
        //        yield return new ValidationResult("Title has too many words", new[] { "Title" });
        //    }
        //}
    }
}