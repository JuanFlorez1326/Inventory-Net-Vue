namespace Inventory.Models
{
    public class ConnectionDB
    {
        private string _connection = @"Data Source=DESKTOP-BP7KLD4;Initial Catalog=Inventory;Integrated Security=True";
        public string connection { set { _connection = value; } get { return _connection; } }
    }
}