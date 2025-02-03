namespace SmartdataSecurity.Model
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int  TypeId { get; set; }
        public int CertificateId { get; set; }
        public bool HasQuestions {  get; set; }
        public int TotalQuestions { get; set; }
        public int MinScore {  get; set; }
        public bool IsGlobal {  get; set; }
        public bool Status {  get; set; }
    }
}
