using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Tetris
{
    public class TBlock : Blocos
    {
        public override int Id => 6;

        protected override posicao StartOffset => new(0, 3);

        protected override posicao[][] Tiles => new posicao[][] {
            new posicao[] {new(0,1), new(1,0), new(1,1), new(1,2)},
            new posicao[] {new(0,1), new(1,1), new(1,2), new(2,1)},
            new posicao[] {new(1,0), new(1,1), new(1,2), new(2,1)},
            new posicao[] {new(0,1), new(1,0), new(1,1), new(2,1)}
        };
    }
}

