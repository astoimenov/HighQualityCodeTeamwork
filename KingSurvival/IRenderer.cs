using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival
{
    public interface IRenderer
    {
        void Render(GameState state);

        void RenderInvalidCommand();
    }
}
