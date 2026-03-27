using LuckyDraw.GenericRepo;
using LuckyDraw.Models;
using Microsoft.AspNetCore.Mvc;

namespace LuckyDraw.Controllers
{
    public class StudentController : Controller
    {
        StudentRepo studentRepo = new StudentRepo();
        PrizeStudentRepo prizeRepo = new PrizeStudentRepo();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Student student)
        {
            if (ModelState.IsValid)
            {
                int year = DateTime.Now.Year;
                string phoneNumber = string.IsNullOrWhiteSpace(student.PhoneNumber) ? "" : student.PhoneNumber;
                student.YearValue = year;
                student.LuckyNumber = studentRepo.GetLuckyNumber(phoneNumber, year);
                Student studentExist = studentRepo.GetAll().FirstOrDefault(x => x.PhoneNumber == student.PhoneNumber && x.YearValue == student.YearValue) ?? new Student();
                if (studentExist.ID <= 0 )
                {
                    student.MechatronicsEngineeringTechnology = student.MechatronicsEngineeringTechnology.HasValue;
                    student.MechanicalEngineeringTechnology = student.MechanicalEngineeringTechnology.HasValue;
                    student.ElectronicsandTelecommunicationsEngineeringTechnology = student.ElectronicsandTelecommunicationsEngineeringTechnology.HasValue;
                    student.ElectricalandElectronicsEngineeringTechnology = student.ElectricalandElectronicsEngineeringTechnology.HasValue;
                    student.ControlandAutomationEngineeringTechnology = student.ControlandAutomationEngineeringTechnology.HasValue;
                    student.ChemicalEngineeringTechnology = student.ChemicalEngineeringTechnology.HasValue;
                    student.ThermalEngineeringTechnology = student.ThermalEngineeringTechnology.HasValue;

                    student.AutomotiveEngineeringTechnology = student.AutomotiveEngineeringTechnology.HasValue;
                    student.InformationSystems = student.InformationSystems.HasValue;
                    student.Accounting = student.Accounting.HasValue;
                    student.ComputerScience = student.ComputerScience.HasValue;
                    student.SoftwareEngineering = student.SoftwareEngineering.HasValue;
                    student.EnglishLanguage = student.EnglishLanguage.HasValue;
                    student.BusinessAdministration = student.BusinessAdministration.HasValue;
                    student.FinanceandBanking = student.FinanceandBanking.HasValue;
                    student.OtherMajor = student.OtherMajor.HasValue;

                    studentRepo.Create(student);
                    return RedirectToAction("LuckyDraw", new { id = student.ID });
                }

                return RedirectToAction("LuckyDraw", new { id = studentExist.ID });

            }

            return View();
        }


        public IActionResult LuckyDraw(int id)
        {
            Student student = studentRepo.GetByID(id);
            return View(student);
        }

        public IActionResult StudentAward()
        {
            return View();
        }
        public JsonResult GetStudentAward(int luckyNumber)
        {
            try
            {
                int year = DateTime.Now.Year;

                var customer = studentRepo.GetAll().Where(x => x.LuckyNumber == luckyNumber && x.YearValue == year).ToList();
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


                return Json(new
                {
                    status = award.Count(),
                    data = award.FirstOrDefault()
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


        public JsonResult GetAllStudetAward(int luckyNumber, string keyword)
        {
            try
            {
                int year = DateTime.Now.Year;

                keyword = string.IsNullOrWhiteSpace(keyword) ? "" : keyword.Trim().ToLower();

                var students = studentRepo.GetAll().Where(x => x.YearValue == year &&
                                                          (x.LuckyNumber == luckyNumber || luckyNumber == 0))
                                                    .ToList();
                var prizes = prizeRepo.GetAll().Where(x => x.YearValue == year).ToList();

                var award = (from c in students
                             join p in prizes on c.LuckyNumber equals p.LuckyNumber
                             where (c.FullName.ToLower().Contains(keyword) ||
                                     c.PhoneNumber.ToLower().Contains(keyword) ||
                                     p.PrizeName.ToLower().Contains(keyword) ||
                                     string.IsNullOrWhiteSpace(keyword))
                                     && (c.LuckyNumber == luckyNumber || luckyNumber == 0)
                             select new
                             {
                                 c.ID,
                                 c.LuckyNumber,
                                 c.FullName,
                                 c.PhoneNumber,
                                 p.PrizeName
                             }).ToList();


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
}
