




using System.Numerics;




public struct Move
{
    public byte From;
    public byte To;

    public Move(byte from, byte to)
    {
        From = from;
        To = to;
    }
}

static class Piece {

    public static int[] crossMoves = {9,7,-9,-7};
    public static int[] straightMoves = {8,1,-8,-1};
    public static int pawnMoves = 8;
    public static int[] knightMoves = {15, 17, -15, -17};

}


public static class Moves{

    private static int moveCount = 0;
    private static Move[] moves = new Move[256];
    static void printUlong(ulong value)
    {
        for (int i = 0; i < 64; i++)
        {
            Console.Write((value >> i) & 1UL);
    
            if ((i + 1) % 8 == 0)
                Console.WriteLine();
        }
    
        Console.WriteLine();
    }

    public static void GenerateMoves(Board board){
        
    }


    public static void Pawns(ulong pawns, ulong occ, bool white){
        ulong pawnMoves; 

        if (white){
            pawnMoves = (pawns >> 8) & ~occ;
        }
        else {
            pawnMoves = (pawns << 8) & ~occ;
        }

        printUlong(pawnMoves);

        while (pawnMoves != 0)
        {
            ulong toBit = pawnMoves & ~(pawnMoves - 1);
            pawnMoves &= pawnMoves - 1;
        
            int to = BitOperations.TrailingZeroCount(toBit);
            int from = white ? to - 8 : to + 8;
        
            moves[moveCount++] = new Move((byte)from, (byte)to);
        }
        Console.WriteLine(moveCount.ToString());
        for (int i = 0; i < moveCount; i++){
            Console.WriteLine("MOVE: " + moves[i].From.ToString() + " -> " + moves[i].To.ToString());
        }
    }

}













