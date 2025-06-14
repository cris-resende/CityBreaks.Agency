namespace CityBreaks.Agency.Utils
{
    public static class Logger
    {
        public static List<string> MemoryLogs { get; private set; } = new List<string>();

        private static readonly string LogFilePath = Path.Combine(Directory.GetCurrentDirectory(), "AppLogs.txt");

        public static void LogToConsole(string message)
        {
            string formattedMessage = $"[CONSOLE][{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
            Console.WriteLine(formattedMessage);
        }

        public static void LogToFile(string message)
        {
            string formattedMessage = $"[FILE][{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
            try
            {
                File.AppendAllText(LogFilePath, formattedMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao logar em arquivo: {ex.Message}");
            }
        }

        public static void LogToMemory(string message)
        {
            string formattedMessage = $"[MEMORY][{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
            MemoryLogs.Add(formattedMessage);
        }

        public static void ClearMemoryLogs()
        {
            MemoryLogs.Clear();
        }
    }
}
