






public class Board {
    
    public bitBoard White, Black;
    public ulong WhiteOcc, BlackOcc, AllOcc;


    public struct bitBoard {
        public ulong Pawns, Rooks, Knights, Bishops, Queens, King;
    }
    

    
    public Board(){
        Black.Pawns =   0x000000000000FF00;
        Black.Rooks =   0x0000000000000081;
        Black.Knights = 0x0000000000000042;
        Black.Bishops = 0x0000000000000024;
        Black.Queens =  0x0000000000000010;
        Black.King =    0x0000000000000008;

        White.Pawns =   0x00FF000000000000;
        White.Rooks =   0x8100000000000000;
        White.Knights = 0x2400000000000000;
        White.Bishops = 0x4200000000000000;
        White.Queens =  0x1000000000000000;
        White.King =    0x0800000000000000;
        updateBoard();
    }

    public Board(Board original){
        Black = original.Black;
        White = original.White;
      
        updateBoard();
    }


    private void updateBoard(){
        WhiteOcc = White.Pawns | White.Rooks | White.Knights | White.Bishops | White.Queens | White.King;
        BlackOcc = Black.Pawns | Black.Rooks | Black.Knights | Black.Bishops | Black.Queens | Black.King;
        AllOcc = WhiteOcc | BlackOcc;
    }


    public void drawBoard (){
        char [] pieces = toCharBoard();
        int row = 8;
        Console.Clear();
        Console.WriteLine("     A  B  C  D  E  F  G  H ");
        Console.WriteLine("    ------------------------");
        string line = "";
        for (int i = 0; i < pieces.Length; i++){
            line += $" {pieces[i]} " ;
            if ((i + 1) % 8 == 0) {
                Console.WriteLine($"{row} | {line}");
                line = "";
                row--;
            }
        }
    }
    
    private char[] toCharBoard()
    {
        char[] board = new char[64];
    
        for (int i = 0; i < 64; i++)
        {
            ulong mask = 1UL << i;
    
            if      ((White.Pawns & mask) != 0) board[i] = 'P';
            else if ((White.Rooks & mask) != 0) board[i] = 'R';
            else if ((White.Knights & mask) != 0) board[i] = 'N';
            else if ((White.Bishops & mask) != 0) board[i] = 'B';
            else if ((White.Queens & mask) != 0) board[i] = 'Q';
            else if ((White.King & mask) != 0) board[i] = 'K';
    
            else if ((Black.Pawns & mask) != 0) board[i] = 'p';
            else if ((Black.Rooks & mask) != 0) board[i] = 'r';
            else if ((Black.Knights & mask) != 0) board[i] = 'n';
            else if ((Black.Bishops & mask) != 0) board[i] = 'b';
            else if ((Black.Queens & mask) != 0) board[i] = 'q';
            else if ((Black.King & mask) != 0) board[i] = 'k';
    
            else board[i] = ' ';
        }
    
        return board;
    }


    private static ulong square(int index){
        return 1UL << index;
    }



    public char[] move(char[] board, string move)
    {
        string[] squares = move.Split(' ');

        int from = DecodeSquare(squares[0]);
        int to   = DecodeSquare(squares[1]);

        board[to] = board[from];
        board[from] = ' ';

        return board;
    }

    private static int DecodeSquare(string square)
    {
        int file = square[0] - 'a'; 
        int rank = square[1] - '1';

        return rank * 8 + file;
    }

}
