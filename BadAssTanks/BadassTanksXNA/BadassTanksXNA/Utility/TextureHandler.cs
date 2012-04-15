using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BadAssTanks
{
    /// <summary>
    /// Handles the creation and retrieval of Textures for the Game Engine.
    /// </summary>
    public class TextureHandler
    {
        /// <summary>
        /// 
        /// </summary>
        private ContentManager _contentManager;
        /// <summary>
        /// 
        /// </summary>
        private Texture2D _tank;
        public Texture2D TankTexture { get { return _tank; } }
        /// <summary>
        /// 
        /// </summary>
        private Texture2D _titleBad;
        public Texture2D TitleBadTexture { get { return _titleBad; } }

        //private ArrayList m_waterImageStrings = null;
        //private ArrayList m_waterTextures = null;
        //private ArrayList m_explosionImages = null;

        //private ArrayList m_animatedImages = null;
        //private ArrayList m_unanimatedImages = null;

        //private ArrayList m_camoTankImages = null;
        //private ArrayList m_blueRedTankImages = null;
        //private ArrayList m_greenYellowTankImages = null;

        //private ArrayList m_bulletImages = null;
        //private ArrayList m_missileImages = null;
        //private ArrayList m_laserImages = null;
        //private ArrayList m_smokeImages = null;

        //private ArrayList m_robotImages = null;
        //private ArrayList m_robotHeadImages = null;

        //private ArrayList m_turretImages = null;
        //private ArrayList m_tankDamage = null;

        //private ArrayList m_titleImages = null;

        //private ArrayList m_upgrades = null;

        //private bool m_deviceFlag = false;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="contentManager"></param>
        public TextureHandler(ContentManager contentManager)
        {
            _contentManager = contentManager;

            this.LoadTextures();
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadTextures()
        {
            _titleBad = _contentManager.Load<Texture2D>("bad");
        }
        
 



        //private void LoadUnanimatedImages()
        //{
        //    String[] imageNames = Directory.GetFiles(@"..\..\..\Images\Unanimated");
        //    Texture tempTexture;

        //    foreach(String imageName in imageNames)
        //    {
        //        tempTexture = TextureLoader.FromFile(m_device, (String)imageName);
        //        m_unanimatedImages.Add(tempTexture);
        //    }
        //}

        //private void LoadAnimatedImages()
        //{
        //    String[] dirNames = Directory.GetDirectories(@"..\..\..\Images\Animated");
        //    String[] imageNames;
        //    Texture tempTexture;
        //    ArrayList tempArray = new ArrayList();

        //    foreach (String dirName in dirNames)
        //    {
        //        imageNames = Directory.GetFiles(dirName);
        //        foreach (String imageName in imageNames)
        //        {
        //            tempTexture = TextureLoader.FromFile(m_device, (String)imageName);
        //            tempArray.Add(tempTexture);
        //        }
        //        m_animatedImages.Add(tempArray);
        //        tempArray = new ArrayList();
        //    }
        //}

        //public ArrayList GetTextures()
        //{
        //    return m_unanimatedImages;
        //}

        //public ArrayList GetAnimatedTextures()
        //{
        //    return m_animatedImages;
        //}

        //private bool LoadTextures()
        //{
        //    //for debugging
        //    if (m_deviceFlag == false)
        //    {
        //        return m_deviceFlag;
        //    }

        //    //load tank textures
        //    Texture camoTankBaseTexture = TextureLoader.FromFile(m_device, @"..\..\..\Images\Tank Parts\tank_base_camo.png");
        //    Texture camoTankTurretTexture = TextureLoader.FromFile(m_device, @"..\..\..\Images\Tank Parts\tank_turret_camo.png");
        //    Texture camoTankGunTexture = TextureLoader.FromFile(m_device, @"..\..\..\Images\Tank Parts\tank_gun_camo.png");

        //    Texture blueRedTankBaseTexture = TextureLoader.FromFile(m_device, @"..\..\..\Images\Tank Parts\tank_base_blue_red.png");
        //    Texture blueRedTankTurretTexture = TextureLoader.FromFile(m_device, @"..\..\..\Images\Tank Parts\tank_turret_blue_red.png");
        //    Texture blueRedTankGunTexture = TextureLoader.FromFile(m_device, @"..\..\..\Images\Tank Parts\tank_gun_blue_red.png");

        //    Texture greenYellowTankBaseTexture = TextureLoader.FromFile(m_device, @"..\..\..\Images\Tank Parts\tank_base_green_yellow.png");
        //    Texture greenYellowTankTurretTexture = TextureLoader.FromFile(m_device, @"..\..\..\Images\Tank Parts\tank_turret_green_yellow.png");
        //    Texture greenYellowTankGunTexture = TextureLoader.FromFile(m_device, @"..\..\..\Images\Tank Parts\tank_gun_green_yellow.png");

        //    //Load hud textures
        //    Texture tankBaseBackground = TextureLoader.FromFile(m_device, @"..\..\..\Images\tank damage\baseBackground.png");
        //    Texture tankBaseDamage = TextureLoader.FromFile(m_device, @"..\..\..\Images\tank damage\base.png");
        //    Texture yellowDamage = TextureLoader.FromFile(m_device, @"..\..\..\Images\tank damage\yellowDamage.png");
        //    Texture redDamage = TextureLoader.FromFile(m_device, @"..\..\..\Images\tank damage\redDamage.png");
        //    Texture background = TextureLoader.FromFile(m_device, @"..\..\..\Images\tank damage\background2.png");
        //    Texture beam = TextureLoader.FromFile(m_device, @"..\..\..\Images\tank damage\beam.png");
        //    Texture beamMax = TextureLoader.FromFile(m_device, @"..\..\..\Images\tank damage\beamMax.png");
        //    Texture minimap = TextureLoader.FromFile(m_device, @"..\..\..\Images\tank damage\minimap.png");

        //    Texture bulletTexture = TextureLoader.FromFile(m_device, @"..\..\..\Images\Weapons\bullet.png");

        //    Texture missileTexture = TextureLoader.FromFile(m_device, @"..\..\..\Images\Weapons\MissileBig.png");

        //    Texture laserTexture1 = TextureLoader.FromFile(m_device, @"..\..\..\Images\Weapons\startLaser.png");
        //    Texture laserTexture2 = TextureLoader.FromFile(m_device, @"..\..\..\Images\Weapons\laser.png");

        //    Texture badTexture = TextureLoader.FromFile(m_device, @"..\..\..\Images\Menu\bad.png");
        //    Texture assTexture = TextureLoader.FromFile(m_device, @"..\..\..\Images\Menu\ass.png");
        //    Texture tanksTexture = TextureLoader.FromFile(m_device, @"..\..\..\Images\Menu\tanks.png");
        //    Texture startTexture = TextureLoader.FromFile(m_device, @"..\..\..\Images\Menu\start.png");
        //    Texture exitTexture = TextureLoader.FromFile(m_device, @"..\..\..\Images\Menu\exit.png");

        //    Texture robotTexture1 = TextureLoader.FromFile(m_device, @"..\..\..\Images\RoboWalker\Ranger0.png");
        //    Texture robotTexture2 = TextureLoader.FromFile(m_device, @"..\..\..\Images\RoboWalker\Ranger1.png");
        //    Texture robotTexture3 = TextureLoader.FromFile(m_device, @"..\..\..\Images\RoboWalker\Ranger2.png");
        //    Texture robotTexture4 = TextureLoader.FromFile(m_device, @"..\..\..\Images\RoboWalker\Ranger3.png");
        //    Texture robotHead = TextureLoader.FromFile(m_device, @"..\..\..\Images\RoboWalker\RangerHead.png");

        //    Texture turret = TextureLoader.FromFile(m_device, @"..\..\..\Images\EnemyStuff\turret.png");

        //    Texture volleyUpgrade = TextureLoader.FromFile(m_device, @"..\..\..\Images\Upgrades\VolleyMissile.png");
        //    Texture rapidFireUpgrade = TextureLoader.FromFile(m_device, @"..\..\..\Images\Upgrades\RapidFire.png");

        //    LoadSmokeTextures();
        //    LoadExplosionTextures();

        //    m_camoTankImages.Add(camoTankBaseTexture);
        //    m_camoTankImages.Add(camoTankTurretTexture);
        //    m_camoTankImages.Add(camoTankGunTexture);

        //    m_blueRedTankImages.Add(blueRedTankBaseTexture);
        //    m_blueRedTankImages.Add(blueRedTankTurretTexture);
        //    m_blueRedTankImages.Add(blueRedTankGunTexture);

        //    m_greenYellowTankImages.Add(greenYellowTankBaseTexture);
        //    m_greenYellowTankImages.Add(greenYellowTankTurretTexture);
        //    m_greenYellowTankImages.Add(greenYellowTankGunTexture);

        //    m_tankDamage.Add(tankBaseBackground);
        //    m_tankDamage.Add(tankBaseDamage);
        //    m_tankDamage.Add(yellowDamage);
        //    m_tankDamage.Add(redDamage);
        //    m_tankDamage.Add(background);
        //    m_tankDamage.Add(beam);
        //    m_tankDamage.Add(beamMax);
        //    m_tankDamage.Add(minimap);

        //    m_bulletImages.Add(bulletTexture);

        //    m_missileImages.Add(missileTexture);

        //    m_laserImages.Add(laserTexture1);
        //    m_laserImages.Add(laserTexture2);

        //    m_titleImages.Add(badTexture);
        //    m_titleImages.Add(assTexture);
        //    m_titleImages.Add(tanksTexture);
        //    m_titleImages.Add(startTexture);
        //    m_titleImages.Add(exitTexture);

        //    m_robotImages.Add(robotTexture1);
        //    m_robotImages.Add(robotTexture2);
        //    m_robotImages.Add(robotTexture3);
        //    m_robotImages.Add(robotTexture4);

        //    m_robotHeadImages.Add(robotHead);

        //    m_turretImages.Add(turret);

        //    m_upgrades.Add(volleyUpgrade);
        //    m_upgrades.Add(rapidFireUpgrade);

        //    return m_deviceFlag;
        //}

        //private void LoadSmokeTextures()
        //{
        //    String[] imageNames = Directory.GetFiles(@"..\..\..\Images\Smoke");
        //    Texture tempTexture;

        //    foreach(String imageName in imageNames)
        //    {
        //        tempTexture = TextureLoader.FromFile(m_device, (String)imageName);
        //        m_smokeImages.Add(tempTexture);
        //    }
        //}

        //private void LoadExplosionTextures()
        //{
        //    String[] imageNames = Directory.GetFiles(@"..\..\..\Images\Kaboom");
        //    Texture tempTexture;

        //    foreach(String imageName in imageNames)
        //    {
        //        tempTexture = TextureLoader.FromFile(m_device, (String)imageName);
        //        m_explosionImages.Add(tempTexture);
        //    }
        //}

        //public ArrayList GetUpgrades()
        //{
        //    return m_upgrades;
        //}

        //public ArrayList GetCamoTankTextures()
        //{
        //    return m_camoTankImages;
        //}

        //public ArrayList GetBlueRedTankTextures()
        //{
        //    return m_blueRedTankImages;
        //}

        //public ArrayList GetGreenYellowTankTextures()
        //{
        //    return m_greenYellowTankImages;
        //}

        //public ArrayList GetTankDamageTextures()
        //{
        //    return m_tankDamage;
        //}

        //public ArrayList GetWaterTextures()
        //{
        //    return m_waterTextures;
        //}

        //public ArrayList GetBulletTextures()
        //{
        //    return m_bulletImages;
        //}

        //public ArrayList GetMissileTextures()
        //{
        //    return m_missileImages;
        //}

        //public ArrayList GetTitleTextures()
        //{
        //    return m_titleImages;
        //}

        //public ArrayList GetSmokeTextures()
        //{
        //    return m_smokeImages;
        //}

        //public ArrayList GetRobotTextures()
        //{
        //    return m_robotImages;
        //}

        //public ArrayList GetRobotHeadTextures()
        //{
        //    return m_robotHeadImages;
        //}

        //public ArrayList GetTurretTextures()
        //{
        //    return m_turretImages;
        //}

        //public ArrayList GetExplosionTextures()
        //{
        //    return m_explosionImages;
        //}

        //public ArrayList GetLaserTextures()
        //{
        //    return m_laserImages;
        //}
    }
}
