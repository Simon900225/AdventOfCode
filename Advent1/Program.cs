using System;
using System.Linq;

var data = new StreamReader("Input.txt").ReadToEnd();

var allBags = data.Split(Environment.NewLine + Environment.NewLine)
    .Select(x => x.Split(Environment.NewLine).Sum(x => Convert.ToInt32(x))).OrderByDescending(x => x);

var largestBag = allBags.First();

var topThreeLargestBags = allBags.Take(3).Sum();

Console.WriteLine($"The largest bag contains {largestBag} calories.");
Console.WriteLine($"The top three largest bags contains {topThreeLargestBags} calories.");