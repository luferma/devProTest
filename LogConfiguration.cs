using log4net;
using log4net.Config;
using System.Reflection;
using System.Text;

class Program
{
    private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    public static string docPath { get; } = AppDomain.CurrentDomain.BaseDirectory;

    static void Main(string[] args)
    {
        LogFunctionLibrary("Debug", "Debug message");
        LogFunctionLibrary("Info", "Info message");
        LogFunctionLibrary("Warn", "Warn message");
        LogFunctionLibrary("Error", "Error message");
        LogFunctionLibrary("Fatal", "Fatal message");

        LogMessage("Debug", "Debug message");
        LogMessage("Info", "Info message");
        LogMessage("Warn", "Warn message");
        LogMessage("Error", "Error message");
        LogMessage("Fatal", "Fatal message");
    }

    /// Function to log file with logger library
    public static void LogFunctionLibrary(string logType, string message)
    {        
        XmlConfigurator.Configure();

        switch (logType)
        {
            case "Debug":
                log.Debug(message);
                break;
            case "Info":
                log.Info(message);
                break;
            case "Warn":
                log.Warn(message);
                break;
            case "Error":
                log.Error(message);
                break;
            case "Fatal":
                log.Fatal(message);
                break;
            default:                
                break;
        }
    }

    /// Function to log file manually and write in a external file
    public static void LogMessage(string level, string message)
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string logEntry = $"[{timestamp}] [{level}] {message}";

        try
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(logEntry);
            // flush every 20 seconds as you do it
            File.AppendAllText(docPath + "application.log", sb.ToString());
            sb.Clear();          
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error writing to log file: {ex.Message}");
        }
    }
}