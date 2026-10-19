using Cau1;
using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using SoChiTieu.Models;

namespace Cau1
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {

            ApplicationConfiguration.Initialize();

    

            string basePath = AppContext.BaseDirectory;

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
                .Build();

            AppSettings settings = new AppSettings();
            configuration.Bind(settings);

            Directory.CreateDirectory(Path.Combine(basePath, "Logs"));

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Is(
                    settings.Logging.MinimumLevel.Equals(
                        "Debug", StringComparison.OrdinalIgnoreCase)
                        ? Serilog.Events.LogEventLevel.Debug
                        : Serilog.Events.LogEventLevel.Information)
                .WriteTo.File(
                    Path.Combine(basePath, "Logs", "log-.txt"),
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 30,
                    shared: true)
                .CreateLogger();

            try
            {
                var options = new DbContextOptionsBuilder<QL_ChiTieuContext>()
                    .UseSqlServer(settings.ConnectionStrings.DefaultConnection)
                    .Options;

                using (var db = new QL_ChiTieuContext(options))
                {
                    db.Database.CanConnect();
                }

                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Không thể khởi chạy ứng dụng hoặc kết nối cơ sở dữ liệu.");

                MessageBox.Show(
                    "Không thể khởi chạy ứng dụng. Vui lòng kiểm tra cấu hình kết nối SQL Server.",
                    "Lỗi khởi động",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}