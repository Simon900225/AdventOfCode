using System.Runtime.InteropServices;

var inputReader = new StreamReader("input.txt");
var stackString = "";
var instructionsString = "";

Stack<char>[] stacks = new Stack<char>[9] { new Stack<char>(), new Stack<char>(), new Stack<char>(), new Stack<char>(), new Stack<char>(), new Stack<char>(), new Stack<char>(), new Stack<char>(), new Stack<char>() };

while (true)
{
    var line = inputReader.ReadLine();
    if (line == null || line.StartsWith("move"))
    {
        instructionsString += line + Environment.NewLine;
        break;
    }

    stackString += line + Environment.NewLine;
}

instructionsString += inputReader.ReadToEnd();

var stackLines = stackString.Split(Environment.NewLine);
for (int i = stackLines.Length - 4; i >= 0; i--)
{
    var data = stackLines[i].Split(' ');
    int column = 0;
    int emptyCount = 0;
    foreach(var s in data)
    {
        if (s == string.Empty)
            emptyCount++;
        else
        {
            char c = s[1];
            stacks[column].Push(c);
            column++;
        }
        if (emptyCount == 4)
        {
            column++;
            emptyCount = 0;
        }
    }
}

//CrateMover 9000
//foreach(var instruction in instructionsString.Split(Environment.NewLine))
//{
//    var intructionSplit = instruction.Split(' ');
//    var amount = int.Parse(intructionSplit[1]);
//    var from = int.Parse(intructionSplit[3]) - 1;
//    var to = int.Parse(intructionSplit[5]) - 1;

//    for (int i = 0; i < amount; i++)
//    {
//        var value = stacks[from].Pop();
//        stacks[to].Push(value);
//    }
//}

//CrateMover 9001
foreach (var instruction in instructionsString.Split(Environment.NewLine))
{
    var intructionSplit = instruction.Split(' ');
    var amount = int.Parse(intructionSplit[1]);
    var from = int.Parse(intructionSplit[3]) - 1;
    var to = int.Parse(intructionSplit[5]) - 1;

    var valuesToAdd = new List<char>();
    for (int i = 0; i < amount; i++)
    {
        var value = stacks[from].Pop();
        valuesToAdd.Add(value);
    }

    valuesToAdd.Reverse();
    foreach (var value in valuesToAdd)
    {
        stacks[to].Push(value);
    }
}

var lastRow = "";
foreach(var stack in stacks)
{
    lastRow += stack.Pop();
}

Console.WriteLine(lastRow);
