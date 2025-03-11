namespace Tic_Tac_Toe.Models
{
    public class GameModel
    {
        public char[,] Board;
        public char CurrentPlayer;

        public GameModel()
        {
            Board = new char[3, 3];
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    Board[i, j] = ' ';
                }
            }
            CurrentPlayer = 'X';
        }

        public void MakeMove(int row, int col)
        {
            if(Board[row, col] == ' ')
            {
                Board[row, col] = CurrentPlayer;
            }
        }

        public bool CheckWin()
        {
            for (int i = 0;i < 3;i++)
            {
                if (Board[i, 0] == CurrentPlayer && Board[i, 0] == CurrentPlayer && Board[i, 0] == CurrentPlayer)
                    return true;
            }

            for(int i = 0; i < 3; i++)
            {
                if (Board[0, i] == CurrentPlayer && Board[1, i] == CurrentPlayer && Board[2, i] == CurrentPlayer)
                    return true;
            }

            if (Board[0, 0] == CurrentPlayer && Board[1, 1] == CurrentPlayer && Board[2, 2] == CurrentPlayer)
                return true;

            if (Board[0, 2] == CurrentPlayer && Board[1, 1] == CurrentPlayer && Board[2, 0] == CurrentPlayer)
                return true;

            return false;
        }

    }
}
