using System;
using System.Collections.Generic;

namespace BadAssTanks
{
    static class BadAssTanks
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (GameEngine gEngine = GameEngine.GetInstance())
            {
                //populate the trig handlers tables
                //TrigHandler.GetInstance();

                ////load the audio
                //AudioHandler.GetInstance();

                //gEngine.InitializeInputDevices();
                //gEngine.InitializeDeviceParams(true);
                //gEngine.InitializeDirect3D();
                //gEngine.InitializeEventHandlers();
                //gEngine.InitializeTextures();

                //gEngine.SetupGame(false);
                               
                //Application.Run(gEngine);

                gEngine.Run();
            }
        }
    }
}