public class Program
{
    public static void Main( string[] args ) {
        var result = File.ReadAllLines( AppDomain.CurrentDomain.BaseDirectory + "PuzzleInput.txt" ).Select( x => new Command( x ) );
        //Part1(result);
        Part2( result );
    }

    private static void Part1( IEnumerable<Command> commands ) {
        int hor = 0;
        int depth = 0;

        foreach ( Command command in commands ) {
            switch ( command.Direction ) {
                case Direction.up:
                depth -= command.Value;
                break;
                case Direction.down:
                depth += command.Value;
                break;
                case Direction.forward:
                hor += command.Value;
                break;
            }
        }
        Console.WriteLine( "Part1: " + hor * depth );
    }

    private static void Part2( IEnumerable<Command> commands ) {
        int hor = 0;
        int aim = 0;
        int depth = 0;

        foreach ( Command command in commands ) {
            switch ( command.Direction ) {
                case Direction.up:
                aim -= command.Value;
                break;
                case Direction.down:
                aim += command.Value;
                break;
                case Direction.forward:
                hor += command.Value;
                depth += aim * command.Value;
                break;
            }
        }
        Console.WriteLine( "Part2: " + hor * depth );
    }

    private class Command
    {
        public Direction Direction { get; }
        public int Value { get; }
        public Command( string command ) {
            var split = command.Split( ' ' );
            Direction = Enum.Parse<Direction>( split[ 0 ] );
            Value = Int32.Parse( split[ 1 ] );
        }
    }

    private enum Direction
    {
        up,
        down,
        forward
    }
}
