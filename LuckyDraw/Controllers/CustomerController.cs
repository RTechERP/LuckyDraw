using LuckyDraw.GenericRepo;
using LuckyDraw.Models;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;

namespace LuckyDraw.Controllers
{
    public class CustomerController : Controller
    {

        CustomerRepo customerRepo = new CustomerRepo();

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult LuckyDraw(int id)
        {
            try
            {
                Customer customer = customerRepo.GetByID(id);
                return View(customer);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.ToString();
                return View();
            }
        }


        #region API

        [HttpGet]
        public JsonResult GetByID(int id)
        {
            try
            {
                Customer customer = customerRepo.GetByID(id);
                return Json(new
                {
                    status = customer.ID <= 0 ? 0 : 1,
                    data = customer
                }, new System.Text.Json.JsonSerializerOptions());
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = 0,
                    data = new Customer()
                }, new System.Text.Json.JsonSerializerOptions());
            }
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            try
            {
                List<Customer> customers = customerRepo.GetAll();
                return Json(new
                {
                    status = 1,
                    data = customers
                }, new System.Text.Json.JsonSerializerOptions());
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = 0,
                    message = ex.Message,
                    error = ex.ToString()
                }, new System.Text.Json.JsonSerializerOptions());
            }
        }

        [HttpPost]
        public JsonResult SaveData([FromBody] Customer c)
        {
            try
            {
                Customer customer = customerRepo.GetByID(c.ID);
                customer.FullName = c.FullName;
                customer.PhoneNumber = c.PhoneNumber;
                customer.EmailAdress = c.EmailAdress;
                customer.Company = c.Company;
                customer.SmartWarehouseSolutions = c.SmartWarehouseSolutions;
                customer.MachineVisionSolutions = c.MachineVisionSolutions;
                customer.AGVnAMRSolutions = c.AGVnAMRSolutions;
                customer.AutomaticMachineManufacturingSolutions = c.AutomaticMachineManufacturingSolutions;
                customer.AutomationEquipmentinProduction = c.AutomationEquipmentinProduction;
                customer.IoTSolutions = c.IoTSolutions;
                customer.OtherSolutions = c.OtherSolutions;
                customer.MailChannel = c.MailChannel;
                customer.WebsiteChannel = c.WebsiteChannel;
                customer.FacebookChannel = c.FacebookChannel;
                customer.PartnersChannel = c.PartnersChannel;
                customer.OtherChannel = c.OtherChannel;
                customer.LuckyNumber = c.LuckyNumber;
                customer.YearValue = c.YearValue;
                customer.GameScore = c.GameScore;
                customer.IsPlayedGame = c.IsPlayedGame;
                customer.TimeStartGame = c.TimeStartGame;
                customer.TimeEndGame = c.TimeEndGame;
                customer.DateOfBirth = c.DateOfBirth;
                customer.Gender = c.Gender;

                if (customer.ID > 0)
                {
                    customerRepo.Update(customer);
                }
                else
                {
                    customerRepo.Create(customer);
                }

                return Json(new
                {
                    status = 1,
                    data = customer
                }, new System.Text.Json.JsonSerializerOptions());
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = 0,
                    message = ex.Message,
                    error = ex.ToString()
                }, new System.Text.Json.JsonSerializerOptions());
            }
        }

        [HttpGet]
        public JsonResult Delele(int id)
        {
            try
            {
                Customer customer = customerRepo.GetByID(id);
                if (customer.ID<=0)
                {
                    return Json(new
                    {
                        status = 0,
                        message = $"Không tìm thấy khách hàng có ID: {id}"
                    }, new System.Text.Json.JsonSerializerOptions());
                }
                else
                {
                    return Json(new
                    {
                        status = 1,
                        message = "Xóa thành công!"
                    }, new System.Text.Json.JsonSerializerOptions());
                }
                
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = 0,
                    message = ex.Message,
                    error = ex.ToString()
                }, new System.Text.Json.JsonSerializerOptions());
            }
        }
        #endregion
    }
}
