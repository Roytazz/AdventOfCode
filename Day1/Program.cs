public class Program
{
    public static void Main( string[] args ) {
        var result = File.ReadAllLines( AppDomain.CurrentDomain.BaseDirectory + "PuzzleInput.txt" ).Select(x=> Int32.Parse(x));
        //Part1(result);
        Part2( result );
    }

    private static void Part1( IEnumerable<int> values ) {
        int incr = 0;
        int last = -1;

        foreach ( int value in values ) {
            if ( last == -1 )
                last = value;
            else if ( value > last )
                incr++;
            last = value;
        }
        Console.WriteLine( "Part1: " + incr );
    }

    private static void Part2( IEnumerable<int> values ) {
        int incr = 0;
        int last = -1;

        for ( int i = 0; i < values.Count(); i++ ) {
            if ( i + 2 >= values.Count() )
                break;

            int sum = values.ElementAt( i ) + values.ElementAt( i + 1 ) + values.ElementAt( i + 2 );
            if ( last == -1 )
                last = sum;
            else if ( sum > last )
                incr++;
            last = sum;
        }
        Console.WriteLine( "Part2: " + incr );
    }
}
