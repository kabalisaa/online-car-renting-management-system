using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using onlinecarrenting.Dao;
using onlinecarrenting.Tables;

namespace onlinecarrenting.Pages.admin
{
    public class Dashboard : PageModel
    {
        public User user = new User();
        public Car car = new Car();
        public UserDao userdao = new UserDao();
        public Cardao cardao = new Cardao();
        public string message = "";
        public string action;
        public Car GetCar()
        {
            return car;
        }
        public void setCar(Car car)
        {
            this.car = car;
        }
        public List<Car> getAllCars()
        {
            return cardao.getAllcar();
        }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            action = Request.Form["action"];
            if (action.Equals("createcar"))
            {
                message = saveCar();
            }
            else
            {
                message = "Deviated";
            }


        }

        public string saveCar()
        {
            car.Platenumber = Request.Form["platenumber"];
            car.Brand = Request.Form["brand"];
            car.Seats = int.Parse(Request.Form["seats"]);
            car.Suitcase = int.Parse(Request.Form["suitcase"]);
            car.Description = (Request.Form["description"]);
            car.Price = int.Parse(Request.Form["price"]);
            var file1 = Request.Form.Files["image1"];
            var file2 = Request.Form.Files["image2"];
            if (file1 != null && file1.Length > 0)
            {
                var fileName = file1.FileName;
                using (var ms = new MemoryStream())
                {
                    file1.CopyTo(ms);
                    car.Image1 = ms.ToArray();
                    //string res=Convert.ToBase64String(filescp);
                    //message=res;
                }
            }
            if (file2 != null && file2.Length > 0)
            {
                var fileName = file2.FileName;
                using (var ms = new MemoryStream())
                {
                    file2.CopyTo(ms);
                    car.Image2 = ms.ToArray();
                    //string res=Convert.ToBase64String(filescp);
                    //message=res;
                }
            }
            return Cardao.saveCar(car);
        }
    }
}
