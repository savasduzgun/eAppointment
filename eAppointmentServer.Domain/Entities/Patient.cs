namespace eAppointmentServer.Domain.Entities
{
    public sealed class Patient
    {
        //patient nesnesi her üretildiğinde otomatik guid oluşur
        public Patient() 
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string IdentityNumber { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty; 
        public string Town { get; set; } = string.Empty; 
        public string FullAdress { get; set; } = string.Empty;
    }
}
