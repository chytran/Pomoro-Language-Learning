using System.ComponentModel.DataAnnotations;

namespace Pomoro_Language_Learning.Areas.Identity.Data
{
    public class ReviewCards
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NonTranslated { get; set; }
        [Required]
        public string Translated { get; set; }
    }
}
