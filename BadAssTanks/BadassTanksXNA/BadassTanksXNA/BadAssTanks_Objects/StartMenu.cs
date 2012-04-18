
namespace BadAssTanks
{
    public class StartMenu
    {
        //public enum Option
        //{
        //    STARTGAME, EXIT
        //}

        //private Option m_selectedOption = Option.STARTGAME;

        //private Device m_device = null;
        //private UnanimatedSprite m_badText = null;
        //private UnanimatedSprite m_assText = null;
        //private UnanimatedSprite m_tanksText = null;

        //private UnanimatedSprite m_startText = null;
        //private UnanimatedSprite m_exitText = null;

        //private ArrayList m_titleTextures = null;

        //private float m_xScalingCoef;
        //private float m_yScalingCoef;

        //private bool m_introMusicPlaying = false;
        //private bool m_badAnimated = false;
        //private bool m_assAnimated = false;
        //private bool m_tanksAnimated = false;

        //private bool m_fireBad = false;
        //private bool m_fireAss = false;
        //private bool m_fireTanks = false;

        //public StartMenu(Device device)
        //{
        //    m_device = device;

        //    m_titleTextures = TextureHandler.GetInstance().GetTitleTextures();

        //    m_badText = new UnanimatedSprite(m_device, (Texture)m_titleTextures[0], 0.0f, 0.0f, 20.0f);
        //    m_assText = new UnanimatedSprite(m_device, (Texture)m_titleTextures[1], 0.0f, 0.0f, 0.0f);
        //    m_tanksText = new UnanimatedSprite(m_device, (Texture)m_titleTextures[2], 0.0f, 0.0f, 0.0f);
        //    m_startText = new UnanimatedSprite(m_device, (Texture)m_titleTextures[3], 0.0f, 0.0f, 0.0f);
        //    m_exitText = new UnanimatedSprite(m_device, (Texture)m_titleTextures[4], 0.0f, 0.0f, 0.0f);

        //    m_xScalingCoef = 0.0f;
        //    m_yScalingCoef = 0.0f;
        //}

        //public void SelectOption(int optionChange)
        //{
        //    if (m_selectedOption == Option.STARTGAME)
        //    {
        //        if (optionChange < 0)
        //        {
        //            m_selectedOption = Option.EXIT;
        //        }
        //    }
        //    else if (m_selectedOption == Option.EXIT)
        //    {
        //        if (optionChange > 0)
        //        {
        //            m_selectedOption = Option.STARTGAME;
        //        }
        //    }

        //    AudioHandler.GetInstance().PlayAudio(AudioHandler.SoundType.BEEP);
        //}

        //public Option GetSelectedOption()
        //{
        //    return m_selectedOption;
        //}

        //public void RenderTitle()
        //{
        //    Matrix saved = m_device.Transform.World;

        //    m_device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.DarkSlateGray, 1.0f, 0);
          
        //    //animate the word Bad
        //    if (!m_badAnimated)
        //    {
        //        if (!m_fireBad)
        //        {
        //            AudioHandler.GetInstance().PlayAudio(AudioHandler.SoundType.EXPLOSION);
        //            m_fireBad = true;
        //        }

        //        m_xScalingCoef += .04f;
        //        m_yScalingCoef += .04f;

        //        m_device.Transform.World = Matrix.Scaling(new Vector3(m_xScalingCoef, m_yScalingCoef, 0.0f)) *
        //            Matrix.Translation(new Vector3(-2.0f, 3.0f, 0.0f));

        //        m_badText.Render();

        //        if (m_xScalingCoef > 2.0f)
        //        {
        //            m_badAnimated = true;

        //            m_xScalingCoef = 0.0f;
        //            m_yScalingCoef = 0.0f;
        //        }
        //    }

        //    //animate the word Ass
        //    else if (!m_assAnimated)
        //    {
        //        if (!m_fireAss)
        //        {
        //            AudioHandler.GetInstance().PlayAudio(AudioHandler.SoundType.EXPLOSION);
        //            m_fireAss = true;
        //        }

        //        m_xScalingCoef += .04f;
        //        m_yScalingCoef += .04f;

        //        m_device.Transform.World = Matrix.Scaling(new Vector3(2.0f, 2.0f, 0.0f)) *
        //            Matrix.Translation(new Vector3(-2.0f, 3.0f, 0.0f));

        //        m_badText.Render();

        //        m_device.Transform.World = Matrix.Scaling(new Vector3(m_xScalingCoef, m_yScalingCoef, 0.0f)) *
        //            Matrix.Translation(new Vector3(2.0f, 3.2f, 0.0f));

        //        m_assText.Render();

        //        if (m_xScalingCoef > 2.0f)
        //        {
        //            m_assAnimated = true;

        //            m_xScalingCoef = 0.0f;
        //            m_yScalingCoef = 0.0f;
        //        }
        //    }

        //    ////animate the word Tanks
        //    else if (!m_tanksAnimated)
        //    {
        //        if (!m_fireTanks)
        //        {
        //            AudioHandler.GetInstance().PlayAudio(AudioHandler.SoundType.EXPLOSION);
        //            m_fireTanks = true;
        //        }

        //        m_xScalingCoef += .04f;
        //        m_yScalingCoef += .04f;

        //        m_device.Transform.World = Matrix.Scaling(new Vector3(2.0f, 2.0f, 0.0f)) *
        //          Matrix.Translation(new Vector3(-2.0f, 3.0f, 0.0f));

        //        m_badText.Render();

        //        m_device.Transform.World = Matrix.Scaling(new Vector3(2.0f, 2.0f, 0.0f)) *
        //            Matrix.Translation(new Vector3(2.0f, 3.2f, 0.0f));

        //        m_assText.Render();

        //        m_device.Transform.World = Matrix.Scaling(new Vector3(m_xScalingCoef, m_yScalingCoef, 0.0f)) *
        //           Matrix.Translation(new Vector3(0.0f, 1.5f, 0.0f));

        //        m_tanksText.Render();

        //        if (m_xScalingCoef >= 3.0f)
        //        {
        //            m_tanksAnimated = true;

        //            m_xScalingCoef = 0.0f;
        //            m_yScalingCoef = 0.0f;
        //        }
        //    }

        //    //animate the entire menu
        //    else
        //    {
        //        if (!m_introMusicPlaying)
        //        {
        //            AudioHandler.GetInstance().PlayAudio(AudioHandler.SoundType.INTROMUSIC);
        //            m_introMusicPlaying = true;
        //        }

        //        m_device.Transform.World = Matrix.Scaling(new Vector3(2.0f, 2.0f, 0.0f)) *
        //           Matrix.Translation(new Vector3(-2.0f, 3.0f, 0.0f));

        //        m_badText.Render();

        //        m_device.Transform.World = Matrix.Scaling(new Vector3(2.0f, 2.0f, 0.0f)) *
        //            Matrix.Translation(new Vector3(2.0f, 3.2f, 0.0f));

        //        m_assText.Render();

        //        m_device.Transform.World = Matrix.Scaling(new Vector3(3.0f, 3.0f, 0.0f)) *
        //            Matrix.Translation(new Vector3(0.0f, 1.5f, 0.0f));

        //        m_tanksText.Render();


        //        m_device.Transform.World = Matrix.Scaling(new Vector3(1.4f, 1.2f, 0.0f)) *
        //           Matrix.Translation(new Vector3(0.0f, -2.0f, 0.0f));

        //        if (m_selectedOption == Option.STARTGAME)
        //        {
        //            m_device.RenderState.SourceBlend = Blend.SourceAlpha;
        //            m_device.RenderState.DestinationBlend = Blend.One;

        //            m_startText.Render();

        //            m_device.RenderState.SourceBlend = Blend.SourceAlpha;
        //            m_device.RenderState.DestinationBlend = Blend.InvSourceAlpha;

        //            m_device.Transform.World = Matrix.Scaling(new Vector3(1.4f, 1.2f, 0.0f)) *
        //                Matrix.Translation(new Vector3(0.0f, -3.0f, 0.0f));

        //            m_exitText.Render();
        //        }
        //        else if (m_selectedOption == Option.EXIT)
        //        {
        //            m_startText.Render();

        //            m_device.Transform.World = Matrix.Scaling(new Vector3(1.4f, 1.2f, 0.0f)) *
        //                Matrix.Translation(new Vector3(0.0f, -3.0f, 0.0f));

        //            m_device.RenderState.SourceBlend = Blend.SourceAlpha;
        //            m_device.RenderState.DestinationBlend = Blend.One;

        //            m_exitText.Render();

        //            m_device.RenderState.SourceBlend = Blend.SourceAlpha;
        //            m_device.RenderState.DestinationBlend = Blend.InvSourceAlpha;
        //        }
        //    }
            
        //    m_device.Transform.World = saved;
        //}

        //public void Destroy()
        //{
        //    if (m_device != null)
        //    {
        //        m_device.Dispose();
        //        m_device = null;
        //    }
        //}
    }
}
