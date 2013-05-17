// <copyright file="IRenderer.cs" company="Team Selenium">
// Team Selenium 2013 All Rights Reserved
// </copyright>
// <author>Team Selenium</author>

namespace KingSurvival
{
    using System;

    public interface IRenderer
    {
        void Render(GameState state);

        void RenderInvalidCommand();
    }
}
