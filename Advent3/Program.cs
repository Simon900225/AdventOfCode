var input = new StreamReader("input.txt").ReadToEnd();
var rucksackInputs = input.Split(Environment.NewLine);
var rucksacks = rucksackInputs.Select(x => new Rucksack(x));
Console.WriteLine($"The priority of all rucksacks: {rucksacks.Sum(x => x.Priority)}");

Console.WriteLine(@$"The team badge priority: {rucksacks.Chunk(3)
    .Sum(team => Rucksack.GetValue(
        team[0].Content.Intersect(team[1].Content).Intersect(team[2].Content).First()
    ))}");


public record Rucksack(string Content)
{
    public string FirstCompartment => Content.Substring(0, Content.Length / 2);
    public string SecondCompartment => Content.Substring(Content.Length / 2, Content.Length / 2);
    public char CompartmentMatch => FirstCompartment.ToCharArray().Intersect(SecondCompartment.ToCharArray()).First();
    public int Priority
    {
        get
        {
            return GetValue(CompartmentMatch);
        }
    }

    public static int GetValue(char c)
    {
        if (((int)c - 96) > 0)
        {
            return (int)c - 96;
        }

        return (int)c - 38;
    }
}