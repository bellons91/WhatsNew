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

            var topics = FindTopicsToShow(assembly).ToList();
            var selectedTopics = new HashSet<string>();

            while (selectedTopics.Count < topics.Count)
            {
                // Get unselected topics and pick 2 random ones
                var unselectedTopics = topics
                    .Where(t => !selectedTopics.Contains(t))
                    .ToArray();

                if (unselectedTopics.Length == 0)
                    break;

                var randomTopics = unselectedTopics
                    .OrderBy(_ => Guid.NewGuid())
                    .Take(Math.Min(2, unselectedTopics.Length))
                    .ToArray();

                // Display the current state
                AnsiConsole.Clear();
                AnsiConsole.Write(CreateTopicsPanel(topics, selectedTopics));
                AnsiConsole.WriteLine();
                //AnsiConsole.Write(CreateSelectionPanel(randomTopics));
                //AnsiConsole.WriteLine();

                // Prompt user for selection
                var prompt = new SelectionPrompt<string>()
                    .Title("[yellow]Select a topic to discuss:[/]")
                    .AddChoices(randomTopics);

                var chosen = AnsiConsole.Prompt(prompt);
                selectedTopics.Add(chosen);

                // Show confirmation
                AnsiConsole.MarkupLine($"[green]✓[/] Selected: [bold]{chosen}[/]");
                await Task.Delay(1000); // Brief pause to show selection
            }

            // Final display
            AnsiConsole.Clear();
            AnsiConsole.Write(CreateTopicsPanel(topics, selectedTopics));
            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine("[green bold]All topics completed![/]");
            AnsiConsole.MarkupLine("\n[green]Session completed![/]");
        }

        private static Panel CreateTopicsPanel(List<string> allTopics, HashSet<string> selectedTopics)
        {
            var topicsToDisplay = allTopics
                .Select(topic =>
                {
                    var icon = selectedTopics.Contains(topic) ? "[green]✓[/]" : "[dim]○[/]";
                    var style = selectedTopics.Contains(topic) ? "[dim strikethrough]" : "[white]";
                    return new Markup($"{icon} {style}{topic}[/]");
                });

            var panel = new Panel(new Rows(topicsToDisplay))
            {
                Header = new PanelHeader($"Topics ({selectedTopics.Count}/{allTopics.Count})", Justify.Center),
                Border = BoxBorder.Rounded
            };

            return panel;
        }

        private static Panel CreateSelectionPanel(string[] choices)
        {
            var choicesMarkup = choices
                .Select((choice, index) => new Markup($"[yellow]{index + 1}.[/] {choice}"));

            var panel = new Panel(new Rows(choicesMarkup))
            {
                Header = new PanelHeader("Choose from these topics", Justify.Center),
                Border = BoxBorder.Rounded
            };

            return panel;
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
