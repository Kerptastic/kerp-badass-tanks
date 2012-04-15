using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace BadAssTanks
{
    /// <summary>
    /// The Game Engine to be used for BadAssTanks. Handles the Graphics Device
    /// Initialization and the creation of all the major moving parts in the engine.
    /// </summary>
    public class GameEngine : Game
    {
        /// <summary>
        /// The static instance of the Game Engine. Used for the Singleton Pattern.
        /// </summary>
        private static GameEngine _instance = null;
        /// <summary>
        /// The Graphice Device Manager for settings up the Game Window.
        /// </summary>
        private GraphicsDeviceManager _gdManager;
        /// <summary>
        /// The Sprite Batch for holding sprites to be drawn to the screen.
        /// </summary>
        private SpriteBatch _spriteBatch;
        /// <summary>
        /// The Graphics Device drawing the images to the screen.
        /// </summary>
        private GraphicsDevice _graphicsDevice;

        //private Camera m_gameCamera = null;
        //private Camera m_hudCamera = null;

        private TextureHandler _textureHandler = null;
        //private GameWorld m_world = null;
        //private ArrayList m_keys = null;

        //private KeyboardHandler m_kbHandler = null;
        //private MouseHandler m_mouseHandler = null;

        //private Size m_defaultWindowSize = new Size(700, 700);
        //private Size m_fullscreenWindowSize = new Size(1280, 1024);

        //private HeadsUpDisplay m_hud = null;
        //private PlayerData m_playerData = null;

        //private IntCoords m_windowLocation;

        //private TextSprite m_pauseSprite = null;
        //private TextSprite m_gameOverSprite = null;

        //private StartMenu m_menu = null;

        //private bool m_windowed, m_paused, m_gameStarted, m_gameOver;

        //private int bulletFireRate = 0;
        //private int missileFireRate = 0;

        //private CustomSprite _mySprite = new CustomSprite();

        /// <summary>
        /// Create the game engine.
        /// </summary>
        private GameEngine()
        {
            _gdManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Initialize();
        }

        /// <summary>
        /// Singleton accessor for the GameEngine.
        /// </summary>
        /// <returns></returns>
        public static GameEngine GetInstance()
        {
            if (_instance == null)
            {
                _instance = new GameEngine();
            }

            return _instance;
        }

        /// <summary>
        /// Initialize the graphics device and the game window setup.
        /// </summary>
        protected override void Initialize()
        {
            try
            {
                //load the game content
                this.LoadContent();
              
                //init the rest of the handlers


                //setup the screen and apply the changes
                _gdManager.PreferredBackBufferWidth = 800;
                _gdManager.PreferredBackBufferHeight = 600;
                _gdManager.IsFullScreen = false;
                _gdManager.ApplyChanges();

                Window.Title = "Bad-Ass Tanks!";
            }
            catch (Exception ex)
            {

            }

            base.Initialize();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void LoadContent()
        {
            //init the texture handler
            _textureHandler = new TextureHandler(this.Content);


            //init the sprite batch and graphics device
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _graphicsDevice = _gdManager.GraphicsDevice;

            base.LoadContent();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void UnloadContent()
        {
            base.UnloadContent(); 
        }

        /// <summary>
        /// Initialize the device parameters.
        /// </summary>
        public void InitializeDeviceParams(bool windowed)
        {
            //m_windowed = windowed;

            //m_pParams = new PresentParameters();
            //m_pParams.Windowed = m_windowed;
            //m_pParams.SwapEffect = SwapEffect.Discard;
            //m_pParams.EnableAutoDepthStencil = true;
            //m_pParams.AutoDepthStencilFormat = DepthFormat.D16;
            //m_pParams.PresentationInterval = PresentInterval.One;

            //if (m_windowed)
            //{
            //    this.ClientSize = m_defaultWindowSize;
            //    this.Size = m_defaultWindowSize;

            //    m_pParams.BackBufferWidth = m_defaultWindowSize.Width - 8;
            //    m_pParams.BackBufferHeight = m_defaultWindowSize.Height - 34;
            //    m_pParams.BackBufferFormat = Format.X8R8G8B8;
            //}
            //else
            //{
            //    this.ClientSize = m_fullscreenWindowSize;
            //    this.Size = m_fullscreenWindowSize;

            //    m_pParams.BackBufferWidth = m_fullscreenWindowSize.Width;
            //    m_pParams.BackBufferHeight = m_fullscreenWindowSize.Height;
            //    m_pParams.BackBufferFormat = Format.X8R8G8B8;
            //}
        }


        public void InitializeInputDevices()
        {
            //m_kbHandler = new KeyboardHandler(ref m_keys, KeyboardHandler.ReadMode.IMMEDIATE,
            //    KeyboardHandler.Exclusiveness.NONEXCLUSIVE, KeyboardHandler.Focus.FOREGROUND,
            //    true, 85, this);

            //m_mouseHandler = new MouseHandler(this);
        }

        /// <summary>
        /// Initialize all the textures to be used.
        /// </summary>
        public void InitializeTextures()
        {
            //m_textureHandler = TextureHandler.GetInstance();
            //m_textureHandler.SetDevice(m_device);
        }

        /// <summary>
        /// Sets up the game to it's intial state.
        /// </summary>
        public void SetupGame(bool gameStarted)
        {
            //init the camera
            //m_gameCamera = new Camera(m_device);
            //m_playerData = new PlayerData();
            //m_hudCamera = new Camera(m_device);

            //m_menu = new StartMenu(m_device);
            //m_hud = new HeadsUpDisplay(m_device, m_playerData);
            //m_world = new GameWorld(m_device, m_gameCamera, m_playerData, m_hud);

            //m_gameCamera.InitializeCamera(
            //    new Vector3((float)m_world.GetTank().GetWorldCoords().x + 2.0f, (float)m_world.GetTank().GetWorldCoords().y, -10.0f),
            //    new Vector3((float)m_world.GetTank().GetWorldCoords().x + 2.0f, (float)m_world.GetTank().GetWorldCoords().y, 0.0f),
            //    new Vector3(0.0f, 1.0f, 0.0f));

            //m_hudCamera.InitializeCamera(
            //    new Vector3(0.0f, 0.0f, -10.0f),
            //    new Vector3(0.0f, 0.0f, 0.0f),
            //    new Vector3(0.0f, 1.0f, 0.0f));

            //m_paused = false;
            //m_gameStarted = gameStarted;
            //m_gameOver = false;

            //m_pauseSprite = new TextSprite(m_device, "", new System.Drawing.Font(new FontFamily("Arial"), 24.0f), 370.0f, 260.0f, 0.0f, Color.Gold);
            //m_gameOverSprite = new TextSprite(m_device, "", new System.Drawing.Font(new FontFamily("Arial"), 24.0f), 350.0f, 260.0f, 0.0f, Color.Gold);   
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                this.Exit();
            }

            base.Update(gameTime);

            
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

        }

        /// <summary>
        /// Render the game.
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.Draw(_textureHandler.TitleBadTexture, new Rectangle(10, 10, 30, 30), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
   

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
        }
    }
}