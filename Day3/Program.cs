using System.Text;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main( string[] args ) {
        var result = File.ReadAllLines( AppDomain.CurrentDomain.BaseDirectory + "PuzzleInput.txt" );
        Part1(result);
        //Part2(result);
    }

    private static void Part1( string[] result ) {
        var sums = new Combo[ result[ 0 ].Length ];
        for ( int i = 0; i < sums.Length; i++ )
            sums[ i ] = new Combo();

        for ( int i = 0; i < result.Length; i++ ) 
            for ( int j = 0; j < result[i].Length; j++ ) 
                if ( result[ i ][ j ] == '0' )
                    sums[ j ].Zeros++;
                else
                    sums[ j ].Ones++;

        //---//

        string common = "";
        string uncommon = "";
        foreach ( var sum in sums ) {
            if(sum.Zeros > sum.Ones ) {
                common = common + "0";
                uncommon = uncommon + "1";
            }
            else {
                common = common + "1";
                uncommon = uncommon + "0";
            }
        }
        Console.WriteLine("Part1: " + Convert.ToInt32( common, 2 ) * Convert.ToInt32( uncommon, 2 ) );
    }

    private static void Part2( string[] result ) {
    }

    private class Combo
    {
        public int Ones { get; set; }
        public int Zeros { get; set; }
    }
}
