







class Program {
    
    static void Main(){
        Console.Clear();
        // Moves.preComputeKnight();
        Moves.preComputeKing();
        // Moves.preComputeKnight();

        var Board = new Board();
        
        char[] pieces = {
            'r','n','b','q','k','b','n','r',
            'p','p','p','p','p','p','p','p',
            ' ',' ',' ',' ',' ',' ',' ',' ',
            ' ',' ',' ',' ',' ',' ',' ',' ',
            ' ',' ',' ',' ',' ',' ',' ',' ',
            ' ',' ',' ',' ',' ',' ',' ',' ',
            'P','P','P','P','P','P','P','P',
            'R','N','B','Q','K','B','N','R'
        };
        
        while (true){
            // Board.drawBoard();
            Console.WriteLine(GC.GetTotalMemory(false));
            // Moves.Pawns(0x00F1000001000000, Board.AllOcc, true);
            // Moves.Pawns(Board.White.Pawns, Board.AllOcc, true);
            // Moves.Pawns(Board.Black.Pawns, Board.AllOcc, false);
            string move = Console.ReadLine() ?? "";
        }



    
    }
}

