using LuckyDraw.GenericRepo;
using LuckyDraw.Models;
using Microsoft.AspNetCore.Mvc;

namespace LuckyDraw.Controllers
{
    public class PrizeController : Controller
    {
        PrizeRepo prizeRepo = new PrizeRepo();

        //[HttpGet("dsqua")]
        public IActionResult Index()
        {
            return View();
        }


        public JsonResult GetAll(int year, int luckynumber, string keyword)
        {
            try
            {
                keyword = string.IsNullOrWhiteSpace(keyword) ? "" : keyword.Trim().ToLower();
                var prizes = prizeRepo.GetAll().Where(x => x.YearValue == year && 
                                                        (x.LuckyNumber == luckynumber || luckynumber == 0) &&
                                                        (x.PrizeName.ToLower().Contains(keyword) || keyword == ""))
                                                .ToList();
                return Json(new
                {
                    status = 1,
                    data = prizes
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

        public JsonResult GetByID(int id)
        {
            try
            {
                var prize = prizeRepo.GetByID(id);
                return Json(new
                {
                    status = 1,
                    data = prize
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

        public JsonResult Delete(int id)
        {
            try
            {
                var prize = prizeRepo.Delete(id);
                return Json(new
                {
                    status = 1,
                    data = prize
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

        public JsonResult SaveData([FromBody] Prize prize)
        {
            try
            {
                prize.YearValue = DateTime.Now.Year;
                var prizes = prizeRepo.GetAll().Where(x => x.YearValue == prize.YearValue &&
                                                        x.LuckyNumber == prize.LuckyNumber &&
                                                        x.ID != prize.ID).ToList();
                if (prizes.Count > 0)
                {
                    return Json(new
                    {
                        status = 0,
                        message = $"Đã tồn tại phần quà có ID: {prize.LuckyNumber}!"
                    });
                }

                Prize p = prizeRepo.GetByID(prize.ID);
                if (p.ID <= 0)
                {
                    prizeRepo.Create(prize);
                }
                else
                {
                    p.LuckyNumber = prize.LuckyNumber;
                    p.PrizeName = prize.PrizeName;
                    prizeRepo.Update(p);
                }

                return Json(new
                {
                    status = 1,
                    data = prize
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
