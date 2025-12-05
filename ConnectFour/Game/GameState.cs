public class GameState
{
    public enum WinState { None, Player1_Wins, Player2_Wins, Tie }

    public byte PlayerTurn { get; private set; } = 1;
    public byte CurrentTurn { get; private set; } = 0;

    private readonly byte[,] board = new byte[6, 7];

    public void ResetBoard()
    {
        Array.Clear(board, 0, board.Length);
        PlayerTurn = 1;
        CurrentTurn = 0;
    }

    public byte PlayPiece(byte col)
    {
        if (col > 6)
            throw new ArgumentException("Column out of range.");

        for (byte row = 5; row != 255; row--) // counts 5,4,3,2,1,0
        {
            if (board[row, col] == 0)
            {
                board[row, col] = PlayerTurn;

                byte landingRow = row;     // 0–5 from top, 5 bottom

                CurrentTurn++;

                PlayerTurn = (byte)(PlayerTurn == 1 ? 2 : 1);
                return landingRow;
            }
        }

        throw new ArgumentException("Column is full.");
    }

    public WinState CheckForWin()
    {
        for (byte row = 0; row < 6; row++)
        {
            for (byte col = 0; col < 7; col++)
            {
                byte p = board[row, col];
                if (p == 0) continue;

                if (Check(row, col, 0, 1, p)) return p == 1 ? WinState.Player1_Wins : WinState.Player2_Wins;
                if (Check(row, col, 1, 0, p)) return p == 1 ? WinState.Player1_Wins : WinState.Player2_Wins;
                if (Check(row, col, 1, 1, p)) return p == 1 ? WinState.Player1_Wins : WinState.Player2_Wins;
                if (Check(row, col, -1, 1, p)) return p == 1 ? WinState.Player1_Wins : WinState.Player2_Wins;
            }
        }

        return CurrentTurn >= 42 ? WinState.Tie : WinState.None;
    }

    private bool Check(int r, int c, int dr, int dc, byte p)
    {
        for (int i = 1; i < 4; i++)
        {
            int nr = r + dr * i;
            int nc = c + dc * i;

            if (nr < 0 || nr >= 6 || nc < 0 || nc >= 7)
                return false;

            if (board[nr, nc] != p)
                return false;
        }
        return true;
    }
}