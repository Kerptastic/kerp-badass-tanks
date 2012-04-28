using System;
using System.Collections.Generic;
using EngineCore2D.Engine;
using BadassTanksXNA.BadAssTanks_World;
using BadassTanksXNA.Utility;

namespace BadassTanksXNA
{
    /// <summary>
    /// Main entry point for the BadAssTanks game. Creates a new GameEngine
    /// and runs it.
    /// </summary>
    static class BadAssTanks
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (GameEngine2D<BadAssTanksWorld> gameEngine = new BadAssTanksGameEngine())
            {
                gameEngine.Run();
            }
        }
    }
}