namespace Tetris
{
    public class  IBloco : Blocos
    {
        private readonly posicao[][] tiles = new posicao[][]
        {
            new posicao[] {new(1,0), new(1,1), new(1,2), new(1,3)},
            new posicao[]{new(0,2), new(1,2), new(2,2), new(3,2)},
            new posicao[]{new(2,0), new(2,1), new(2,2), new(2,3)},
            new posicao[]{new(0,1), new(1,1), new(2,1), new(3,1)}
        };
        public override int Id => 1;
        protected override posicao StartOffset => new posicao(-1,3);
        protected override posicao[][] Tiles => tiles;
    }
}
