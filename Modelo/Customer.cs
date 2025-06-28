namespace Modelo
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }   
        public Address? HomeAddress { get; set; }
        public Address? WorkAddress { get; set; }

        public static int InstanceCount = 0;
        public int ObjectCount = 0;

        public bool Validate()
        {
            bool IsValid = true;

            IsValid = !string.IsNullOrEmpty(this.Name) &&
                      (this.Id > 0);

            return IsValid;
        }
    }
}
