
namespace BBCNewsAutomation
{
    internal class LoggerManager
    {
        public static ILogger GetLoggerInstance() 
        {
            return new TextLogger("D:\\Trainings\\logger.txt");
        }
    }
}
