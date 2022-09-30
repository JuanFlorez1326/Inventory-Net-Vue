namespace Inventory.Models.Entities
{
    public class Login
    {
        private string _emailLogin;
        private string _passwordLogin;

        public string emailLogin { set { _emailLogin = value; } get { return _emailLogin; } }
        public string passwordLogin { set { _passwordLogin = value; } get { return _passwordLogin; } }
    }
}