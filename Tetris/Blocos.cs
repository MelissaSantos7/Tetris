using System.Collections.Generic;

namespace Tetris
{
    public abstract class Blocos
    {
        protected abstract posicao[][] Tiles { get; }
        protected abstract posicao StartOffset { get; }
        public abstract int Id { get; }

        private int rotationState;
        private posicao offset;

        public Blocos()
        {
            offset = new posicao(StartOffset.Row, StartOffset.Column);  
        }

        public IEnumerable<posicao> TilePositins()
        {
            foreach (posicao p in Tiles[rotationState])
            {
                yield return new posicao(p.Row + offset.Row,p.Column+offset.Column);
            }
        }

        public void RotateCW()
        {
            rotationState = (rotationState + 1) % Tiles.Length;
        }

        public void RotateCCW()
        {
            if (rotationState == 0)
            {
                rotationState = Tiles.Length - 1;
            }
            else
            {
                rotationState--;
            }
        }   
        public void Move(int rows, int columns)
        {
            offset.Row += rows;
            offset.Column += columns;
        }

        public void Reset()
        {
            rotationState = 0 ;
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }
    }
}
