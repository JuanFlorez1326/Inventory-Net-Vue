namespace Inventory.Models.Entities
{
    public class Invoice
    {
        private int _id_invoice;
        private int _id_product;
        private int _id_user;

        public int id_invoice { set { _id_invoice = value; } get { return _id_invoice; } }
        public int id_product { set { _id_product = value; } get { return _id_product; } }
        public int id_user { set { _id_user = value; } get { return _id_user; } }
    }
}