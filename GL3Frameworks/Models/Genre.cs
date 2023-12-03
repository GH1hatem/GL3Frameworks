namespace GL3Frameworks.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string? GenreName { get; set; } = null;
        public virtual ICollection<Movie>? Movies { get; set; }

    }
}
