var input = new StreamReader("input.txt").ReadToEnd();
var sectionAssignmentPairs = input.Split(Environment.NewLine);

int whollyContained = 0;
int conflicts = 0;

foreach(var sectionAssignmentPair in sectionAssignmentPairs)
{
    var pairs = sectionAssignmentPair.Split(',');
    var rangeOne = GetRange(pairs[0]);
    var rangeTwo = GetRange(pairs[1]);
    var combined = rangeOne.Concat(rangeTwo);
    var conflict = combined.Any(x => combined.Count(y => y == x) > 1);

    if (conflict)
        conflicts ++;

    if (rangeOne.All(x => rangeTwo.Contains(x)) || 
        rangeTwo.All(x => rangeOne.Contains(x)))
        whollyContained++;
}

Console.WriteLine(whollyContained);
Console.WriteLine(conflicts);

static List<int> GetRange(string pair)
{
    var range = new List<int>();
    var values = pair.Split('-');
    var start = int.Parse(values[0]);
    var end = int.Parse(values[1]);

    for (int i = start; i <= end; i++)
    {
        range.Add(i);
    }

    return range;
}