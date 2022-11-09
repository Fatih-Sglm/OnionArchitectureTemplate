using CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using CrossCuttingConcerns.Logging.Serilog.Messages;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace CrossCuttingConcerns.Logging.Serilog.Logger;

public class FileLogger : LoggerServiceBase
{
    public FileLogger(IConfiguration configuration)
    {
        FileLogConfiguration logConfig = configuration.GetSection("SeriLogConfigurations:FileLogConfiguration")
                                                      .Get<FileLogConfiguration>() ??
                                         throw new Exception(SerilogMessages.NullOptionsMessage);
        var date = DateTime.Now.ToString("yyyy’-‘MM’-‘dd");
        string logFilePath = string.Format("{0}{1}", Directory.GetCurrentDirectory() + logConfig.FolderPath, date + ".txt");

        Logger = new LoggerConfiguration()
                 .WriteTo.File(
                     logFilePath,
                     rollingInterval: RollingInterval.Day,
                     retainedFileCountLimit: null,
                     fileSizeLimitBytes: 5000000,
                     outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}")
                 .CreateLogger();
    }
}