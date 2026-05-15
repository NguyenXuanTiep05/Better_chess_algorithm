







class Program {
    
    static void Main(){
        
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
            Board.drawBoard();
            Console.WriteLine(GC.GetTotalMemory(false));
            string move = Console.ReadLine() ?? "";
        }
    
    }
}

