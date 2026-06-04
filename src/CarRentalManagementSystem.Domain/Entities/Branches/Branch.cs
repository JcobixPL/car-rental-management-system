namespace CarRentalManagementSystem.Domain.Entities.Branches
{
    public sealed class Branch
    {
        public Guid Id { get; private set; }
        public string City { get; private set; } = string.Empty;
        public string Address { get; private set; } = string.Empty;
        public string PhoneNumber { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public bool IsActive { get; private set; }

        private Branch() { }

        public Branch(
            string city,
            string address,
            string phoneNumber,
            string email)
        {
            Id = Guid.NewGuid();
            City = city;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        public void Activate()
        {
            IsActive = true;
        }
    }
}
