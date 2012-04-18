using System;
using System.Collections.Generic;
using System.Text;

namespace BadAssTanks
{
    public class PlayerData
    {
        //private String m_name = String.Empty;

        //private int m_enemyKillCount = 0;

        //private int m_livesRemaining = 3;

        //private long m_score = 0;
        //private int m_health = 100;

        //private float m_laserPower = 0.0f;

        //private const long m_maxScore = 999999;

        //private bool m_hasRapidFire = false;
        //private bool m_hasVolley = false;
        //private bool m_laserReady = false;

        //private List<Upgrade> m_upgrades = new List<Upgrade>();

        //public PlayerData()
        //{
        //}

        //public void IncreaseKills()
        //{
        //    m_enemyKillCount++;
        //}

        //public void ZeroOutData()
        //{
        //    m_enemyKillCount = 0;
           
        //    m_hasRapidFire = false;
        //    m_hasVolley = false;

        //    m_upgrades.Clear();
        //}

        //public void ClearScore()
        //{
        //    m_score = 0;
        //}

        //public void RecieveUpgrade(Upgrade upgrade)
        //{
        //    m_upgrades.Add(upgrade);

        //    if(upgrade.GetUpgradeType() == GameWorld.WorldObjectType.RAPIDFIREUPGRADE)
        //        m_hasRapidFire = true;
        //    else if(upgrade.GetUpgradeType() == GameWorld.WorldObjectType.VOLLEYUPGRADE)
        //        m_hasVolley = true;
        //}

        //public void IncreaseHealth(int amount)
        //{
        //    m_health += amount;

        //    if (m_health > 100)
        //        m_health = 100;
        //}

        //public void ReduceBeam(float amount)
        //{
        //    m_laserPower -= amount;
        //    m_laserReady = false;
        //}

        //public bool DecreaseHealth(int amount)
        //{
        //    bool deadTank = false;

        //    m_health -= amount;

        //    if (m_health <= 0)
        //    {
        //        m_health = 100;

        //        deadTank = true;

        //        if (m_livesRemaining > 0)
        //        {
        //            this.DecreaseLives();
        //        }
        //        else
        //        {
        //            m_health = 0;
        //        }
        //    }

        //    return deadTank;
        //}

        //public void IncreaseScore(long amount, bool laserFiring)
        //{
        //    m_score += amount;

        //    if (m_score > m_maxScore)
        //        m_score = m_maxScore;

        //    if (!laserFiring)
        //    {
        //        if (m_laserPower <= 6.0f)
        //        {
        //            m_laserReady = false;
        //            m_laserPower += (float)amount / 2000.0f;
        //        }
        //        else
        //        {
        //            m_laserReady = true;
        //        }
        //    }
        //}

        //public void IncreaseLives()
        //{
        //    m_livesRemaining++;
        //}

        //public void DecreaseLives()
        //{
        //    m_livesRemaining--;

        //    if (m_livesRemaining < 0)
        //        m_livesRemaining = 0;
        //}

        //public bool LaserReady()
        //{
        //    return m_laserReady;
        //}

        //public int GetKillCount()
        //{
        //    return m_enemyKillCount;
        //}

        //public int GetLivesRemaining()
        //{
        //    return m_livesRemaining;
        //}

        //public long GetScore()
        //{
        //    return m_score;
        //}

        //public int GetHealth()
        //{
        //    return m_health;
        //}

        //public float LaserPower()
        //{
        //    return m_laserPower;
        //}

        //public List<Upgrade> GetUpgrades()
        //{
        //    return m_upgrades;
        //}

        //public bool HasVolley()
        //{
        //    return m_hasVolley;
        //}

        //public bool HasRapidFire()
        //{
        //    return m_hasRapidFire;
        //}
    }
}
