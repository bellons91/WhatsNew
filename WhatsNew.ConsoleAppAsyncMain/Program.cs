namespace WhatsNew.ConsoleAppAsyncMain
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();
            var content = await httpClient.GetStringAsync("https://www.code4it.dev");
            Console.WriteLine(content);
        }
    }
}