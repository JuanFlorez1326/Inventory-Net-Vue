namespace Inventory.Models.Entities
{
    public class Users
    {
        private int _document_id;
        private string _name;
        private string _lastname;
        private string _email;
        private string _password;
        private string _phone;
        private string _age;

        public int document_id { set { _document_id = value; } get { return _document_id; } }
        public string name { set { _name = value; } get { return _name; } }
        public string lastname { set { _lastname = value; } get { return _lastname; } }
        public string email { set { _email = value; } get { return _email; } }
        public string password { set { _password = value; } get { return _password; } }
        public string phone { set { _phone = value; } get { return _phone; } }
        public string age { set { _age = value; } get { return _age; } }
    }
}