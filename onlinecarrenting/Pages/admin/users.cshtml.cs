using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using onlinecarrenting.Dao;
using onlinecarrenting.Tables;

namespace onlinecarrenting.Pages.admin
{
    public class usersModel : PageModel
    {public UserDao userdao=new UserDao();
        public List<User> userlist()
        {
           return UserDao.getAllUser();
        }
        public void OnGet()
        {
        }
    }
}
