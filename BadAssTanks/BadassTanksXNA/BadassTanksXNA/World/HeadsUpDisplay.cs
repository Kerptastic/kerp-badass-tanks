
namespace BadAssTanks
{
    public class HeadsUpDisplay
    {
        //private Device m_device;
        //private PlayerData m_playerData;

        //private ArrayList m_damageTextures;
        //private ArrayList explosions;
        //private ArrayList smokes;

        //private UnanimatedSprite baseBackground;
        //private UnanimatedSprite tankBase;
        //private UnanimatedSprite redDamage;
        //private UnanimatedSprite yellowDamage;
        //private UnanimatedSprite background;
        //private UnanimatedSprite beam;
        //private UnanimatedSprite beamMax;

        //private const int baseBackgroundIndex = 0;
        //private const int tankBaseIndex = 1;
        //private const int yellowDamageIndex = 2;
        //private const int redDamageIndex = 3;
        //private const int backgroundIndex = 4;
        //private const int tickIndex = 5;
        //private const int beamMaxIndex = 6;

        //private int[] damage = new int[9];
        //private float beamCount = 0;

        //private const float maximumBeam = 6.0f;
        //private const float beamIncrease = 0.2f;

        //private const float m_baseWidth = 460.0f;
        //private const float m_baseHeight = 1000.0f;

        //private const float backgroundTransX = 0.0f;
        //private const float backgroundTransY = 0.38f;

        //private const float baseTransX = 0.0f;
        //private const float baseTransY = -3.0f;

        //private const float damageTransX = -3.3f;
        //private const float damageTransY = -1.33f;

        //private const float damageWidth = 3.3f;
        //private const float damageHeight = 1.67f;

        //private const float baseScaleX = 5.0f;
        //private const float baseScaleY = 2.5f;

        //private const float damageScaleX = baseScaleX / 3;
        //private const float damageScaleY = baseScaleY / 3;

        //private const float backgroundScaleX = 7.6f;
        //private const float backgroundScaleY = 7.3f;

        //private TextSprite m_score = null;
        //private TextSprite m_laserPower = null;
        //private TextSprite m_health = null;
        //private TextSprite m_weapons = null;
        //private TextSprite m_lives = null;

        //public HeadsUpDisplay(Device device, PlayerData playerData)
        //{
        //    m_device = device;
        //    m_playerData = playerData;

        //    m_score = new TextSprite(m_device, "", new System.Drawing.Font(new FontFamily("Arial"), 16.0f), 10.0f, 10.0f, 0.0f, Color.Gold);
        //    m_health = new TextSprite(m_device, "", new System.Drawing.Font(new FontFamily("Arial"), 16.0f), 10.0f, 300.0f, 0.0f, Color.Gold);
        //    m_laserPower = new TextSprite(m_device, "", new System.Drawing.Font(new FontFamily("Arial"), 16.0f), 10.0f, 80.0f, 0.0f, Color.Gold);
        //    m_weapons = new TextSprite(m_device, "", new System.Drawing.Font(new FontFamily("Arial"), 16.0f), 10.0f, 175.0f, 0.0f, Color.Gold);
        //    m_lives = new TextSprite(m_device, "", new System.Drawing.Font(new FontFamily("Arial"), 16.0f), 10.0f, 260.0f, 0.0f, Color.Gold);
            
        //    m_damageTextures = TextureHandler.GetInstance().GetTankDamageTextures();

        //    baseBackground =
        //        new UnanimatedSprite(m_device, ((Texture)m_damageTextures[baseBackgroundIndex]), 0.0f, 0.0f, 0.0f);

        //    tankBase =
        //        new UnanimatedSprite(m_device, ((Texture)m_damageTextures[tankBaseIndex]), 0.0f, 0.0f, 0.0f);

        //    redDamage =
        //        new UnanimatedSprite(m_device, ((Texture)m_damageTextures[redDamageIndex]), 0.0f, 0.0f, 0.0f);

        //    yellowDamage =
        //        new UnanimatedSprite(m_device, ((Texture)m_damageTextures[yellowDamageIndex]), 0.0f, 0.0f, 0.0f);

        //    background =
        //        new UnanimatedSprite(m_device, ((Texture)m_damageTextures[backgroundIndex]), 0.0f, 0.0f, 0.0f);

        //    beam =
        //        new UnanimatedSprite(m_device, ((Texture)m_damageTextures[tickIndex]), 0.0f, 0.0f, 0.0f);

        //    beamMax =
        //        new UnanimatedSprite(m_device, ((Texture)m_damageTextures[beamMaxIndex]), 0.0f, 0.0f, 0.0f);

        //    //Create the two arrays
        //    explosions = new ArrayList();
        //    smokes = new ArrayList();

        //    //Load the textures
        //    ArrayList m_explosionImages = TextureHandler.GetInstance().GetExplosionTextures();

        //    for(int i = 0; i < 9; i++)
        //        explosions.Add(new AnimatedSprite(m_device, m_explosionImages, 0.0f, 0.0f, 0.0f, 15));

        //    ArrayList m_smokeImages = TextureHandler.GetInstance().GetSmokeTextures();

        //    for (int i = 0; i < 9; i++) 
        //        smokes.Add(new AnimatedSprite(m_device, m_smokeImages, 0.0f, 0.0f, 0.0f, 100));
        //}

        //public void SetBeam()
        //{
        //    if (m_playerData.LaserPower() < maximumBeam)
        //        beamCount = m_playerData.LaserPower();
        //}

        //public int[] getDamageArray()
        //{
        //    return damage;
        //}

        //public void DoDamage()
        //{
        //    //Whether or not the damage has been done
        //    bool damageDone = false;

        //    //The random number generator for the damage
        //    Random random = new Random();

        //    //Check to see if the whole tank is red, if so no damage can be done
        //    int redNum = 0;
        //    for (int i = 0; i < damage.Length; i++)
        //    {
        //        if (damage[i] == 2)
        //            redNum++;
        //    }

        //    //Generate random spots until the damage is done
        //    while (damageDone == false && redNum < 9)
        //    {
        //        int temp = random.Next(9);

        //        if (damage[temp] != 2)
        //        {
        //            damage[temp]++;
        //            damageDone = true;
        //        }
        //    }

        //}

        //public void ReduceDamage()
        //{
        //    for (int i = 0; i < damage.Length; i++)
        //    {
        //        damage[i] = 0;
        //    }
        //}

        //public void RenderHUD(int width, int height)
        //{
        //    RenderBackground();
        //    RenderBaseBackground();
        //    RenderText();
        //    RenderBeam();
        //    RenderDamage();
        //    RenderBase();
        //    RenderUpgrades();
        //}

        //public void RenderBackground()
        //{
        //    Matrix saved = m_device.Transform.World;

        //    m_device.Transform.World = Matrix.Scaling(new Vector3(backgroundScaleX, backgroundScaleY, 0.0f)) *
        //                               Matrix.Translation(new Vector3(backgroundTransX, backgroundTransY, 0.0f));
        //    background.Render();

        //    m_device.Transform.World = saved;
        //}

        //public void RenderText()
        //{
        //    String scoreString = "Score\n " + m_playerData.GetScore();

        //    m_score.SetText(scoreString);
        //    m_score.Render();

        //    String upgradeString = "Laser-Rang \nPower ";

        //    m_laserPower.SetText(upgradeString);
        //    m_laserPower.Render();

        //    String weaponsString = "Weapons";

        //    m_weapons.SetText(weaponsString);
        //    m_weapons.Render();

        //    String livesString = "Lives Left: " + m_playerData.GetLivesRemaining();

        //    m_lives.SetText(livesString);
        //    m_lives.Render();

        //    String healthString = "Health\n" + m_playerData.GetHealth() + "%";

        //    m_health.SetText(healthString);
        //    m_health.Render();
        //}

        //public void RenderBeam()
        //{
        //    Matrix saved = m_device.Transform.World;

        //    float tx = -6.4f;
        //    float ty = 4.40f;

        //    float sx = 0.1f;
        //    float sy = 0.4f;

        //    if (m_playerData.LaserPower() >= maximumBeam)
        //    {
        //        m_device.Transform.World = Matrix.Scaling(new Vector3(sx + maximumBeam, sy, 0.0f)) *
        //                                       Matrix.Translation(new Vector3(tx + maximumBeam, ty, 0.0f));
        //        beamMax.Render();
        //    }
        //    else
        //    {
        //        m_device.Transform.World = Matrix.Scaling(new Vector3(sx + m_playerData.LaserPower(), sy, 0.0f)) *
        //                                       Matrix.Translation(new Vector3(tx + m_playerData.LaserPower(), ty, 0.0f));
        //        beam.Render();
        //    }

        //    m_device.Transform.World = saved;

        //}

        //public void RenderBaseBackground()
        //{
        //    Matrix saved = m_device.Transform.World;

        //    m_device.Transform.World = Matrix.Scaling(new Vector3(baseScaleX, baseScaleY, 0.0f)) *
        //                               Matrix.Translation(new Vector3(baseTransX, baseTransY, 0.0f));
        //    baseBackground.Render();

        //    m_device.Transform.World = saved;

        //}

        //public void RenderBase()
        //{
        //    Matrix saved = m_device.Transform.World;

        //    m_device.Transform.World = Matrix.Scaling(new Vector3(baseScaleX, baseScaleY, 0.0f)) *
        //                               Matrix.Translation(new Vector3(baseTransX, baseTransY, 0.0f));
        //    tankBase.Render();

        //    m_device.Transform.World = saved;
        //}

        //public void RenderDamage()
        //{
        //    Matrix saved = m_device.Transform.World;

        //    for (int i = 0; i < damage.Length; i++)
        //    {
        //        //Get the x multiplier
        //        int multX = i % 3;

        //        //Get the y multiplier
        //        int multY = 0;
        //        if (i > 2 && i < 6)
        //            multY = 1;
        //        else if (i > 5 && i < 9)
        //            multY = 2;


        //        m_device.Transform.World =
        //                Matrix.Scaling(new Vector3(damageScaleX, damageScaleY, 0.0f)) *
        //                Matrix.Translation(new Vector3(damageTransX + (damageWidth * multX),
        //                                                damageTransY - (damageHeight * multY), 0.0f));

        //        if (damage[i] == 1)
        //        {
        //            yellowDamage.Render();

        //            //Render the smoke
        //            AnimatedSprite temp = (AnimatedSprite)smokes[i];
        //            temp.Render();
        //        }
        //        else if (damage[i] == 2)
        //        {
        //            redDamage.Render();

        //            //Render the smoke
        //            AnimatedSprite temp1 = (AnimatedSprite)smokes[i];
        //            temp1.Render();

        //            //Render the explosion
        //            AnimatedSprite temp2 = (AnimatedSprite)explosions[i];
        //            temp2.Render();
        //        }

        //        m_device.Transform.World = saved;
        //    }
        //}

        //private void RenderUpgrades()
        //{
        //    Matrix saved = m_device.Transform.World;

        //    List<Upgrade> upgrades = m_playerData.GetUpgrades();

        //    for (int upgradeCount = 0; upgradeCount < upgrades.Count; upgradeCount++)
        //    {
        //        if (upgradeCount == 0)
        //        {
        //            upgrades[upgradeCount].SetLocation(-4.8f, 2.7f);
        //        }
        //        else if (upgradeCount == 1)
        //        {
        //            upgrades[upgradeCount].SetLocation(-1.0f, 2.7f);
        //        }
        //        else if (upgradeCount == 2)
        //        {
        //            upgrades[upgradeCount].SetLocation(2.8f, 2.7f);
        //        }

        //        upgrades[upgradeCount].Render();              
        //    }

        //    m_device.Transform.World = saved;
        //}
    }
}
