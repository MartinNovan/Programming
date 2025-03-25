using System.Collections.ObjectModel;

namespace _11_assignment
{
    public partial class MainWindow
    {
        public ObservableCollection<Product> Products { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();
            Products = new ObservableCollection<Product>();
            DataContext = this;
            
        }

        private void DataGrid_OnCurrentCellChanged(object? sender, EventArgs e)
        {
            TotalPrice.Text = $"Total price: {Products.Sum(product => product.Price)}";
            ExpiredProducts.Text = $"Expired products: { Products.Count(product => product.ExpirationDate < DateTime.Now)}";
        }

        public class Product
        {
            public string ProductName { get; set; } = "Default Name";
            public decimal Price { get; set; } = 0;
            public DateTime ExpirationDate { get; set; } = DateTime.Now;
        }
    }
}