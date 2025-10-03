namespace WhatsNew.ConsoleAppAsyncMain
{
    internal class Program
    {
        // C# 7.1 (August 2017)
        private static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();
            var content = await httpClient.GetStringAsync("https://www.code4it.dev");
            Console.WriteLine(content);
        }
    }
}