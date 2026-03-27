using LuckyDraw.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace LuckyDraw.Models.Context
{
    public partial class IndustryExhibitionRTCContext
    {
        public IndustryExhibitionRTCContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(Config.ConnectionString);
    }
}
