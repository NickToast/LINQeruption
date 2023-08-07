using System.Diagnostics.Tracing;

List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Test", 1905, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
// IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
// PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!

//1. Use LINQ to find the first eruption that is in Chile and print the result.
Console.WriteLine("1: ");
Console.WriteLine(eruptions.Where(e => e.Location == "Chile").OrderBy(e => e.Year).First());

//2. Find the first eruption from the "Hawaiian Is" location and print it. If none is found, print "No Hawaiian Is Eruption found."
Console.WriteLine("2: ");
var HawaiianIsList = eruptions.Where(e => e.Location == "Hawaiian Is").ToList();
if (HawaiianIsList.Count < 1) 
{
    Console.WriteLine("No Hawaiian Is Eruption found");
}
else 
{
    Console.WriteLine(eruptions.Where(e => e.Location == "Hawaiian Is").OrderBy(e => e.Year).First());
}

//3. Find the first eruption from the "Greenland" location and print it. If none is found, print "No Greenland Eruption found."
Console.WriteLine("3: ");
var GreenlandList = eruptions.Where(e => e.Location == "Greenland").ToList();
if (GreenlandList.Count < 1) 
{
    Console.WriteLine("No Greenland Eruption found");
}
else 
{
    Console.WriteLine(eruptions.Where(e => e.Location == "Greenland").OrderBy(e => e.Year).First());
}

//4. Find the first eruption that is after the year 1900 AND in "New Zealand", then print it.
Console.WriteLine("4: ");
Console.WriteLine(eruptions.Where(e => e.Location == "New Zealand").Where(e => e.Year > 1900).OrderBy(e => e.Year).First());

//5. Find all eruptions where the volcano's elevation is over 2000m and print them.
Console.WriteLine("5: ");
foreach (Eruption e in eruptions.Where(e => e.ElevationInMeters > 2000))
{
    Console.WriteLine(e.ToString());
}
//Or can use the helper method and put the query into a List or IEnumerable like so
IEnumerable<Eruption> ElevationAbove2000 = eruptions.Where(e => e.ElevationInMeters > 2000);
PrintEach(ElevationAbove2000, "Eruptions with Elevation Above 2000m");

//6. Find all eruptions where the volcano's name starts with "L" and print them. Also print the number of eruptions found.
//single quotes for L
Console.WriteLine("6: ");
IEnumerable<Eruption> eruptionsStartL = eruptions.Where(e => e.Volcano[0] == 'L');
int Lcount = eruptionsStartL.Count();
PrintEach(eruptionsStartL, $"There are {Lcount} eruptions that start with L");

//7. Find the highest elevation, and print only that integer (Hint: Look up how to use LINQ to find the max!)
Console.WriteLine("7: ");
int highestElevation = eruptions.Max(e => e.ElevationInMeters);
Console.WriteLine($"The highest elevation recorded is {highestElevation} meters.");

//8. Use the highest elevation variable to find and print the name of the Volcano with that elevation.
//Single returns a single, specific element of a sequence
Console.WriteLine("8: ");
Eruption highestElev = eruptions.Single(e => e.ElevationInMeters == highestElevation);
Console.WriteLine($"Highest elevation Volcano: {highestElev.Volcano}");

//9. Print all Volcano names alphabetically.
Console.WriteLine("9: ");
IEnumerable<Eruption> alphabetical = eruptions.OrderBy(e => e.Volcano);
PrintEach(alphabetical, "List of Volcano Eruptions in Alphabetical Order:");

//10. Print the sum of all the elevations of the volcanoes combined.
Console.WriteLine("10:");
int sum = eruptions.Sum(e => e.ElevationInMeters);
Console.WriteLine($"Sum of All Elevations: {sum} meters");

//11. Print whether any volcanoes erupted in the year 2000 (Hint: look up the Any query)
Console.WriteLine("11:");
if (eruptions.Any(e => e.Year == 2000))
{
    Console.WriteLine("There are Volcano eruptions in the year 2000.");
} else
{
    Console.WriteLine("No Volcano eruptions in the year 2000.");
}
//Can also set eruption to a bool and use that in a ternary ?
bool volcanoes2000 = eruptions.Any(e => e.Year == 2000);
Console.WriteLine(volcanoes2000 ? "There are Volcano eruptions in the year 2000." : "No Volcano eruptions in the year 2000.");


//12. Find all stratovolcanoes and print just the first three (Hint: look up Take)
Console.WriteLine("12:");
IEnumerable<Eruption> stratovolcanoEruptions3 = eruptions.Where(e => e.Type == "Stratovolcano").Take(3);
PrintEach(stratovolcanoEruptions3, "Stratovolcano eruptions.");


//13. Print all the eruptions that happened before the year 1000 CE alphabetically according to Volcano name.
Console.WriteLine("13:");
IEnumerable<Eruption> beforeYear1000 = eruptions.Where(e => e.Year < 1000).OrderBy(e => e.Volcano);
PrintEach(beforeYear1000, "Eruptions Before Year 1000 in Alphabetical Order:");


//14. Redo the last query, but this time use LINQ to only select the volcano's name so that only the names are printed.
//Empty array of strings, by selecting only the volcano names, we are getting back strings, so we have to set the variable to a string, and because
//we have multiple volcano names, it must be an array, so we use the .ToArray() method to convert the data type
Console.WriteLine("14:");
string[] eruptionsBeforeYear1000Names = eruptions.Where(e => e.Year < 1000).OrderBy(e => e.Volcano).Select(e => e.Volcano).ToArray();
foreach(string s in eruptionsBeforeYear1000Names)
{
    Console.WriteLine(s);
}


// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}

