namespace SmartdataSecurity.Model
{
    public class Tenant
    {
        public int  Id { get; set; }
        public string  Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public int AddressId { get; set; }
        public string ContactPersonName {  get; set; } = string.Empty;
        public string ContactPersonEmail {  get; set; } = string.Empty;
        public string ContactPhoneNumber { get; set; } = string.Empty;

        public string TenantConfig { get; set; } = string.Empty;

        public bool Status {  get; set; }


    }
}
