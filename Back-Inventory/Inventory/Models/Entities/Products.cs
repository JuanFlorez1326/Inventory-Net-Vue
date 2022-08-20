namespace Inventory.Models.Entities
{
    public class Products
    {
        private int _id_product;
        private int _user_productId;
        private string _name_product;
        private string _description;
        private int _tickets;
        private int _departures;
        private int _total;
        private string _seller;
        private string _image_url;
        private double _price;

        public int id_product { set { _id_product = value; } get { return _id_product; } }
        public int user_productId { set { _user_productId = value; } get { return _user_productId; } }
        public string name_product { set { _name_product = value; } get { return _name_product; } }
        public string description { set { _description = value; } get { return _description; } }
        public int tickets { set { _tickets = value; } get { return _tickets; } }
        public int departures { set { _departures = value; } get { return _departures; } }
        public int total { set { _total = value; } get { return _total; } }
        public string seller { set { _seller = value; } get { return _seller; } }
        public string image_url { set { _image_url = value; } get { return _image_url; } }
        public double price { set { _price = value; } get { return _price; } }
    }
}