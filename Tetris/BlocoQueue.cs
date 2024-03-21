using System;

namespace Tetris
{
    public class BlocoQueue
    {
        private readonly Blocos[] blocos = new Blocos[]
        {
            new IBloco(),
            new JBloco(),
            new LBloco(),
            new SBlock(),
            new TBlock(),
            new ZBloco()
        };

        private readonly Random random = new Random();

        public Blocos NextBlock { get; private set;}

        public BlocoQueue()
        {
            NextBlock = RandomBlock();
        }

        private Blocos RandomBlock()
        {
            return blocos[random.Next(blocos.Length)];
        }

        public Blocos GetAndUpdate()
        {
            Blocos blocos = NextBlock;

            do
            {
                NextBlock = RandomBlock();
            }
            while (blocos.Id == NextBlock.Id);

            return blocos;
        }
    }
}
