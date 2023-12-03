namespace GL3Frameworks.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public virtual ICollection<Movie>? Movies { get; set; }
        
        public virtual Membershiptype? Membershiptype { get; set; }
    }
}
