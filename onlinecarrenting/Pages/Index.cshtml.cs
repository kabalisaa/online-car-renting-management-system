using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using onlinecarrenting.Dao;
using onlinecarrenting.Tables;

namespace onlinecarrenting.Pages
{
    public class IndexModel : PageModel
    {
       public User usr=new User();
        private UserDao dao=new UserDao();
        public string message;
        public string action;
        public void OnGet()
        {

        }
        public void OnPost() {
        action= Request.Form["action"];
        if(action.Equals("createuser"))
            {
                usr.Name = Request.Form["name"];   
                usr.Email = Request.Form["email"];
                usr.Password = Request.Form["password"];
                usr.Phone = Request.Form["phone"];
                usr.Gender = Request.Form["gender"];
                message= UserDao.saveUser(usr);
               
            }
        else if(action.Equals("login"))
            {
                usr.Email = Request.Form["email"];
                usr.Password = Request.Form["password"];
                string result= UserDao.UserLogin(usr);
                if(result.Equals(""))
                {
                    message = "Wrong Credentials Try again";
                }
                else
                {
                    Response.Redirect("/dashboard?email="+usr.Email+"");
                }
               
            }
        else if(action.Equals("adminlogin"))
            {
                usr.Email = Request.Form["email"];
                usr.Password = Request.Form["password"];
                if(usr.Email.Equals("admin")&& usr.Password.Equals("admin"))
                {
                    Response.Redirect("/admin/dashboard");
                }
            }
            else if (action.Equals("file"))
            {
                var file = Request.Form.Files["file"];
                if (file != null && file.Length > 0)
                {  
                    var fileName = file.FileName;
                   using(var ms=new MemoryStream())
                    {
                        file.CopyTo(ms);
                        byte[] filescp=ms.ToArray();
                        //string res=Convert.ToBase64String(filescp);
                        //message=res;
                    }
                }
                else
                {
                    message = "no file selected";
                }
               
            }
        }
    }
}