namespace KingSurvival
{
    using System;

    public interface IRenderer
    {
        void Render(GameState state);

        void RenderInvalidCommand();
    }
}
