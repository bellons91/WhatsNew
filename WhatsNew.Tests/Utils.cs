namespace WhatsNew.Tests
{
    public static class Utils
    {
        public static IEnumerable<T> Shuffle<T>(IEnumerable<T> items)
        {
            Random rd = new Random();
            return items.OrderBy(_ => rd.Next());
        }
    }
}