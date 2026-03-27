using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LuckyDraw.Models;
using LuckyDraw.GenericRepo;

namespace LuckyDraw.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;


    CustomerRepo customerRepo = new CustomerRepo();
    StudentRepo studentRepo = new StudentRepo();
    PrizeRepo prizeRepo = new PrizeRepo();

    private IConfiguration configuration;
    public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
    {
        _logger = logger;
        this.configuration = configuration;
    }

    //[HttpGet("dangky")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(Customer customer)
    {
        if (ModelState.IsValid)
        {
            int year = DateTime.Now.Year;
            string phoneNumber = string.IsNullOrWhiteSpace(customer.PhoneNumber) ? "" : customer.PhoneNumber;

            int minValue = configuration.GetValue<int>("MinValue");
            int maxValue = configuration.GetValue<int>("MaxValue");

            customer.YearValue = year;
            customer.LuckyNumber = customerRepo.GetLuckyNumber(phoneNumber, year, minValue, maxValue);
            Customer customerExist = customerRepo.GetAll().FirstOrDefault(x => x.PhoneNumber == customer.PhoneNumber && x.YearValue == customer.YearValue) ?? new Customer();
            if (customerExist.ID <= 0)
            {
                customer.SmartWarehouseSolutions = customer.SmartWarehouseSolutions.HasValue;
                customer.MachineVisionSolutions = customer.MachineVisionSolutions.HasValue;
                customer.AGVnAMRSolutions = customer.AGVnAMRSolutions.HasValue;
                customer.AutomaticMachineManufacturingSolutions = customer.AutomaticMachineManufacturingSolutions.HasValue;
                customer.AutomationEquipmentinProduction = customer.AutomationEquipmentinProduction.HasValue;
                customer.IoTSolutions = customer.IoTSolutions.HasValue;
                customer.OtherSolutions = customer.OtherSolutions.HasValue;

                customer.MailChannel = customer.MailChannel.HasValue;
                customer.WebsiteChannel = customer.WebsiteChannel.HasValue;
                customer.FacebookChannel = customer.FacebookChannel.HasValue;
                customer.PartnersChannel = customer.PartnersChannel.HasValue;
                customer.OtherChannel = customer.OtherChannel.HasValue;

                //customer.LuckyNumber = 0;
                customer.GameScore = 0;
                customer.IsPlayedGame = false;

                customerRepo.Create(customer);
                return RedirectToAction("LuckyDraw", new { id = customer.ID });
            }

            return RedirectToAction("LuckyDraw", new { id = customerExist.ID });

        }

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    //[HttpGet("quaysotrungthuong")]
    public IActionResult LuckyDraw(int id)
    {

        Customer customer = customerRepo.GetByID(id);
        return View(customer);

    }

    //[HttpGet("dstrungthuong")]
    public IActionResult CustomerAward()
    {
        return View();
    }

    public JsonResult GetCustomerAward(int luckyNumber)
    {
        try
        {
            int year = DateTime.Now.Year;

            var customer = customerRepo.GetAll().Where(x => x.LuckyNumber == luckyNumber && x.YearValue == year).ToList();
            var prizes = prizeRepo.GetAll().Where(x => x.YearValue == year).ToList();

            var award = (from c in customer
                         join p in prizes on c.LuckyNumber equals p.LuckyNumber
                         select new
                         {
                             c.ID,
                             c.LuckyNumber,
                             c.FullName,
                             c.PhoneNumber,
                             p.PrizeName
                         }).ToList();

            if (award.FirstOrDefault() == null)
            {
                return Json(new
                {
                    status = award.Count(),
                    data = customer.FirstOrDefault()
                });
            }
            else
            {
                return Json(new
                {
                    status = award.Count(),
                    data = award.FirstOrDefault()
                });
            }
            
        }
        catch (Exception ex)
        {
            return Json(new
            {
                status = 0,
                message = ex.Message
            });
        }
    }


    public JsonResult GetAllCustomerAward(int luckyNumber, string keyword)
    {
        try
        {
            int year = DateTime.Now.Year;

            keyword = string.IsNullOrWhiteSpace(keyword) ? "" : keyword.Trim().ToLower();

            var customer = customerRepo.GetAll().Where(x => x.YearValue == year &&
                                                      (x.LuckyNumber == luckyNumber || luckyNumber == 0))
                                                .ToList();
            var prizes = prizeRepo.GetAll().Where(x => x.YearValue == year).ToList();

            var award = (from c in customer
                         join p in prizes on c.LuckyNumber equals p.LuckyNumber into customerAll
                         from ca in customerAll.DefaultIfEmpty()
                         where (c.FullName.ToLower().Contains(keyword) ||
                                 c.PhoneNumber.ToLower().Contains(keyword) ||
                                 ca.PrizeName.ToLower().Contains(keyword) ||
                                 string.IsNullOrWhiteSpace(keyword))
                                 && (c.LuckyNumber == luckyNumber || luckyNumber == 0)
                         select new
                         {
                             c.ID,
                             c.LuckyNumber,
                             c.FullName,
                             c.PhoneNumber,
                             c.Company,
                             PrizeName = ca?.PrizeName ?? "",
                             LuckyNumberPrize = ca?.LuckyNumber ?? 0,
                         }).OrderByDescending(x => x.ID)
                            .ToList();


            return Json(new
            {
                status = 1,
                data = award
            });
        }
        catch (Exception ex)
        {
            return Json(new
            {
                status = 0,
                message = ex.Message
            });
        }
    }
}
