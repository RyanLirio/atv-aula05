namespace Modelo
{
    public class Product
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public float CurrentPrice { get; set; }

        public bool Validate()
        {

            bool IsValid = true;

            IsValid = !string.IsNullOrEmpty(this.ProductName) &&
                      (this.Id > 0) && 
                      (this.CurrentPrice > 0);

            return IsValid;
        }

    }
}
