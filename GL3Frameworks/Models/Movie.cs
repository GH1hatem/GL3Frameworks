using System.Drawing;

namespace GL3Frameworks.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? name {  get; set; }
        public string? description { get; set; }
        public DateTime date { get; set; }
        public virtual Genre? Genre { get; set; } = null;
        public virtual ICollection<Customer>? Customer { get; set; }
        public Image? Image { get; set; }
    }
}
