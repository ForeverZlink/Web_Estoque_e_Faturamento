namespace Web_Estoque_E_Faturamento._Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name{get; set; }
        
        public string? Description{ get; set; }
        public string? Code{ get; set; }
        
        public DateTime DateOfCreation {
            get {return DateTime.Today.Date;}
            set{;}}

    }
}
