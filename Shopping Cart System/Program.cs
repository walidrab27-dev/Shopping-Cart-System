namespace Shopping_Cart_System
{
    public class ShoppingCart
    {
        public string Name { get; private set; }
        private double _prices;
        private int _quantity;
        public ShoppingCart(string name, double price, int quantity)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name)) { throw new ArgumentNullException("Name cannot be null or empty."); }
            if (price <= 0) { throw new ArgumentOutOfRangeException("Price cannot be negative."); }
            if (quantity < 0) { throw new ArgumentOutOfRangeException("Quantity cannot be negative."); }
            this.Name = name;
            this._prices = price;
            this._quantity = quantity;
        }
        public string ChangeName(string newName)
        {
            if (string.IsNullOrEmpty(newName) || string.IsNullOrWhiteSpace(newName)) { throw new ArgumentNullException("Name cannot be null or empty."); }
            this.Name = newName;
            return this.Name;
        }
        public double Price { get { return _prices; } }
        public double ChangePrice(double newPrice)
        {
            if (newPrice <= 0) { throw new ArgumentOutOfRangeException("Price cannot be negative."); }
            _prices = newPrice;
            return this._prices;
        }
        public int Quantity { get { return _quantity; } }
        public int ChangeQuantity(int newQuantity)
        {
            if (newQuantity < 0) { throw new ArgumentOutOfRangeException("Quantity cannot be negative."); }
            _quantity = newQuantity;
            return this._quantity;
        }
        public double CalculateTotalPrice()
        {
            double totalPrice = this._prices * this._quantity;
            return totalPrice;
        }
        public double CalculateTotalPrice(double discount)
        {
            if (discount <= 0) { throw new ArgumentOutOfRangeException("Discount cannot be negative."); }
            double totalPrice = (this._prices * this._quantity) - discount;
            return totalPrice;
        }
    }
    public class CartManger
    {
        private List<ShoppingCart> _cartItems;
        public CartManger()
        {
            _cartItems = new List<ShoppingCart>();
        }
        public void AddToCart(ShoppingCart item)
        {
            _cartItems.Add(item);
        }
        public void DisplayCartItems()
        {
            for (var i =0; i < _cartItems.Count; i++)
            {
                if (_cartItems[i].Name == "C# Programming")
                {
                    Console.WriteLine($"{_cartItems[i].Name} | Price: ${_cartItems[i].Price} | Quantity: {_cartItems[i].Quantity}" +
                        $"\nTotal Price: ${_cartItems[i].CalculateTotalPrice(10)}");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"{_cartItems[i].Name}, Price: {_cartItems[i].Price}, Quantity: {_cartItems[i].Quantity}" +
                        $"\nTotal Price: {_cartItems[i].CalculateTotalPrice()}");
                    Console.WriteLine();
                }
            }
        }
        public void CalculateTotalCartPrice()
        {
            double totalCartPrice = 0;
            for (var i = 0; i < _cartItems.Count; i++)
            {
                if (_cartItems[i].Name == "C# Programming")
                {
                    totalCartPrice += _cartItems[i].CalculateTotalPrice(10);
                }
                else
                {
                    totalCartPrice += _cartItems[i].CalculateTotalPrice();
                }
            }
            Console.WriteLine($"Total Cart Price: ${totalCartPrice}");
        }
    }
    internal class Program
    {
        public static void Run()
        {
            CartManger cartManager = new CartManger();
            ShoppingCart item1 = new ShoppingCart("C# Programming", 50.00, 2);
            ShoppingCart item2 = new ShoppingCart("Headphones", 100.00, 1);
            ShoppingCart item3 = new ShoppingCart("T-Shirt", 20.00, 5);
            cartManager.AddToCart(item1);
            cartManager.AddToCart(item2);
            cartManager.AddToCart(item3);
            cartManager.DisplayCartItems();
            cartManager.CalculateTotalCartPrice();
        }
        static void Main(string[] args)
        {
            Run();
        }
    }
}
