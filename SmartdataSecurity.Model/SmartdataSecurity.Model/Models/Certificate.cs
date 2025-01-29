namespace SmartdataSecurity.Model
{
    public class Certificate
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public bool Status { get; set; }
    }
}
