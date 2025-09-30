using System;

namespace QuanLyQuanCafe.DTO
{
    public class AccountDTO
    {
        public string UserName { get; set; }
        public string Role { get; set; }

        public AccountDTO(string userName, string role)
        {
            UserName = userName;
            Role = role;
        }
    }
}