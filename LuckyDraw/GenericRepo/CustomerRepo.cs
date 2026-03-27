using LuckyDraw.Models;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;

namespace LuckyDraw.GenericRepo
{
    public class CustomerRepo : GenericRepo<Customer>
    {
        //private IConfiguration configuration;
        //public CustomerRepo(IConfiguration configuration)
        //{
        //    this.configuration = configuration;
        //}

        public int GetLuckyNumber(string phoneNumber, int year, int minValue, int maxValue)
        {
            //int minValue = 1, maxValue = 11;
            try
            {
                //int minValue = configuration.GetValue<int>("MinValue");
                //int maxValue = configuration.GetValue<int>("MaxValue");

                //int minValue = 1;
                //int maxValue = 999;

                phoneNumber = phoneNumber.Trim();
                Customer customer = GetAll().FirstOrDefault(x => x.PhoneNumber == phoneNumber && x.YearValue == year) ?? new Customer();
                if (customer.LuckyNumber > 0) //nếu đã có số
                {
                    return Convert.ToInt32(customer.LuckyNumber);
                }
                else//Nếu chưa có số thì random 1 số
                {
                    //Get 1 list số đã có
                    List<int> luckyNumbers = GetAll().Where(x => x.YearValue == year)
                                                     .Select(x => Convert.ToInt32(x.LuckyNumber)).ToList();

                    //luckyNumbers.AddRange(new[] { 1, 2, 3, 4, 5, 6, 7, 8 });
                    Random random = new Random();
                    int randomNumber = 0;
                    do
                    {
                        randomNumber = random.Next(minValue, maxValue); // Tạo số ngẫu nhiên từ min đến max
                    }
                    while (luckyNumbers.Contains(randomNumber)); // Kiểm tra số có trong danh sách không

                    return randomNumber;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
