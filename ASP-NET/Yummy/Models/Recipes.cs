using System.ComponentModel.DataAnnotations;

namespace Yummy.Models
{
    public class Recipes
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime Time { get; set; }
        public string? Difficulty { get; set; }
        public int Likes { get; set; }
        public string? Ingredients { get; set; }
        public string? Process { get; set; }
        public string? Tips_and_Trick { get; set; }
    }
}