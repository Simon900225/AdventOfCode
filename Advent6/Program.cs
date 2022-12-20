var input = new StreamReader("input.txt").ReadToEnd();

Console.WriteLine($"Start of packet: {FindUniqueSequence(input, 4)}");
Console.WriteLine($"Start of message: {FindUniqueSequence(input, 14)}");

static int FindUniqueSequence(string input, int length)
{
    var queue = new Queue<char>();
    int i = 0;

    for (; i < input.Length; i++)
    {
        queue.Enqueue(input[i]);

        if (queue.Count > length)
        {
            queue.Dequeue();
            if (queue.Distinct().Count() == length)
                break;
        }
    }

    return i + 1;
}