namespace Tetris
{
    public class GameState
    {
        private Blocos currentBlock;

        public Blocos CurrentBlock 
        {
            get => currentBlock;
            private set
            {
                currentBlock = value;
                currentBlock.Reset();

                for(int i = 0; i < 2; i++)
                {
                    currentBlock.Move(1, 0);

                    if (!BlocksFits())
                    {
                        currentBlock.Move(-1, 0);
                    }
                }
            }
        }

        public GameGrid GameGrid { get; }
        public BlocoQueue BlocoQueue { get; }
        public bool GameOver { get; private set; }
        public int Score { get; private set; }
        public Blocos HeldBlock { get; private set; }
        public bool CanHold {  get; private set; }

        public GameState()
        {
            GameGrid = new GameGrid(22, 10);
            BlocoQueue = new BlocoQueue();
            CurrentBlock = BlocoQueue.GetAndUpdate();
            CanHold = true;
        }

        private bool BlocksFits()
        {
            foreach( posicao p in CurrentBlock.TilePositins())
            {
                if(!GameGrid.IsEmpty(p.Row, p.Column))
                {
                    return false;
                }
            }
            return true;
        }

        public void HoldBlock()
        {
            if (!CanHold)
            {
                return;
            }
            if (HeldBlock == null)
            {
                HeldBlock = CurrentBlock;
                CurrentBlock = BlocoQueue.GetAndUpdate();
            }
            else
            {
                Blocos tmp = CurrentBlock;
                CurrentBlock = HeldBlock;
                HeldBlock = tmp;
            }

            CanHold = false;
        }

        public void RotateBlockCW()
        {
            CurrentBlock.RotateCW();

            if (!BlocksFits())
            {
                CurrentBlock.RotateCCW();
            }
        }

        public void RotateBlockCCW()
        {
            CurrentBlock.RotateCCW();

            if (!BlocksFits())
            {
                CurrentBlock.RotateCW();
            }
        }
        public void MovelBlockLeft()
        {
            CurrentBlock.Move(0, -1);

            if (!BlocksFits())
            {
                CurrentBlock.Move(0, 1);
            }
        }
        public void MoveBlockRight()
        {
            CurrentBlock.Move(0, 1);

            if (!BlocksFits())
            {
                CurrentBlock.Move(0, -1);
            }
        }
        private bool IsGameOver()
        {
            return !(GameGrid.IsRowEmpty(0) && GameGrid.IsRowEmpty(1));
        }

        private void PlaceBlock()
        {
            foreach(posicao p in CurrentBlock.TilePositins())
            {
                GameGrid[p.Row, p.Column] = CurrentBlock.Id;
            }
            Score += GameGrid.ClearFullRows();

            if (IsGameOver())
            {
                GameOver = true;
            }
            else
            {
                CurrentBlock = BlocoQueue.GetAndUpdate();
                CanHold = true;
            }
        }
        public void MoveBlockDown()
        {
            CurrentBlock.Move(1, 0);

            if (!BlocksFits())
            {
                CurrentBlock.Move(-1, 0);
                PlaceBlock();
            }
        }

        private int  TileDropDIstance(posicao p)
        {
            int drop = 0;

            while(GameGrid.IsEmpty(p.Row + drop + 1, p.Column))
            {
                drop++;
            }
            return drop;
        }

        public int BlockDropDistance()
        {
            int drop = GameGrid.Rows;
            
            foreach(posicao p in CurrentBlock.TilePositins())
            {
                drop = System.Math.Min(drop, TileDropDIstance(p));
            }
            return drop;
        }

        public void DropBlock()
        {
            CurrentBlock.Move(BlockDropDistance(), 0);
            PlaceBlock() ;
        }
    }
}
