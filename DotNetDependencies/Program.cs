using System.Globalization;
using Humanizer;

var englishCulture = CultureInfo.GetCultureInfo("en-US");
CultureInfo.CurrentCulture = englishCulture;
CultureInfo.CurrentUICulture = englishCulture;
CultureInfo.DefaultThreadCurrentCulture = englishCulture;
CultureInfo.DefaultThreadCurrentUICulture = englishCulture;

Console.WriteLine("Quantities:");
HumanizeQuantities();

Console.WriteLine("\nDate/Time Manipulation:");
HumanizeDates();

static void HumanizeQuantities()
{
    Console.WriteLine("case".ToQuantity(0));
    Console.WriteLine("case".ToQuantity(1));
    Console.WriteLine("case".ToQuantity(5));
}

static void HumanizeDates()
{
    Console.WriteLine(DateTime.UtcNow.AddHours(-24).Humanize());
    Console.WriteLine(DateTime.UtcNow.AddHours(-2).Humanize());
    Console.WriteLine(TimeSpan.FromDays(1).Humanize());
    Console.WriteLine(TimeSpan.FromDays(16).Humanize());
}