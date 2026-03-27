namespace LuckyDraw.Models.Common
{
    public class Config
    {
        private static int _isPublish = 1;
        public static string ConnectionString
        {
            get
            {
                string connectionString = @"Server=DESKTOP-40H717B\MSSQLSERVER19;database=IndustryExhibitionRTC;User Id = sa; Password=1;TrustServerCertificate=True";
                if (_isPublish == 1) connectionString = @"";
                return connectionString;
            }
        }
    }
}
