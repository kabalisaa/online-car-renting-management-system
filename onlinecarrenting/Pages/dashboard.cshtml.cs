using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using onlinecarrenting.Dao;
using onlinecarrenting.Tables;

namespace onlinecarrenting.Pages
{
    public class PrivacyModel : PageModel
    {
        public User usr=new User();
        public void OnGet()
        {
            string email = Request.Query["email"].ToString();
            usr = UserDao.findUserbyEmail(email);  
        }
    }
}