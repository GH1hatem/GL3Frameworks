namespace GL3Frameworks.Models
{
    public class Membershiptype
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int SignUpFee { get; set; }
        public int DurationInMonth { get; set; }
        public int DiscountRate { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}
