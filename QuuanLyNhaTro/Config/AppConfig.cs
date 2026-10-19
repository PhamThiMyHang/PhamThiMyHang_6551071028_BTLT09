using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QuuanLyNhaTro.Models;

namespace QuuanLyNhaTro.Config;

public static class AppConfig
{
    private static AppSettings? _settings;

    public static AppSettings Settings => _settings ??= Load();

    private static AppSettings Load()
    {
        // Chạy trong Visual Studio (có debugger) => Development; chạy bản publish => Production
        var env = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")
                  ?? (Debugger.IsAttached ? "Development" : "Production");

        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: false)
            .Build();

        return config.Get<AppSettings>() ?? new AppSettings();
    }

    /// <summary>Tạo DbContext mới. Dùng trong khối using cho mỗi thao tác.</summary>
    public static QlNhaTroContext CreateDb()
    {
        var options = new DbContextOptionsBuilder<QlNhaTroContext>()
            .UseSqlServer(Settings.ConnectionStrings.DefaultConnection)
            .Options;
        return new QlNhaTroContext(options);
    }
}