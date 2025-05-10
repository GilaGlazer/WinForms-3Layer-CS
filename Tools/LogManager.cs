
namespace Tools;

public static class LogManager
{
    private static readonly string dirPath = "Log";
    public static string Tab = "";

    //ניתוב של קבצי הלוג
    private static string getCurrentPathDir()
    {
        return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dirPath);

    }
    //ניתוב של החודשים
    private static string getLogPathForCurrentFolder()
    {
        string currentMonth = $"{DateTime.Now:yyyy-MM}";
        string logDir = getCurrentPathDir();
        string currentLogFolder = $@"{logDir}\{currentMonth}";

        if (!Directory.Exists(currentLogFolder))
        {
            Directory.CreateDirectory($@"{logDir}\{currentMonth}");
        }
        Directory.CreateDirectory(currentLogFolder);
        return currentLogFolder;
    }
    //ניתוב של הימים
    private static string getLogPathForCurrentDayFiles()
    {
        string currentFolder = getLogPathForCurrentFolder();
        int currentDay = DateTime.Now.Day;
        string currentFile = $@"{currentFolder}/{currentDay}.log";
        if (!File.Exists(currentFile))
            File.Create(currentFile).Close();
        return currentFile;
    }

    public static void WriteToLog(string projectName, string funcName, string message)
    {
        // קביעת הנתיב לתיקיית הלוגים
        string logDirectoryPath = getLogPathForCurrentFolder();

        // קביעת הנתיב לקובץ הלוג
        string logFilePath = getLogPathForCurrentDayFiles();

        // יצירת התוכן שייכתב ללוג
        string logEntry = $"{Tab}{DateTime.Now}\t{projectName}.{funcName}:\t{message}";

        // הוספת התוכן לקובץ
        File.AppendAllText(logFilePath, logEntry + Environment.NewLine);

    }
    public static void DeleteLogContent()
    {
        var directories = Directory.GetDirectories(getCurrentPathDir());
        int month;
        foreach (var dir in directories)
        {
            if (Directory.GetCreationTime(dir) < DateTime.Now.AddMonths(-2))
            {
                Directory.Delete(dir, true);
            }
        }

    }

}





//namespace Tools;

//public static class LogManager
//{
//    private static string dirPath = "Log";
//    public static String Tab = String.Empty;
//    private static String getCurrentPathDir()
//    {
//        return $@"../{dirPath}/{DateTime.Now.Month}";
//    }

//    private static String getCurrentPathFile()
//    {
//        return $@"{LogManager.getCurrentPathDir()}/{DateTime.Now.Day}.txt";
//    }


//    public static void WriteToLog(String projectName, String funcName, String message)
//    {
//        if (!Directory.Exists(LogManager.getCurrentPathDir()))
//        {
//            Directory.CreateDirectory(LogManager.getCurrentPathDir());
//        }

//        if (!File.Exists(LogManager.getCurrentPathFile()))
//        {
//            File.Create(LogManager.getCurrentPathFile());
//        }


//        using (StreamWriter writer = new StreamWriter(LogManager.getCurrentPathFile(), true))
//        {
//            writer.WriteLine($"{Tab}{DateTime.Now}\t{projectName}.{funcName}:\t{message}");
//        }

//    }
//    public static void DeleteLogContent()
//    {
//        String[] directories = Directory.GetDirectories($@"{dirPath}");
//        int month;
//        foreach (var dir in directories)
//        {
//            if (int.TryParse($@"{dir}", out month) && DateTime.Now.Month - month > 2)
//            {
//                Directory.Delete(dir, true);
//            }
//        }


//    }

//}