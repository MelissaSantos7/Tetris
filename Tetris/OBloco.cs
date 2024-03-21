namespace Tetris
{
    public class OBloco : Blocos
    {
        private readonly posicao[][] tiles = new posicao[][]
        {
            new posicao[] {new posicao(0,0), new(0,1), new(1,0), new (1,1)}
        };

        public override int Id => 4;
        protected override posicao StartOffset => new posicao(0,4);
        protected override posicao[][] Tiles => tiles;
    }
}
