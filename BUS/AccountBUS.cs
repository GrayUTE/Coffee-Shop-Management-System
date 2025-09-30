using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;

namespace QuanLyQuanCafe.BUS
{
    public enum LoginResult
    {
        Success,
        WrongUserPass,
        WrongRole
    }

    public class AccountBUS
    {
        private static AccountBUS instance;
        public static AccountBUS Instance
        {
            get { if (instance == null) instance = new AccountBUS(); return instance; }
            private set { instance = value; }
        }
        private AccountBUS() { }

        public LoginResult Login(string userName, string passWord, string selectedRole, out AccountDTO account)
        {
            account = AccountDAO.Instance.GetAccount(userName, passWord);

            if (account == null)
                return LoginResult.WrongUserPass;

            if (account.Role != selectedRole)
                return LoginResult.WrongRole;

            return LoginResult.Success;
        }
    }
}