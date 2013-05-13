namespace KingSurvival
{
    using System;

    public class GameOverEventArgs : EventArgs
    {
        public GameOverEventArgs(GameState gameState)
            : base()
        {
            this.GameState = gameState;
        }

        public GameState GameState { get; private set; }
    }
}
