/// X & A = ROCK     1
/// Y & B = PAPER    2
/// Z & C = SCISSOR  3
/// LOSS 0
/// DRAW 3
/// WIN  6

GameResult GameOutcome(Game game) =>
    game switch
    {
        { Player: "X", Oppnent: "A" } => new GameResult(3 + 1, 3 + 1), //DRAW + 1
        { Player: "X", Oppnent: "B" } => new GameResult(0 + 1, 6 + 2), //LOSE + 1
        { Player: "X", Oppnent: "C" } => new GameResult(6 + 1, 0 + 3), //WIN  + 1
        { Player: "Y", Oppnent: "A" } => new GameResult(6 + 2, 0 + 1), //WIN  + 2
        { Player: "Y", Oppnent: "B" } => new GameResult(3 + 2, 3 + 2), //DRAW + 2
        { Player: "Y", Oppnent: "C" } => new GameResult(0 + 2, 6 + 3), //LOSE + 2
        { Player: "Z", Oppnent: "A" } => new GameResult(0 + 3, 6 + 1), //LOSE + 3
        { Player: "Z", Oppnent: "B" } => new GameResult(6 + 3, 0 + 2), //WIN  + 3
        { Player: "Z", Oppnent: "C" } => new GameResult(3 + 3, 3 + 3), //DRAW + 3
    };

GameResult GameOutcomeReal(Game game) =>
    game switch
    {
        { Player: "X", Oppnent: "A"} => new GameResult(0 + 3, 6 + 1), //LOSE = SCISSOR + 3
        { Player: "X", Oppnent: "B"} => new GameResult(0 + 1, 6 + 2), //LOSE = ROCK    + 1
        { Player: "X", Oppnent: "C"} => new GameResult(0 + 2, 6 + 3), //LOSE = PAPER   + 2 
        { Player: "Y", Oppnent: "A"} => new GameResult(3 + 1, 3 + 1), //DRAW = ROCK    + 1
        { Player: "Y", Oppnent: "B"} => new GameResult(3 + 2, 3 + 2), //DRAW = PAPER   + 2
        { Player: "Y", Oppnent: "C"} => new GameResult(3 + 3, 3 + 3), //DRAW = SCISSOR + 3 
        { Player: "Z", Oppnent: "A"} => new GameResult(6 + 2, 0 + 1), //WIN  = PAPER   + 2
        { Player: "Z", Oppnent: "B"} => new GameResult(6 + 3, 0 + 2), //WIN  = SCISSOR + 3
        { Player: "Z", Oppnent: "C"} => new GameResult(6 + 1, 0 + 3), //WIN  = ROCK    + 1
    };

var input  = new StreamReader("Input.txt").ReadToEnd();
var games = input.Split(Environment.NewLine);

var totalPlayerScore = games.Sum(x => GameOutcome(GetGame(x)).PlayerScore);
var totalPlayerScoreReal = games.Sum(x => GameOutcomeReal(GetGame(x)).PlayerScore);

Console.WriteLine($"Total points perfect game: {totalPlayerScore}");
Console.WriteLine($"Total points correct strategy: {totalPlayerScoreReal}");

Game GetGame(string input)
{
    var game = input.Split(" ");
    return new Game(game[1], game[0]);
}

public record Game(string Player, string Oppnent);
public record GameResult(int PlayerScore, int OponentScore);