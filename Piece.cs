




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

    static ulong notACol =  0xFEFEFEFEFEFEFEFE;
    static ulong notHCol =  0x7F7F7F7F7F7F7F7F;
    static ulong notABCol = 0xFCFCFCFCFCFCFCFC;
    static ulong notGHCol = 0x3F3F3F3F3F3F3F3F;


    public static int[] crossMoves = {9,7,-9,-7};
    public static int[] straightMoves = {8,1,-8,-1};
    public static int pawnMoves = 8;
    public static (int, ulong)[] knightMoves = {(15, notHCol), 
                                                (17, notACol), 
                                                (-15, notACol), 
                                                (-17, notHCol), 
                                                (6, notGHCol),
                                                (10, notABCol), 
                                                (-6, notABCol), 
                                                (-10, notGHCol)};

    public static (int, ulong)[] kingMoves = {  (-1, notHCol),(-9, notHCol),(7,notHCol),
                                                (1, notACol),(-7,notACol),(9, notACol),
                                                (-8, 0xFFFFFFFFFFFFFFFF),(8, 0xFFFFFFFFFFFFFFFF)};

}


public static class Moves{

    private static int moveCount = 0;
    private static Move[] moves = new Move[256];
    private static ulong[] knightsAttack = new ulong[64];
    private static ulong[] kingAttack = new ulong[64];


    public static void printUlong(ulong value)
    {
        for (int i = 0; i < 64; i++)
        {
            Console.Write(((value >> i) & 1UL) + " ");
    
            if ((i + 1) % 8 == 0)
                Console.WriteLine();
        }
    
        Console.WriteLine();
    }

    public static void GenerateMoves(Board board){
        
    }


    public static void Pawns(ulong pawns, ulong occ, bool white){
        ulong pawnMoves; 
        ulong pawnMovesDouble; 
        ulong whitePawnDoubleMove = 0x00FF000000000000;
        ulong blackPawnDoubleMove = 0x000000000000FF00;
        int moveInt = Piece.pawnMoves;

        if (white){
            pawnMoves = (pawns >> moveInt) & ~occ;
            pawnMovesDouble = pawns & whitePawnDoubleMove;
            pawnMovesDouble = (pawnMovesDouble >> (moveInt * 2)) & ~occ;
        }
        else {
            pawnMoves = (pawns << moveInt) & ~occ;
            pawnMovesDouble = pawns & blackPawnDoubleMove;
            pawnMovesDouble = (pawnMovesDouble << (moveInt * 2)) & ~occ;
        }

        
        while (pawnMoves != 0)
        {
            ulong toBit = pawnMoves & ~(pawnMoves - 1);
            pawnMoves &= pawnMoves - 1;
        
            int to = BitOperations.TrailingZeroCount(toBit);
            int from = white ? to - moveInt : to + moveInt;
        
            moves[moveCount++] = new Move((byte)from, (byte)to);
        }

        while (pawnMovesDouble != 0){
            ulong toBit = pawnMovesDouble & ~(pawnMovesDouble- 1);
            pawnMovesDouble &= pawnMovesDouble - 1;
        
            int to = BitOperations.TrailingZeroCount(toBit);
            int from = white ? to - (moveInt * 2) : to + (moveInt * 2);
        
            moves[moveCount++] = new Move((byte)from, (byte)to);

        }
        Console.WriteLine(moveCount.ToString());
        for (int i = 0; i < moveCount; i++){
            Console.WriteLine("MOVE: " + moves[i].From.ToString() + " -> " + moves[i].To.ToString());
        }
    }


    private static void genStraightMoves (ulong piece, ulong occupied){

    }


    public static void preComputeKnight(){
        for (int i = 0; i < 64; i++){
            ulong position = 1UL << i;

            for (int j = 0; j < Piece.knightMoves.Length; j++){
                (int move, ulong mask)= Piece.knightMoves[j];
                knightsAttack[i] |= (move < 0 ? (position >> Math.Abs(move)) : (position << move)) & mask;
            }
            Console.Clear();
            Console.WriteLine(i.ToString());
            printUlong(knightsAttack[i]);
            Console.ReadKey();
        }
    }

    public static void preComputeKing(){
        for (int i = 0; i < 64; i++){
            ulong position = 1UL << i;

            for (int j = 0; j < Piece.kingMoves.Length; j++){
                (int move, ulong mask)= Piece.kingMoves[j];
                kingAttack[i] |= (move < 0 ? (position >> Math.Abs(move)) : (position << move)) & mask;
            }
            Console.Clear();
            Console.WriteLine(i.ToString());
            printUlong(kingAttack[i]);
            Console.ReadKey();
        }
    }

}













