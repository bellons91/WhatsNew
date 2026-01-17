using Spectre.Console;
using System.Reflection;
using WhatsNew.Tests.Utils;

namespace TopicsPicker
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            var assembly = typeof(WhatsNew.Tests.About_AliasOnTypes).Assembly;

            var topics = FindTopicsToShow(assembly);


            ShowListOfTopics(topics);

  
            var choices = topics
                .ToArray()
                .OrderBy(_ => Guid.NewGuid())
                .Chunk(2);

            foreach (var chunk in choices)
            {
                var prompt2 = new SelectionPrompt<string>()
                    .Title("Select a topic")
                    .AddChoices(chunk);

                var chosen = AnsiConsole.Prompt(prompt2);
 
            }
        }
 
        private static void ShowListOfTopics(IEnumerable<string> topics)
        {
            var topicsToDisplay = topics
                .Select(topic => new Markup("[green]> [/]" + topic));

            var panel = new Panel(new Rows(topicsToDisplay));
            panel.Header = new PanelHeader("All the topics to explore", Justify.Center);
            AnsiConsole.Write(panel);
        }

        private static IEnumerable<string> FindTopicsToShow(Assembly myAssembly)
        {
            foreach (var type in myAssembly.GetTypes())
            {
                bool isAttributeApplied = type.IsDefined(typeof(IncludeRandomSelectionAttribute), false);
                IncludeRandomSelectionAttribute attributeInstance = type.GetCustomAttribute<IncludeRandomSelectionAttribute>();

                if (attributeInstance != null)
                {
                    yield return attributeInstance.Description;
                }
            }
        }

    }
}
