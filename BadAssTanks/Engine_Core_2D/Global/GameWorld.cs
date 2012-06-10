using KerpEngine.Engine_2D.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using KerpEngine.Engine_2D;
using KerpEngine.Engine_3D;

namespace KerpEngine.Global
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class GameWorld
    {
        protected Viewport _viewport;
        
        /// <summary>
        /// 
        /// </summary>
        protected TextureHandler _textureHandler;
        public TextureHandler TextureHandler { get { return _textureHandler; } }
        /// <summary>
        /// 
        /// </summary>
        protected ModelHandler _modelHandler = null;
        public ModelHandler ModelHandler { get { return _modelHandler; } }


        /// <summary>
        /// 
        /// </summary>
        protected QuadTree _quadTree;
        public QuadTree QuadTree { get { return _quadTree; } }

        public GameWorld(TextureHandler textureHandler, ModelHandler modelHandler, Viewport viewport)
        {
            _textureHandler = textureHandler;
            _modelHandler = modelHandler;
            _viewport = viewport;

            _quadTree = new QuadTree(0, 0, 20, 20);
            _quadTree.Divide();
        }

        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);
        public abstract void Draw(GraphicsDevice device, BasicEffect effect, Matrix viewMatrix, Matrix projectionMatrix, GameTime gameTime);

        #region BadAssTanks World Code
        //public enum WorldObjectType
        //{
        //    TANKMUNITION, ENEMY, ENEMYMUNITION, EXPLOSION,
        //    VOLLEYUPGRADE, RAPIDFIREUPGRADE, LASER
        //}

        //private Device m_device;
        //public static Camera m_camera;

        //private GameEngine.IntCoords m_tankWorldStartLocation;

        //public const int m_worldWidth = 37;
        //public const int m_worldHeight = 128;

        //private const int m_drawWidth = 20;
        //private const int m_drawHeight = 13;

        //private const int RAPIDFIREKILLCOUNT = 12;
        //private const int VOLLEYKILLCOUNT = 25;

        //private HeadsUpDisplay m_hud = null;

        //private ArrayList m_level = new ArrayList();

        //private ArrayList m_AnimatedTileList = new ArrayList();
        //private ArrayList m_UnanimatedTileList = new ArrayList();

        //private ArrayList m_UnpassableTileCoords = new ArrayList();

        //private WorldTile[,] m_worldTiles = null;
        //private BoundingShape2D[,] m_boundingBoxes = null;

        //private ArrayList m_enemies = new ArrayList();
        //private ArrayList m_tankMunitions = new ArrayList();
        //private ArrayList m_enemyMunitions = new ArrayList();
        //private ArrayList m_explosions = new ArrayList();
        //private ArrayList m_upgrades = new ArrayList();

        //private EnemyFactory m_enemyFactory = null;

        //private Tank m_tank = null;
        //private BossBot m_bossBot = null;
        //private PlayerData m_playerData = null;
        //private Laser m_laser = null;

        //private bool m_tankDestroyed;
        //private bool m_tankInvincible;
        //private bool m_laserFiring = false;

        //private int m_invincibleTintCount = 0;

        //private float m_tankDeadTimestamp = 0.0f;
        //private float m_tankInvincibleTimestamp = 0.0f;

        //private int m_enemyCount = 0;

        //private TextSprite m_text = null;

        //private CustomSprite m_volleyUpgradeSprite = null;
        //private CustomSprite m_rapidFireUpgradeSprite = null;

        //private Upgrade m_volleyUpgrade = null;
        //private Upgrade m_rapidFireUpgrade = null;

        //private const int m_maxEnemies = 5;

        ///// <summary>
        ///// Creates the game world
        ///// </summary>
        ///// <param name="device"> Reference to the linked Direct3D device for rendering. </param>
        ///// <param name="camera"> Camera linked to the game world. </param>
        //public GameWorld(Device device, Camera camera, PlayerData playerData, HeadsUpDisplay hud)
        //{
        //    m_device = device;
        //    m_camera = camera;
        //    m_playerData = playerData;
        //    m_hud = hud;

        //    m_text = new TextSprite(m_device, "", new System.Drawing.Font(new FontFamily("Times New Roman"), 10.0f), 200.0f, 20.0f, 0.0f, Color.White);

        //    m_worldTiles = new WorldTile[m_worldWidth, m_worldHeight];
        //    m_boundingBoxes = new BoundingShape2D[m_worldWidth, m_worldHeight];

        //    m_enemyFactory = new EnemyFactory(device);

        //    m_tankWorldStartLocation.x = 18;
        //    m_tankWorldStartLocation.y = 13;

        //    m_tankDestroyed = false;
        //    m_tankInvincible = false;

        //    this.ReadInLevel(@"..\..\..\Level Files\finalLevel.txt");
        //    this.InitializePermaObjects();
        //    this.LoadTiles();
        //    this.LoadEnemies();
        //}

        ///// <summary>
        ///// Reads a level file into a string array list.
        ///// </summary>

        //private void ReadInLevel(String fileName)
        //{
        //    TextReader TR = new StreamReader(fileName);

        //    String tempLine = TR.ReadLine();
        //    String tempString;

        //    int index;
        //    int startIndex = 0;

        //    while (tempLine != null)
        //    {
        //        startIndex = 0;

        //        for (index = 1; index < tempLine.Length; index++)
        //        {
        //            if (tempLine[index] == 'U' || tempLine[index] == 'A')
        //            {
        //                tempString = tempLine.Substring(startIndex, (index - startIndex));
        //                startIndex = index;
        //                m_level.Add(tempString);
        //            }
        //        }

        //        tempString = tempLine.Substring(startIndex, (index - startIndex));
        //        m_level.Add(tempString);

        //        tempLine = TR.ReadLine();
        //    }
        //}

        ///// <summary>
        ///// Loads the tiles into the world.
        ///// </summary>
        //private void LoadTiles()
        //{
        //    foreach (ArrayList textureList in TextureHandler.GetInstance().GetAnimatedTextures())
        //    {
        //        m_AnimatedTileList.Add(new WorldTile(new AnimatedSprite(m_device, textureList, 0.0f, 0.0f, 0.0f, 90)));
        //    }

        //    foreach (Texture texture in TextureHandler.GetInstance().GetTextures())
        //    {
        //        m_UnanimatedTileList.Add(new WorldTile(new UnanimatedSprite(m_device, texture, 0, 0.0f, 0.0f)));
        //    }

        //    int col = 0;
        //    int row = 0;

        //    String animated;
        //    String passable;
        //    String arrayIndex;

        //    foreach (String S in m_level)
        //    {
        //        animated = "" + S[0];
        //        passable = "" + S[1];
        //        arrayIndex = S.Substring(2);

        //        if (animated == "U")
        //        {
        //            m_worldTiles[row, col] = (WorldTile)m_UnanimatedTileList[Int32.Parse(arrayIndex)];
        //        }
        //        if (animated == "A")
        //        {
        //            m_worldTiles[row, col] = (WorldTile)m_AnimatedTileList[Int32.Parse(arrayIndex)];
        //        }

        //        if (arrayIndex == "46")
        //            RegisterObject(m_enemyFactory.CreateEnemy(EnemyFactory.EnemyType.TURRET, row, col), WorldObjectType.ENEMY);

        //        List<MathHandler> m_points = new List<MathHandler>();

        //        m_points.Add(new MathHandler(-0.5f, 0.5f));
        //        m_points.Add(new MathHandler(0.5f, 0.5f));
        //        m_points.Add(new MathHandler(0.5f, -0.5f));
        //        m_points.Add(new MathHandler(-0.5f, -0.5f));

        //        if (passable == "0")
        //        {
        //            m_boundingBoxes[row, col] = new BoundingShape2D(m_points);
        //            m_boundingBoxes[row, col].Translate(new MathHandler(row, col));
        //            m_tank.SetUnpassableCoords(row, col);
        //        }

        //        row++;

        //        if (row == m_worldWidth)
        //        {
        //            col++;
        //            row = 0;
        //        }
        //    }
        //}

        //private void LoadEnemies()
        //{
        //    Random rand = new Random((int)GameTimer.timeGetTime());
        //    GameEngine.IntCoords currentCoords = m_tank.GetWorldCoords();
        //    GameEngine.IntCoords spawnCoords = currentCoords;

        //    spawnCoords.x = currentCoords.x + rand.Next(-4, 4);
        //    spawnCoords.y = currentCoords.y + 8;

        //    while (m_UnpassableTileCoords.Contains(spawnCoords))
        //    {
        //        spawnCoords.x = currentCoords.x + rand.Next(-4, 4);
        //        spawnCoords.y = currentCoords.y + 8;
        //    }

        //    int randomNumber = rand.Next(20);

        //    if (randomNumber > 5)
        //    {
        //        if (spawnCoords.x > 0 && spawnCoords.y > 0 && spawnCoords.x < m_worldWidth && spawnCoords.y < m_worldHeight)
        //        {
        //            RegisterObject(m_enemyFactory.CreateEnemy(EnemyFactory.EnemyType.ROBOWALKER, spawnCoords.x, spawnCoords.y), WorldObjectType.ENEMY);
        //        }
        //    }
        //    if (randomNumber > 15)
        //    {
        //        if (spawnCoords.x > 0 && spawnCoords.y > 0 && spawnCoords.x < m_worldWidth && spawnCoords.y < m_worldHeight)
        //        {
        //            RegisterObject(m_enemyFactory.CreateEnemy(EnemyFactory.EnemyType.TANK, spawnCoords.x, spawnCoords.y), WorldObjectType.ENEMY);
        //        }
        //    }
        //}

        //private void InitializePermaObjects()
        //{
        //    m_tank = new Tank(m_device, m_tankWorldStartLocation.x, m_tankWorldStartLocation.y, 0.09f, 0.0f, Tank.TankColor.CAMO);
        //    m_bossBot = new BossBot(m_device, 18, 125);

        //    m_volleyUpgradeSprite = new UnanimatedSprite(m_device, ((Texture)(TextureHandler.GetInstance().GetUpgrades())[0]), 0.0f, 0.0f, 0.0f);
        //    m_rapidFireUpgradeSprite = new UnanimatedSprite(m_device, ((Texture)(TextureHandler.GetInstance().GetUpgrades())[1]), 0.0f, 0.0f, 0.0f);

        //    m_volleyUpgrade = new Upgrade(m_device, m_volleyUpgradeSprite, WorldObjectType.VOLLEYUPGRADE);
        //    m_rapidFireUpgrade = new Upgrade(m_device, m_rapidFireUpgradeSprite, WorldObjectType.RAPIDFIREUPGRADE);
        //}

        //public void RegisterObject(WorldObject obj, WorldObjectType objectType)
        //{
        //    if (obj != null)
        //    {
        //        if (objectType == WorldObjectType.ENEMY)
        //        {
        //            m_enemies.Add(obj);
        //            if (obj.GetType() != typeof(Turret))
        //                m_enemyCount++;
        //        }
        //        else if (objectType == WorldObjectType.ENEMYMUNITION)
        //        {
        //            m_enemyMunitions.Add(obj);
        //        }
        //        else if (objectType == WorldObjectType.TANKMUNITION)
        //        {
        //            m_tankMunitions.Add(obj);
        //        }
        //        else if (objectType == WorldObjectType.LASER)
        //        {
        //            m_laser = (Laser)obj;
        //        }
        //        else if (objectType == WorldObjectType.EXPLOSION)
        //        {
        //            AudioHandler.GetInstance().PlayAudio(AudioHandler.SoundType.EXPLOSION1);
        //            m_explosions.Add(obj);
        //        }
        //        else if (objectType == WorldObjectType.VOLLEYUPGRADE)
        //        {
        //            m_upgrades.Add(obj);
        //        }
        //        else if (objectType == WorldObjectType.RAPIDFIREUPGRADE)
        //        {
        //            m_upgrades.Add(obj);
        //        }
        //    }
        //}

        //public Tank GetTank()
        //{
        //    if (!m_tankDestroyed)
        //        return m_tank;
        //    else
        //        return null;
        //}

        ///// <summary>
        ///// Renders the world.
        ///// </summary>
        //public bool RenderWorld()
        //{
        //    bool gameOver = false;

        //    GameEngine.FloatCoords tankPos = m_tank.GetTileCoords();
        //    GameEngine.IntCoords tankLoc = m_tank.GetWorldCoords();

        //    //set row and col start point

        //    int colMin = tankLoc.y - (m_drawWidth / 2);
        //    int colMax = tankLoc.y + (m_drawWidth / 2);

        //    int rowMin = tankLoc.x - (m_drawHeight / 2);
        //    int rowMax = tankLoc.x + (m_drawHeight / 2);

        //    if (rowMin < 0)
        //        rowMin = 0;
        //    if (rowMax >= m_worldWidth)
        //        rowMax = m_worldWidth - 1;

        //    if (colMin < 0)
        //        colMin = 0;
        //    if (colMax >= m_worldHeight)
        //        colMax = m_worldHeight - 1;

        //    //******************* RENDER WORLD ***********************

        //    Matrix saved = m_device.Transform.World;

        //    for (int colCount = rowMin; colCount <= rowMax; colCount++)
        //    {
        //        for (int rowCount = colMin; rowCount <= colMax; rowCount++)
        //        {
        //            m_worldTiles[colCount, rowCount].SetLocation(colCount, rowCount);

        //            m_device.Transform.World =
        //                Matrix.Scaling(new Vector3(0.5f, 0.5f, 0.0f)) *
        //                Matrix.Translation(colCount, rowCount, 0.0f);

        //            m_worldTiles[colCount, rowCount].Render();
        //        }
        //    }

        //    m_device.Transform.World = saved;

        //    gameOver = DetectCollisions(rowMin, rowMax, colMin, colMax);
        //    RespondToCollisions();
        //    //render enemies
        //    for (int enemies = 0; enemies < m_enemies.Count; enemies++)
        //    {
        //        WorldObject enemy = (WorldObject)m_enemies[enemies];

        //        int xdif = enemy.GetWorldCoords().x - m_tank.GetWorldCoords().x;
        //        int ydif = enemy.GetWorldCoords().y - m_tank.GetWorldCoords().y;

        //        double distance = Math.Sqrt(Math.Pow((double)xdif, 2) + Math.Pow((double)ydif, 2));

        //        if (enemy.ReadyToFire() && distance < 10.0)
        //        {
        //            RegisterObject(((WorldObject)enemy.FireWeapon("BULLET")[0]), WorldObjectType.ENEMYMUNITION);
        //        }
        //        enemy.Move(m_tank);
        //        enemy.Render();
        //        enemy.Tint(Color.White);

        //        if (enemy.GetType() == typeof(Turret) && enemy.GetWorldCoords().y <= (m_tank.GetWorldCoords().y - 9))
        //        {
        //            m_enemies.Remove(enemy);
        //            enemy.Destroy();
        //            m_enemyCount--;
        //        }
        //    }

        //    if (m_tank.GetWorldCoords().y <= 100)
        //    {
        //        if (m_enemyCount < m_maxEnemies)
        //            LoadEnemies();
        //    }
        //    else
        //    {
        //        if (m_bossBot != null)
        //        {
        //            if (m_bossBot.ReadyToFire())
        //            {
        //                RegisterObject(((WorldObject)m_bossBot.FireWeapon("MISSILE")[0]), WorldObjectType.ENEMYMUNITION);

        //                RegisterObject(((WorldObject)m_bossBot.FireWeapon("MISSILE")[1]), WorldObjectType.ENEMYMUNITION);

        //                RegisterObject(((WorldObject)m_bossBot.FireWeapon("MISSILE")[2]), WorldObjectType.ENEMYMUNITION);
        //            }

        //            if (m_bossBot.TurretsReadyToFire())
        //            {
        //                RegisterObject(((WorldObject)m_bossBot.FireTurrets()[0]), WorldObjectType.ENEMYMUNITION);
        //                RegisterObject(((WorldObject)m_bossBot.FireTurrets()[1]), WorldObjectType.ENEMYMUNITION);
        //            }

        //            if (m_bossBot.ReadyToSpawn())
        //            {
        //                RegisterObject(new RoboWalker(m_device, m_bossBot.GetWorldCoords().x + 2, m_bossBot.GetWorldCoords().y - 1), WorldObjectType.ENEMY);
        //                RegisterObject(new RoboWalker(m_device, m_bossBot.GetWorldCoords().x - 2, m_bossBot.GetWorldCoords().y - 1), WorldObjectType.ENEMY);
        //            }
        //            m_bossBot.Move(m_tank);
        //            m_bossBot.Render();
        //        }
        //    }

        //    //render tank munitions
        //    for (int tankMunitionCount = 0; tankMunitionCount < m_tankMunitions.Count; tankMunitionCount++)
        //    {
        //        WorldObject tankMunition = (WorldObject)m_tankMunitions[tankMunitionCount];

        //        tankMunition.Move(m_tank.GetGundamFacingAngle());
        //        tankMunition.Render();
        //    }

        //    //render enemy munitions
        //    for (int enemyMunitionCount = 0; enemyMunitionCount < m_enemyMunitions.Count; enemyMunitionCount++)
        //    {
        //        WorldObject enemyMunition = (WorldObject)m_enemyMunitions[enemyMunitionCount];

        //        enemyMunition.Move(m_tank.GetGundamFacingAngle());
        //        enemyMunition.Render();
        //    }

        //    //render the tank
        //    if (!m_tankDestroyed)
        //    {
        //        uint currentTime = GameTimer.timeGetTime();

        //        float deltaTime = currentTime - m_tankInvincibleTimestamp;

        //        if (deltaTime >= 2000.0f)
        //            m_tankInvincible = false;

        //        m_tank.Render();

        //        if (!m_tankInvincible)
        //            m_tank.Tint(Color.White);
        //    }
        //    else
        //    {
        //        uint currentTime = GameTimer.timeGetTime();

        //        float deltaTime = currentTime - m_tankDeadTimestamp;
        //        m_tankInvincible = true;

        //        if (deltaTime >= 3500.0f)
        //        {
        //            m_tankDestroyed = false;
        //            m_tankInvincibleTimestamp = currentTime;
        //        }
        //    }

        //    if (m_tankInvincible)
        //    {
        //        if (m_invincibleTintCount == 0)
        //        {
        //            m_tank.Tint(Color.Yellow);
        //            m_invincibleTintCount++;
        //        }
        //        else if (m_invincibleTintCount == 1)
        //        {
        //            m_tank.Tint(Color.Red);
        //            m_invincibleTintCount++;
        //        }
        //        else if (m_invincibleTintCount == 2)
        //        {
        //            m_tank.Tint(Color.Yellow);
        //            m_invincibleTintCount = 0;
        //        }
        //    }

        //    //render laser
        //    if (m_laser != null && m_playerData.LaserPower() > 0)
        //    {
        //        m_laserFiring = true;

        //        m_playerData.ReduceBeam(.075f);
        //        m_laser.Move(m_tank.GetGundamFacingAngle());
        //        m_laser.Render();

        //    }
        //    else
        //    {
        //        m_laserFiring = false;

        //        if (m_laser != null)
        //        {
        //            m_laser.Destroy();
        //            m_laser = null;
        //        }
        //    }

        //    //render explosions
        //    for (int explosionCount = 0; explosionCount < m_explosions.Count; explosionCount++)
        //    {
        //        WorldObject explosion = (WorldObject)m_explosions[explosionCount];

        //        if (!explosion.IsDestroyed())
        //        {
        //            explosion.Render();
        //        }
        //        else
        //        {
        //            m_explosions.Remove(explosion);
        //        }
        //    }

        //    return gameOver;
        //}

        //private bool DetectCollisions(int rowMin, int rowMax, int colMin, int colMax)
        //{
        //    bool gameOver = false;

        //    /******************************************************
        //     * COLLISION TEST 1 - TANK MUNITIONS to ENEMIES
        //     ******************************************************/
        //    for (int tankMunitionCount = 0; tankMunitionCount < m_tankMunitions.Count; tankMunitionCount++)
        //    {
        //        WorldObject tankMunition = (WorldObject)m_tankMunitions[tankMunitionCount];

        //        if (tankMunition.IsDestroyed())
        //        {
        //            if (tankMunition.GetType() != typeof(Bullet))
        //                RegisterObject(new Explosion(m_device, tankMunition.GetWorldCoords().x, tankMunition.GetWorldCoords().y,
        //                    tankMunition.GetTileCoords().x, tankMunition.GetTileCoords().y), WorldObjectType.EXPLOSION);

        //            m_tankMunitions.Remove(tankMunition);
        //            continue;
        //        }

        //        for (int enemyCount = 0; enemyCount < m_enemies.Count; enemyCount++)
        //        {
        //            WorldObject enemy = (WorldObject)m_enemies[enemyCount];

        //            double munitionX = tankMunition.GetWorldCoords().x + tankMunition.GetTileCoords().x;
        //            double munitionY = tankMunition.GetWorldCoords().y + tankMunition.GetTileCoords().y;

        //            double enemyX = enemy.GetWorldCoords().x + enemy.GetTileCoords().x;
        //            double enemyY = enemy.GetWorldCoords().y + enemy.GetTileCoords().y;

        //            double x = munitionX - enemyX;
        //            double y = munitionY - enemyY;

        //            double distance = Math.Sqrt((x * x) + (y * y));

        //            if (distance <= 2.00)
        //            {
        //                bool result = CollisionHandler.GetInstance().CheckOABBIntersection(tankMunition.GetBoundingShape(), enemy.GetBoundingShape());

        //                if (result)
        //                {
        //                    RegisterObject(new Explosion(m_device, tankMunition.GetWorldCoords().x, tankMunition.GetWorldCoords().y,
        //                                                        tankMunition.GetTileCoords().x, tankMunition.GetTileCoords().y), WorldObjectType.EXPLOSION);
        //                    enemy.Tint(Color.Red);

        //                    if (enemy.ReduceHealth(tankMunition.GetCrashDamage()))
        //                    {
        //                        m_playerData.IncreaseScore(enemy.GetPointValue(), m_laserFiring);
        //                        m_playerData.IncreaseKills();

        //                        if (enemy.GetType() != typeof(Turret))
        //                        {
        //                            m_enemyCount--;
        //                        }
        //                        else
        //                        {
        //                            //Redraw the tile the turret sits on
        //                            int row = enemy.GetWorldCoords().x;
        //                            int col = enemy.GetWorldCoords().y;

        //                            Texture SE = TextureLoader.FromFile(m_device, @"..\Images\Unanimated\48bunkerSE.png");
        //                            Texture SW = TextureLoader.FromFile(m_device, @"..\Images\Unanimated\47bunkerSW.png");
        //                            Texture NE = TextureLoader.FromFile(m_device, @"..\Images\Unanimated\46bunkerNE.png");
        //                            Texture NW = TextureLoader.FromFile(m_device, @"..\Images\Unanimated\45bunkerNW.png");

        //                            m_worldTiles[row, col] = new WorldTile(new UnanimatedSprite(m_device, SW, 0, 0.0f, 0.0f));
        //                            m_worldTiles[row + 1, col] = new WorldTile(new UnanimatedSprite(m_device, SE, 0, 0.0f, 0.0f));
        //                            m_worldTiles[row, col + 1] = new WorldTile(new UnanimatedSprite(m_device, NW, 0, 0.0f, 0.0f));
        //                            m_worldTiles[row + 1, col + 1] = new WorldTile(new UnanimatedSprite(m_device, NE, 0, 0.0f, 0.0f));
        //                        }

        //                        enemy.Destroy();
        //                        m_enemies.Remove(enemy);

        //                        //display a resulting explosion
        //                        for (int index = 0; index < 5; index++)
        //                        {
        //                            Random rand = new Random((int)GameTimer.timeGetTime());
        //                            float randOffset = (rand.Next(1000)) / 3000.0f;
        //                            RegisterObject(new Explosion(m_device, enemy.GetWorldCoords().x, enemy.GetWorldCoords().y,
        //                                                            (enemy.GetTileCoords().x + randOffset), (enemy.GetTileCoords().y - randOffset)), WorldObjectType.EXPLOSION);
        //                            if (index > 2)
        //                            {
        //                                RegisterObject(new Explosion(m_device, enemy.GetWorldCoords().x, enemy.GetWorldCoords().y,
        //                                                                (enemy.GetTileCoords().x + randOffset), enemy.GetTileCoords().y), WorldObjectType.EXPLOSION);
        //                            }
        //                        }
        //                    }

        //                    m_tankMunitions.Remove(tankMunition);
        //                    tankMunition.Destroy();
        //                    break;
        //                }
        //            }
        //        }
        //    }

        //    /******************************************************
        //     * COLLISION TEST 2 - TANK to ENEMIES
        //     ******************************************************/
        //    if (!m_tankDestroyed)
        //    {
        //        for (int enemyCount = 0; enemyCount < m_enemies.Count; enemyCount++)
        //        {
        //            WorldObject enemy = (WorldObject)m_enemies[enemyCount];

        //            double tankX = m_tank.GetWorldCoords().x + m_tank.GetTileCoords().x;
        //            double tankY = m_tank.GetWorldCoords().y + m_tank.GetTileCoords().y;

        //            double enemyX = enemy.GetWorldCoords().x + enemy.GetTileCoords().x;
        //            double enemyY = enemy.GetWorldCoords().y + enemy.GetTileCoords().y;

        //            double x = tankX - enemyX;
        //            double y = tankY - enemyY;

        //            double distance = Math.Sqrt((x * x) + (y * y));

        //            if (distance <= 1.75)
        //            {
        //                bool result = CollisionHandler.GetInstance().CheckOABBIntersection(m_tank.GetBoundingShape(), enemy.GetBoundingShape());

        //                int healthBefore = m_playerData.GetHealth();

        //                if (result)
        //                {
        //                    m_tank.Tint(Color.Red);

        //                    bool blowUpTank = false;

        //                    if (m_tankInvincible)
        //                    {
        //                        blowUpTank = m_playerData.DecreaseHealth(0);
        //                    }
        //                    else
        //                    {
        //                        blowUpTank = m_playerData.DecreaseHealth(enemy.GetCrashDamage());
        //                    }

        //                    GameEngine.IntCoords coords = m_tank.GetWorldCoords();

        //                    if (blowUpTank)
        //                    {
        //                        m_tankDestroyed = true;
        //                        m_tankDeadTimestamp = GameTimer.timeGetTime();
        //                        m_playerData.ZeroOutData();

        //                        m_hud.ReduceDamage();

        //                        if (m_playerData.GetLivesRemaining() == 0 && m_playerData.GetHealth() == 0)
        //                        {
        //                            gameOver = true;
        //                            return gameOver;
        //                        }
                               
        //                        for (int index = 0; index < 5; index++)
        //                        {
        //                            Random rand = new Random((int)GameTimer.timeGetTime());

        //                            float randOffset = (rand.Next(1000)) / 3000.0f;

        //                            RegisterObject(new Explosion(m_device, m_tank.GetWorldCoords().x, m_tank.GetWorldCoords().y,
        //                                                            (m_tank.GetTileCoords().x + randOffset), (m_tank.GetTileCoords().y - randOffset)), WorldObjectType.EXPLOSION);
        //                            if (index > 2)
        //                            {
        //                                RegisterObject(new Explosion(m_device, m_tank.GetWorldCoords().x, m_tank.GetWorldCoords().y,
        //                                                                (m_tank.GetTileCoords().x + randOffset), m_tank.GetTileCoords().y), WorldObjectType.EXPLOSION);
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        m_playerData.IncreaseKills();

                                
        //                        int depleted = healthBefore - m_playerData.GetHealth();
        //                        int damages = depleted / 5;

        //                        for(int doDamage = 0; doDamage < damages; doDamage++)
        //                            m_hud.DoDamage();
        //                    }

        //                    m_playerData.IncreaseScore(enemy.GetPointValue(), m_laserFiring);

        //                    if(enemy.GetType() != typeof(Turret))
        //                        m_enemyCount--;

        //                    enemy.Destroy();
        //                    m_enemies.Remove(enemy);

        //                    for (int index = 0; index < 5; index++)
        //                    {
        //                        Random rand = new Random((int)GameTimer.timeGetTime());
        //                        float randOffset = (rand.Next(1000)) / 3000.0f;
        //                        RegisterObject(new Explosion(m_device, enemy.GetWorldCoords().x, enemy.GetWorldCoords().y,
        //                                                        (enemy.GetTileCoords().x + randOffset), (enemy.GetTileCoords().y - randOffset)), WorldObjectType.EXPLOSION);
        //                        if (index > 2)
        //                        {
        //                            RegisterObject(new Explosion(m_device, enemy.GetWorldCoords().x, enemy.GetWorldCoords().y,
        //                                                            (enemy.GetTileCoords().x + randOffset), enemy.GetTileCoords().y), WorldObjectType.EXPLOSION);
        //                        }
        //                    }

        //                    break;
        //                }
        //            }
        //        }
        //    }


        //    /******************************************************
        //     * COLLISION TEST 3 - ENEMY MUNITION to TANK
        //     ******************************************************/
        //    if (!m_tankDestroyed)
        //    {
        //        for (int enemyMunitionCount = 0; enemyMunitionCount < m_enemyMunitions.Count; enemyMunitionCount++)
        //        {
        //            WorldObject enemyMunition = ((WorldObject)m_enemyMunitions[enemyMunitionCount]);

        //            double enemyMunitionX = enemyMunition.GetWorldCoords().x + enemyMunition.GetTileCoords().x;
        //            double enemyMunitionY = enemyMunition.GetWorldCoords().y + enemyMunition.GetTileCoords().y;

        //            double tankX = m_tank.GetWorldCoords().x + m_tank.GetTileCoords().x;
        //            double tankY = m_tank.GetWorldCoords().y + m_tank.GetTileCoords().y;

        //            double x = enemyMunitionX - tankX;
        //            double y = enemyMunitionY - tankY;

        //            double distance = Math.Sqrt((x * x) + (y * y));

        //            if (distance <= 2.00)
        //            {
        //                int healthBefore = m_playerData.GetHealth();

        //                bool result = CollisionHandler.GetInstance().CheckOABBIntersection(enemyMunition.GetBoundingShape(), m_tank.GetBoundingShape());

        //                if (result)
        //                {
        //                    RegisterObject(new Explosion(m_device, enemyMunition.GetWorldCoords().x, enemyMunition.GetWorldCoords().y, enemyMunition.GetTileCoords().x, enemyMunition.GetTileCoords().y), WorldObjectType.EXPLOSION);

        //                    m_enemyMunitions.Remove(enemyMunition);
        //                    enemyMunition.Destroy();
        //                    m_tank.Tint(Color.Red);

        //                    bool blowUpTank = false;

        //                    if (m_tankInvincible)
        //                    {
        //                        blowUpTank = m_playerData.DecreaseHealth(0);
        //                    }
        //                    else
        //                    {
        //                        blowUpTank = m_playerData.DecreaseHealth(5);
        //                    }

        //                    GameEngine.IntCoords coords = m_tank.GetWorldCoords();

        //                    if (blowUpTank)
        //                    {
        //                        m_tankDestroyed = true;
        //                        m_tankDeadTimestamp = GameTimer.timeGetTime();
        //                        m_playerData.ZeroOutData();
        //                        m_playerData.DecreaseLives();

        //                        m_hud.ReduceDamage();

        //                        if (m_playerData.GetLivesRemaining() == 0 && m_playerData.GetHealth() == 0)
        //                        {
        //                            gameOver = true;
        //                            return gameOver;
        //                        }

        //                        for (int index = 0; index < 5; index++)
        //                        {
        //                            Random rand = new Random((int)GameTimer.timeGetTime());

        //                            float randOffset = (rand.Next(1000)) / 3000.0f;

        //                            RegisterObject(new Explosion(m_device, m_tank.GetWorldCoords().x, m_tank.GetWorldCoords().y,
        //                                                            (m_tank.GetTileCoords().x + randOffset), (m_tank.GetTileCoords().y - randOffset)), WorldObjectType.EXPLOSION);
        //                            if (index > 2)
        //                            {
        //                                RegisterObject(new Explosion(m_device, m_tank.GetWorldCoords().x, m_tank.GetWorldCoords().y,
        //                                                                (m_tank.GetTileCoords().x + randOffset), m_tank.GetTileCoords().y), WorldObjectType.EXPLOSION);
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        m_hud.DoDamage();
        //                    }

        //                    break;
        //                }
        //            }
        //        }
        //    }

        //    /******************************************************
        //     * COLLISION TEST 4 - WORLD to EVERYTHING
        //     ******************************************************/
        //    //for (int colCount = rowMin; colCount <= rowMax; colCount++)
        //    //{
        //    //    for (int rowCount = colMin; rowCount <= colMax; rowCount++)
        //    //    {
        //    //        m_worldTiles[colCount, rowCount].SetLocation(colCount, rowCount);

        //    //        bool result = false;

        //    //        if (m_boundingBoxes[colCount, rowCount] != null)
        //    //        {
        //    //            for (int tankMunitionCount = 0; tankMunitionCount < m_tankMunitions.Count; tankMunitionCount++)
        //    //            {
        //    //                WorldObject tankMunition = ((WorldObject)m_tankMunitions[tankMunitionCount]);
        //    //                result = CollisionHandler.GetInstance().CheckOABBIntersection(tankMunition.GetBoundingShape(), m_boundingBoxes[colCount, rowCount]);

        //    //                if (result)
        //    //                {
        //    //                    if (tankMunition.GetType() != typeof(Bullet))
        //    //                    {
        //    //                        RegisterObject(new Explosion(m_device, tankMunition.GetWorldCoords().x, tankMunition.GetWorldCoords().y,
        //    //                                                            tankMunition.GetTileCoords().x, tankMunition.GetTileCoords().y), WorldObjectType.EXPLOSION);
        //    //                    }

        //    //                    m_tankMunitions.Remove(tankMunition);
        //    //                    tankMunition.Destroy();
        //    //                }
        //    //            }

        //    //            for (int enemyMunitionCount = 0; enemyMunitionCount < m_enemyMunitions.Count; enemyMunitionCount++)
        //    //            {
        //    //                WorldObject enemyMunition = ((WorldObject)m_enemyMunitions[enemyMunitionCount]);
        //    //                result = CollisionHandler.GetInstance().CheckOABBIntersection(enemyMunition.GetBoundingShape(), m_boundingBoxes[colCount, rowCount]);

        //    //                if (result)
        //    //                {
        //    //                    enemyMunition.Destroy();
        //    //                    m_enemyMunitions.Remove(enemyMunition);
        //    //                }
        //    //            }
        //    //        }
        //    //    }
        //    //}

        //    /******************************************************
        //    * COLLISION TEST 5 - LASER to ENEMIES
        //    ******************************************************/
        //    if(m_laser != null)
        //    {
        //        for (int enemyIndex = 0; enemyIndex < m_enemies.Count; enemyIndex++)
        //        {
        //            WorldObject enemy = ((WorldObject)m_enemies[enemyIndex]);

        //            double laserX = m_laser.GetWorldCoords().x + m_laser.GetTileCoords().x;
        //            double laserY = m_laser.GetWorldCoords().y + m_laser.GetTileCoords().y;

        //            double enemyX = enemy.GetWorldCoords().x + enemy.GetTileCoords().x;
        //            double enemyY = enemy.GetWorldCoords().y + enemy.GetTileCoords().y;

        //            double x = laserX - enemyX;
        //            double y = laserY - enemyY;

        //            double distance = Math.Sqrt((x * x) + (y * y));

        //            if (distance <= 7.00)
        //            {
        //                if (enemy.ReduceHealth(m_laser.GetCrashDamage()))
        //                {
        //                    if (enemy.GetType() != typeof(Turret))
        //                    {
        //                        m_enemyCount--;
        //                    }
        //                    else
        //                    {
        //                        //Redraw the tile the turret sits on
        //                        int row = enemy.GetWorldCoords().x;
        //                        int col = enemy.GetWorldCoords().y;

        //                        Texture SE = TextureLoader.FromFile(m_device, @"..\Images\Unanimated\48bunkerSE.png");
        //                        Texture SW = TextureLoader.FromFile(m_device, @"..\Images\Unanimated\47bunkerSW.png");
        //                        Texture NE = TextureLoader.FromFile(m_device, @"..\Images\Unanimated\46bunkerNE.png");
        //                        Texture NW = TextureLoader.FromFile(m_device, @"..\Images\Unanimated\45bunkerNW.png");

        //                        m_worldTiles[row, col] = new WorldTile(new UnanimatedSprite(m_device, SW, 0, 0.0f, 0.0f));
        //                        m_worldTiles[row + 1, col] = new WorldTile(new UnanimatedSprite(m_device, SE, 0, 0.0f, 0.0f));
        //                        m_worldTiles[row, col + 1] = new WorldTile(new UnanimatedSprite(m_device, NW, 0, 0.0f, 0.0f));
        //                        m_worldTiles[row + 1, col + 1] = new WorldTile(new UnanimatedSprite(m_device, NE, 0, 0.0f, 0.0f));
        //                    }

        //                    enemy.Destroy();
        //                    m_enemies.Remove(enemy);

        //                    m_playerData.IncreaseScore(enemy.GetPointValue(), m_laserFiring);

        //                    //display a resulting explosion
        //                    for (int index = 0; index < 5; index++)
        //                    {
        //                        Random rand = new Random((int)GameTimer.timeGetTime());
        //                        float randOffset = (rand.Next(1000)) / 3000.0f;
                               
        //                        RegisterObject(new Explosion(m_device, enemy.GetWorldCoords().x, enemy.GetWorldCoords().y,
        //                                                        (enemy.GetTileCoords().x + randOffset), (enemy.GetTileCoords().y - randOffset)), WorldObjectType.EXPLOSION);
        //                        if (index > 2)
        //                        {
        //                            RegisterObject(new Explosion(m_device, enemy.GetWorldCoords().x, enemy.GetWorldCoords().y,
        //                                                            (enemy.GetTileCoords().x + randOffset), enemy.GetTileCoords().y), WorldObjectType.EXPLOSION);
        //                        }
        //                    }
        //                }
        //            }
                
        //        }
        //    }
        //    /******************************************************
        //    * COLLISION TEST 6 - TANK MUNITIONS to BOSS
        //    ******************************************************/

        //    for (int munitionIndex = 0; munitionIndex < m_tankMunitions.Count; munitionIndex++)
        //    {
        //        WorldObject tankMunition = ((WorldObject)m_tankMunitions[munitionIndex]);

        //        bool headResult = CollisionHandler.GetInstance().CheckOABBIntersection(m_bossBot.GetBoundingShape(), tankMunition.GetBoundingShape());
        //        bool leftResult = false;
        //        bool rightResult = false;

        //        if (m_bossBot.GetLeftTurretShape() != null)
        //            leftResult = CollisionHandler.GetInstance().CheckOABBIntersection(m_bossBot.GetLeftTurretShape(), tankMunition.GetBoundingShape());

        //        if (m_bossBot.GetRightTurretShape() != null)
        //            rightResult = CollisionHandler.GetInstance().CheckOABBIntersection(m_bossBot.GetRightTurretShape(), tankMunition.GetBoundingShape());

        //        if (headResult)
        //        {
        //            RegisterObject(new Explosion(m_device, tankMunition.GetWorldCoords().x, tankMunition.GetWorldCoords().y, tankMunition.GetTileCoords().x, tankMunition.GetTileCoords().y), WorldObjectType.EXPLOSION);

        //            if (m_bossBot.ReduceHealth(tankMunition.GetCrashDamage()))
        //            {
        //                //BLOW UP BOSS AND END GAME
        //                gameOver = true;

        //                m_tankMunitions.Remove(tankMunition);
        //                tankMunition.Destroy();
        //                m_bossBot.Destroy();
        //                m_bossBot = null;

        //                break;
        //            }

        //            m_bossBot.Tint(Color.Red);
        //            m_tankMunitions.Remove(tankMunition);
        //            tankMunition.Destroy();
        //        }
        //        else if (leftResult)
        //        {
        //            RegisterObject(new Explosion(m_device, tankMunition.GetWorldCoords().x, tankMunition.GetWorldCoords().y, tankMunition.GetTileCoords().x, tankMunition.GetTileCoords().y), WorldObjectType.EXPLOSION);
        //            if (m_bossBot.ReduceLeftTurretHealth(tankMunition.GetCrashDamage()))
        //            {
        //                //BLOW UP LEFT TURRET
        //                for (int index = 0; index < 5; index++)
        //                {
        //                    Random rand = new Random((int)GameTimer.timeGetTime());
        //                    float randOffset = (rand.Next(1000)) / 3000.0f;
        //                    RegisterObject(new Explosion(m_device, m_bossBot.GetWorldCoords().x + 2, m_bossBot.GetWorldCoords().y,
        //                                                    (m_bossBot.GetTileCoords().x + randOffset), (m_bossBot.GetTileCoords().y - randOffset)), WorldObjectType.EXPLOSION);
        //                    if (index > 2)
        //                    {
        //                        RegisterObject(new Explosion(m_device, m_bossBot.GetWorldCoords().x + 2, m_bossBot.GetWorldCoords().y,
        //                                                        (m_bossBot.GetTileCoords().x + randOffset), (m_bossBot.GetTileCoords().y - randOffset)), WorldObjectType.EXPLOSION);
        //                        RegisterObject(new Explosion(m_device, m_bossBot.GetWorldCoords().x + 2, m_bossBot.GetWorldCoords().y,
        //                                                        (m_bossBot.GetTileCoords().x + randOffset), (m_bossBot.GetTileCoords().y - randOffset)), WorldObjectType.EXPLOSION);
        //                    }

        //                    if (index > 4)
        //                    {
        //                        RegisterObject(new Explosion(m_device, m_bossBot.GetWorldCoords().x + 2, m_bossBot.GetWorldCoords().y,
        //                                                        (m_bossBot.GetTileCoords().x + randOffset), (m_bossBot.GetTileCoords().y - randOffset)), WorldObjectType.EXPLOSION);
        //                        RegisterObject(new Explosion(m_device, m_bossBot.GetWorldCoords().x + 2, m_bossBot.GetWorldCoords().y,
        //                                                        (m_bossBot.GetTileCoords().x + randOffset), (m_bossBot.GetTileCoords().y - randOffset)), WorldObjectType.EXPLOSION);
        //                    }
        //                }
        //            }

        //            m_bossBot.TintLeftTurret(Color.Red);
        //            m_tankMunitions.Remove(tankMunition);
        //            tankMunition.Destroy();
        //        }
        //        else if (rightResult)
        //        {
        //            RegisterObject(new Explosion(m_device, tankMunition.GetWorldCoords().x, tankMunition.GetWorldCoords().y, tankMunition.GetTileCoords().x, tankMunition.GetTileCoords().y), WorldObjectType.EXPLOSION);
                    
        //            if (m_bossBot.ReduceRightTurretHealth(tankMunition.GetCrashDamage()))
        //            {
        //                //BLOW UP RIGHT TURRET
        //                for (int index = 0; index < 5; index++)
        //                {
        //                    Random rand = new Random((int)GameTimer.timeGetTime());
        //                    float randOffset = (rand.Next(1000)) / 3000.0f;
        //                    RegisterObject(new Explosion(m_device, m_bossBot.GetWorldCoords().x - 2, m_bossBot.GetWorldCoords().y,
        //                                                    (m_bossBot.GetTileCoords().x + randOffset), (m_bossBot.GetTileCoords().y - randOffset)), WorldObjectType.EXPLOSION);
        //                    if (index > 2)
        //                    {
        //                        RegisterObject(new Explosion(m_device, m_bossBot.GetWorldCoords().x - 2, m_bossBot.GetWorldCoords().y,
        //                                                        (m_bossBot.GetTileCoords().x + randOffset), (m_bossBot.GetTileCoords().y - randOffset)), WorldObjectType.EXPLOSION);
        //                        RegisterObject(new Explosion(m_device, m_bossBot.GetWorldCoords().x - 2, m_bossBot.GetWorldCoords().y,
        //                                                        (m_bossBot.GetTileCoords().x + randOffset), (m_bossBot.GetTileCoords().y - randOffset)), WorldObjectType.EXPLOSION);
        //                    }

        //                    if (index > 4)
        //                    {
        //                        RegisterObject(new Explosion(m_device, m_bossBot.GetWorldCoords().x - 2, m_bossBot.GetWorldCoords().y,
        //                                                        (m_bossBot.GetTileCoords().x + randOffset), (m_bossBot.GetTileCoords().y - randOffset)), WorldObjectType.EXPLOSION);
        //                        RegisterObject(new Explosion(m_device, m_bossBot.GetWorldCoords().x - 2, m_bossBot.GetWorldCoords().y,
        //                                                        (m_bossBot.GetTileCoords().x + randOffset), (m_bossBot.GetTileCoords().y - randOffset)), WorldObjectType.EXPLOSION);
        //                    }
        //                }
        //            }

        //            m_bossBot.TintRightTurret(Color.Red);
        //            m_tankMunitions.Remove(tankMunition);
        //            tankMunition.Destroy();
        //        }
        //    }

        //    return gameOver;
        //}
        

        //public void RespondToCollisions()
        //{
        //    //upgrade the tank munitions if killcounts are reached
        //    if (m_playerData.GetKillCount() >= RAPIDFIREKILLCOUNT && !m_playerData.HasRapidFire())
        //    {
        //        m_playerData.RecieveUpgrade(m_rapidFireUpgrade);
        //    }
        //    else if (m_playerData.GetKillCount() >= VOLLEYKILLCOUNT && !m_playerData.HasVolley())
        //    {
        //        m_playerData.RecieveUpgrade(m_volleyUpgrade);
        //    }
        //}

        ///// <summary>
        ///// Destroy the used memory.
        ///// </summary>
        //public void Destroy()
        //{
        //    for (int row = 0; row < m_worldWidth; row++)
        //    {
        //        for (int col = 0; col < m_worldHeight; col++)
        //        {
        //            if (m_worldTiles[row, col] != null)
        //                m_worldTiles[row, col].Destroy();
        //        }
        //    }

        //    if (m_worldTiles != null)
        //        m_worldTiles = null;

        //    if (m_device != null)
        //    {
        //        m_device.Dispose();
        //        m_device = null;
        //    }

        //    if (m_camera != null)
        //        m_camera = null;

        //    if (m_enemies != null)
        //    {
        //        m_enemies.Clear();
        //        m_enemies = null;
        //    }

        //    if (m_tankMunitions != null)
        //    {
        //        m_tankMunitions.Clear();
        //        m_tankMunitions = null;
        //    }

        //    if (m_tank != null)
        //    {
        //        m_tank.Destroy();
        //        m_tank = null;
        //    }

        //    if (m_bossBot != null)
        //    {
        //        m_bossBot.Destroy();
        //        m_bossBot = null;
        //    }
        //}

        #endregion
    }
}
