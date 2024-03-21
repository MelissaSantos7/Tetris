﻿namespace Tetris
{
    public class LBloco : Blocos
    {
        public override int Id => 3;
        protected override posicao StartOffset => new posicao(0, 3);

        private readonly posicao[][] tiles = new posicao[][]
        {
            new posicao[] {new(0,2),new(1,0),new(1,1), new(1,2)},
            new posicao[]{new(0,1), new(1,1), new(2,1), new(2,2) },
            new posicao[]{new(1,0), new(1,1), new(1,2), new(2,0) },
            new posicao[]{new(0,0), new(0,1),new(1,1),new(2,1) }
        }; 
        protected override posicao[][] Tiles => tiles;
    }
}
