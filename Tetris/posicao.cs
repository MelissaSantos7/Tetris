namespace Tetris
{
    public class posicao
    {
        public int Row {  get; set; }
        public int Column { get; set; }

        public posicao (int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
