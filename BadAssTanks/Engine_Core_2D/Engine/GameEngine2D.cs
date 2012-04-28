using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EngineCore2D.Engine
{
    /// <summary>
    /// A Game Engine that defines the structure and contains the common components needed
    /// to initialize, update, and render a GameWorld.  This class should be extended by a
    /// a custom GameEngine, which will define its own custom game world.
    /// 
    /// The design of this Game Engine is to be agnostic to the game that is being developed.
    /// Therefore, there should NEVER be any specific game related information placed here.
    /// The EngineCore2D Engine only will care about the class inside of it, and will call
    /// use the interface provided by those classes - relying on the implementation provided
    /// by the implementing Game class.
    /// </summary>
    public abstract class GameEngine2D<GameWorldType> : Game
    {
        #region XNA Related Objects
        /// <summary>
        /// The Graphice Device Manager for settings up the Game Window.
        /// </summary>
        protected GraphicsDeviceManager _gdManager;
        /// <summary>
        /// The Sprite Batch for holding sprites to be drawn to the screen.
        /// </summary>
        protected SpriteBatch _spriteBatch;
        /// <summary>
        /// The Graphics Device drawing the images to the screen.
        /// </summary>
        protected GraphicsDevice _graphicsDevice;
        #endregion

        #region EngineCore2D Related Objects
        /// <summary>
        /// 
        /// </summary>
        protected GameWorldType _gameWorld = default(GameWorldType);
        public GameWorldType GameWorld { get { return _gameWorld; } set { _gameWorld = value; } }
        /// <summary>
        /// 
        /// </summary>
        protected Camera2D _camera2d = null;
        public Camera2D Camera2D { get { return _camera2d; } }
        /// <summary>
        /// 
        /// </summary>
        protected Texture2DHandler _textureHandler = null;
        public Texture2DHandler TextureHandler { get { return _textureHandler; } }
        #endregion

        /// <summary>
        /// Creates a new GameEngine2D.  This needs to be implemented by a custom
        /// GameEngine and called from the constructor.
        /// </summary>
        public GameEngine2D()
        {
            this._gdManager = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Initializes the graphics device and the game window setup.
        /// 
        /// Called after GameEngine.Run() is called.
        /// </summary>
        protected override void Initialize()
        {
            //setup the screen and apply the changes
            this._gdManager.PreferredBackBufferWidth = 800;
            this._gdManager.PreferredBackBufferHeight = 600;
            this._gdManager.IsFullScreen = false;
            this._gdManager.ApplyChanges();

            this._camera2d = new Camera2D(GraphicsDevice.Viewport, new Vector2(0, 0));

            this.Window.Title = "Bad-Ass Tanks!";

            base.Initialize();
        }

        /// <summary>
        /// Initializes the SpriteBatch and keeps a local copy of the GraphicsDevice
        /// from the GraphicsDeviceManager.
        /// 
        /// This needs to be overridden ALSO by an implementing custom GameEngine, 
        /// and called BEFORE any custom initialization code is called.  This will
        /// ensure the XNA code is properly setup and completed before any loading of
        /// Game specific content is loaded.
        /// 
        /// The GameWorld should be set to a custom GameWorld in this method implemented
        /// by a custom GameEngine implementing class.
        /// 
        /// Called after GameEngine.Run() is called.
        /// </summary>
        protected override void LoadContent()
        {
            this._spriteBatch = new SpriteBatch(GraphicsDevice);
            this._graphicsDevice = _gdManager.GraphicsDevice;

            base.LoadContent();
        }

        /// <summary>
        /// Unloads all of the content for the Game.
        /// 
        /// This needs to be overridden ALSO by an implementing custom GameEngine, 
        /// and called BEFORE any custom initialization code is called.  This will
        /// ensure the XNA content can be disposed of properly first, before Game
        /// specific content is unloaded.
        /// </summary>
        protected override void UnloadContent()
        {
            base.UnloadContent(); 
        }     

        /// <summary>
        /// Updates the current state of the Game. This method will handle all input related
        /// code, and pass the information that is collected to the GameWorld.
        /// </summary>
        /// <param name="gameTime">The current GameTime.</param>
        protected override void Update(GameTime gameTime)
        {
            this._camera2d.Update();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                this.Exit();
            }

            base.Update(gameTime);

            #region old_game_render_code
            //m_kbHandler.ReadImmediateData();

            //Key currentKey;
    
            //for (int count = 0; count < m_keys.Count; count++)
            //{
            //    currentKey = (Key)m_keys[count];

            //    if (!m_paused && !m_gameOver)
            //    {
            //        float angle = 0.0f;

            //        if (m_world.GetTank() != null)
            //            angle = m_world.GetTank().GetFacingAngleInRadians();

            //        switch (currentKey)
            //        {
            //            case (Key.W): //works
            //                if (m_world.GetTank() != null)
            //                    m_world.GetTank().Move("UP", m_gameCamera);
            //                break;

            //            case (Key.S): //works
            //                if (m_world.GetTank() != null)
            //                    m_world.GetTank().Move("DOWN", m_gameCamera);
            //                break;

            //            case (Key.D): //works
            //                if (m_world.GetTank() != null)
            //                    m_world.GetTank().Rotate("RIGHT");
            //                break;

            //            case (Key.A): //works
            //                if (m_world.GetTank() != null)
            //                    m_world.GetTank().Rotate("LEFT");
            //                break;

            //            case (Key.Up):
            //                if (!m_gameStarted)
            //                {
            //                    m_menu.SelectOption(1);
            //                    break;
            //                }
            //                else
            //                    break;
            //            case (Key.Down):
            //                if (!m_gameStarted)
            //                {
            //                    m_menu.SelectOption(-1);
            //                    break;
            //                }
            //                else
            //                    break;

            //            case (Key.Return):
            //                if (!m_gameStarted)
            //                {
            //                    StartMenu.Option opt = m_menu.GetSelectedOption();

            //                    if (opt == StartMenu.Option.STARTGAME)
            //                    {
            //                        m_gameStarted = true;
            //                        AudioHandler.GetInstance().StopAudio(AudioHandler.SoundType.INTROMUSIC);
            //                    }
            //                    else if (opt == StartMenu.Option.EXIT)
            //                    {
            //                        m_keys.Clear();
            //                        this.Close();
            //                        frameOK = false;
            //                    }
            //                }

            //                break;

            //            case (Key.P):
            //                Thread.Sleep(200);
            //                m_paused = !m_paused;
            //                break;

            //            case (Key.F1):
            //                if (m_windowed)
            //                {
            //                    m_windowed = false;
            //                }
            //                else
            //                {
            //                    m_windowed = true;
            //                }

            //                this.InitializeDeviceParams(m_windowed);

            //                m_device.Reset(m_pParams);

            //                Thread.Sleep(1000);
            //                break;

            //            case (Key.Escape):
            //                m_keys.Clear();
            //                this.Close();
            //                frameOK = false;
            //                break;
            //        };
            //    }
            //    else if(m_paused && !m_gameOver)
            //    {
            //        switch (currentKey)
            //        {
            //            case (Key.P):
            //                Thread.Sleep(200);
            //                m_paused = !m_paused;
            //                break;

            //            case (Key.F1):
            //                if (m_windowed)
            //                {
            //                    m_windowed = false;
            //                }
            //                else
            //                {
            //                    m_windowed = true;
            //                }

            //                //reset the presentation params and the device
            //                this.InitializeDeviceParams(m_windowed);

            //                m_device.Reset(m_pParams);

            //                Thread.Sleep(1000);
            //                break;

            //            case (Key.Escape):
            //                m_keys.Clear();
            //                this.Close();
            //                frameOK = false;
            //                break;
            //        };
            //    }
            //    else if (m_gameOver)
            //    {
            //        switch (currentKey)
            //        {
            //            case (Key.N):
            //                m_paused = false;
            //                m_gameOver = false;

            //                this.SetupGame(true);

            //                break;
            //            case (Key.Escape):
            //                m_paused = false;
            //                m_gameOver = false;

            //                this.SetupGame(true);

            //                //m_keys.Clear();
            //                //this.Close();
            //                //frameOK = false;
            //                break;
            //        };
            //    }

            //    m_keys.Remove(currentKey);
            //}

            //byte[] clicks = m_mouseHandler.ProcessMouse();
            //IntCoords coords = m_mouseHandler.GetCoordsInWindow();

            ////set the mouse coordinates
            //m_mouseHandler.GetCoordsOnScreen();

            ////mouse is dealing with relative coords to its last position.
            ////need to keep track of position on our own

            //GameEngine gEngine = GameEngine.GetInstance();

            //GameEngine.IntCoords windowCoords = gEngine.GetMouseHandler().GetCoordsInWindow();
            //Size screenSize = gEngine.GetWindowSize();

            //if (m_gameStarted)
            //{
            //    float xOffset = (float)(windowCoords.x - ((screenSize.Width - 4) / 2) - 90.0f);
            //    float yOffset = ((windowCoords.y - (screenSize.Height / 2) - 17) * -1);

            //    float hyp = (float)Math.Sqrt((yOffset * yOffset) + (xOffset * xOffset));

            //    float a = (float)Math.Asin(((double)xOffset / hyp));
            //    float degrees = a * 180.0f / (float)Math.PI;

            //    if (xOffset > 0.0f && yOffset > 0.0f)
            //    {
            //        degrees = degrees * -1.0f;
            //    }
            //    else if (xOffset < 0.0f && yOffset > 0.0f)
            //    {
            //        degrees = degrees * -1.0f;
            //    }
            //    else if (xOffset < 0.0f && yOffset < 0.0f)
            //    {
            //        degrees = degrees + 180.0f;
            //    }
            //    else if (xOffset > 0.0f && yOffset < 0.0f)
            //    {
            //        degrees = degrees + 180.0f;
            //    }

            //    //rotate the turret
            //    if (m_world.GetTank() != null)
            //    {
            //        m_world.GetTank().RotateGundam(degrees);

            //        //shoot the laser -- 1 and 2 are pressed
            //        if (clicks != null && clicks[0] != 0 && clicks[1] != 0)
            //        {
            //            if (m_playerData.LaserReady())
            //            {
            //                m_world.RegisterObject(((WorldObject)m_world.GetTank().FireWeapon("LASER")[0]), GameWorld.WorldObjectType.LASER);
            //            }
            //        }

            //        //shoot bullets -- 1 is pressed
            //        else if (clicks != null && clicks[0] != 0)
            //        {
            //            if (m_playerData.HasRapidFire())
            //            {
            //                if (bulletFireRate >= 5)
            //                {
            //                    if (m_world.GetTank() != null)
            //                    {
            //                        ArrayList bulletList = m_world.GetTank().FireWeapon("BULLET");

            //                        for (int bulletIndex = 0; bulletIndex < bulletList.Count; bulletIndex++)
            //                        {
            //                            m_world.RegisterObject(((WorldObject)bulletList[bulletIndex]), GameWorld.WorldObjectType.TANKMUNITION);
            //                        }
            //                    }

            //                    bulletFireRate = 0;
            //                }
            //                bulletFireRate++;
            //            }
            //            else
            //            {
            //                if (bulletFireRate >= 15)
            //                {
            //                    if (m_world.GetTank() != null)
            //                    {
            //                        ArrayList bulletList = m_world.GetTank().FireWeapon("BULLET");

            //                        for (int bulletIndex = 0; bulletIndex < bulletList.Count; bulletIndex++)
            //                        {
            //                            m_world.RegisterObject(((WorldObject)bulletList[bulletIndex]), GameWorld.WorldObjectType.TANKMUNITION);
            //                        }                               
            //                    }
            //                    bulletFireRate = 0;
            //                }
            //                bulletFireRate++;
            //            }
            //        }

            //        //shoot missiles -- 2 is pressed
            //        else if (clicks != null && clicks[1] != 0)
            //        {

            //            if (missileFireRate >= 30)
            //            {
            //                if (m_world.GetTank() != null)
            //                {
            //                    ArrayList missileList = null;

            //                    if (m_playerData.HasVolley())
            //                        missileList = m_world.GetTank().FireWeapon("VOLLEYMISSILE");
            //                    else
            //                        missileList = m_world.GetTank().FireWeapon("MISSILE");

            //                    for (int missileIndex = 0; missileIndex < missileList.Count; missileIndex++)
            //                    {
            //                        m_world.RegisterObject(((WorldObject)missileList[missileIndex]), GameWorld.WorldObjectType.TANKMUNITION);
            //                    }
            //                }

            //                missileFireRate = 0;
            //            }
            //            missileFireRate++;
            //        }
            //    }
            //}
            #endregion
        }

        /// <summary>
        /// Draws the game.  Simply calls Draw on the GameWorld.
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            base.Draw(gameTime);

            #region old_game_render_code
            //try
            //{
            //    m_device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.Black, 1.0f, 0);

            //    if (m_gameStarted)
            //    {
            //        int width = 875;
            //        int height = 700;

            //        Viewport leftViewPort = new Viewport();

            //        leftViewPort.X = 0; leftViewPort.Y = 0;
            //        leftViewPort.Width = width - height; leftViewPort.Height = height;
            //        leftViewPort.MinZ = 0.0f; leftViewPort.MaxZ = 1.0f;

            //        m_device.Viewport = leftViewPort;

            //        m_device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.Black, 1.0f, 0);

            //        m_hudCamera.ResetCamera();

            //        m_device.BeginScene();
            //        beginSceneCalled = true;

            //        m_hud.RenderHUD(this.Width, this.Height);

            //        if (beginSceneCalled)
            //        {
            //            m_device.EndScene();
            //        }

            //        Viewport rightViewPort = new Viewport();

            //        rightViewPort.X = width - height; leftViewPort.Y = 0;
            //        rightViewPort.Width = width - (width - height); rightViewPort.Height = height;
            //        rightViewPort.MinZ = 0.0f; rightViewPort.MaxZ = 1.0f;

            //        m_device.Viewport = rightViewPort;

            //        m_device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.Black, 1.0f, 0);

            //        m_gameCamera.ResetCamera();

            //        m_device.BeginScene();
            //        beginSceneCalled = true;

            //        if (m_gameOver)
            //        {
            //            m_paused = true;
            //            m_gameOverSprite.SetText("GAME OVER\n\n\nN: New Game \nESC: Exit");
            //            m_gameOverSprite.Render();
            //        }
            //        else if (!m_paused)
            //        {
            //            m_gameOver = m_world.RenderWorld();
            //        }
            //        else
            //        {
            //            m_pauseSprite.SetText("PAUSE");
            //            m_pauseSprite.Render();
            //        }
            //    }
            //    else
            //    {
            //        m_hudCamera.ResetCamera();

            //        m_device.BeginScene();
            //        beginSceneCalled = true;

            //        m_menu.RenderTitle();
            //    }


            //    if (beginSceneCalled)
            //        m_device.EndScene();

            //}
            //finally
            //{
            //    m_device.Present();
            //}

            #endregion
        }
    }
}