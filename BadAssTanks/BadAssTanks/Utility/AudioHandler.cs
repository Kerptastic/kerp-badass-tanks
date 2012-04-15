using System;
using System.Collections;
using System.Text;
using System.IO;


namespace BadAssTanks
{
    public class AudioHandler
    {
        //public static AudioHandler m_instance = null;

        //private Sound.Device m_device = null;

        //private SecondaryBuffer m_gunBuffer = null;
        //private SecondaryBuffer m_explosionBuffer = null;
        //private SecondaryBuffer m_explosion1Buffer = null;
        //private SecondaryBuffer m_missileLaunchBuffer = null;
        //private SecondaryBuffer m_laserBuffer = null;
        //private SecondaryBuffer m_introMusicBuffer = null;
        //private SecondaryBuffer m_beep = null;

        //public enum SoundType
        //{
        //    GUNSHOT, EXPLOSION, EXPLOSION1, INTROMUSIC, MISSILELAUNCH, LASER, BEEP, WARNING
        //}

        //private AudioHandler()
        //{
        //    m_device = new Sound.Device();

        //    m_device.SetCooperativeLevel(new System.Windows.Forms.Form(), CooperativeLevel.Normal);

        //    CreateBuffers();
        //}

        //public static AudioHandler GetInstance()
        //{
        //    if (m_instance == null)
        //        m_instance = new AudioHandler();

        //    return m_instance;
        //}

        //private void CreateBuffers()
        //{
        //    BufferDescription desc = new BufferDescription();
        //    desc.ControlVolume = true;

        //    try
        //    {
        //        m_gunBuffer = new SecondaryBuffer(@"..\Audio\gunshot.wav", m_device);
        //        m_explosionBuffer = new SecondaryBuffer(@"..\Audio\explosion.wav", m_device);
        //        m_explosion1Buffer = new SecondaryBuffer(@"..\Audio\explosion1.wav", m_device);
        //        m_missileLaunchBuffer = new SecondaryBuffer(@"..\Audio\missile_launch.wav", m_device);
        //        m_laserBuffer = new SecondaryBuffer(@"..\Audio\laser.wav", m_device);

        //        m_introMusicBuffer = new SecondaryBuffer(@"..\Audio\intro_music.wav", desc, m_device);

        //        m_beep = new SecondaryBuffer(@"..\Audio\beep.wav", m_device);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

        //public void PlayAudio(SoundType soundType)
        //{
        //    if (soundType == SoundType.GUNSHOT)
        //    {
        //        m_gunBuffer.SetCurrentPosition(0);
        //        m_gunBuffer.Play(0, BufferPlayFlags.Default);
        //    }
        //    else if (soundType == SoundType.EXPLOSION)
        //    {
        //        m_explosionBuffer.SetCurrentPosition(0);
        //        m_explosionBuffer.Play(0, BufferPlayFlags.Default);
        //    }
        //    else if (soundType == SoundType.EXPLOSION1)
        //    {
        //        m_explosion1Buffer.SetCurrentPosition(0);
        //        m_explosion1Buffer.Play(0, BufferPlayFlags.Default);
        //    }
        //    else if (soundType == SoundType.INTROMUSIC)
        //    {
        //        m_introMusicBuffer.SetCurrentPosition(0);
        //        m_introMusicBuffer.Play(0, BufferPlayFlags.Default);
        //    }
        //    else if (soundType == SoundType.MISSILELAUNCH)
        //    {
        //        m_missileLaunchBuffer.SetCurrentPosition(0);
        //        m_missileLaunchBuffer.Play(0, BufferPlayFlags.Default);
        //    }
        //    else if (soundType == SoundType.LASER)
        //    {
        //        m_laserBuffer.SetCurrentPosition(0);
        //        m_laserBuffer.Play(0, BufferPlayFlags.Default);
        //    }
        //    else if (soundType == SoundType.BEEP)
        //    {
        //        m_beep.SetCurrentPosition(0);
        //        m_beep.Play(0, BufferPlayFlags.Default);
        //    }
        //}

        //public void StopAudio(SoundType soundType)
        //{
        //    if (soundType == SoundType.GUNSHOT)
        //    {
        //        m_gunBuffer.SetCurrentPosition(0);
        //        m_gunBuffer.Play(0, BufferPlayFlags.Default);
        //    }
        //    else if (soundType == SoundType.EXPLOSION)
        //    {
        //        m_explosionBuffer.SetCurrentPosition(0);
        //        m_explosionBuffer.Stop();
        //    }
        //    else if (soundType == SoundType.EXPLOSION1)
        //    {
        //        m_explosion1Buffer.SetCurrentPosition(0);
        //        m_explosion1Buffer.Stop();
        //    }
        //    else if (soundType == SoundType.INTROMUSIC)
        //    {
        //        m_introMusicBuffer.SetCurrentPosition(0);
        //        m_introMusicBuffer.Stop();
        //    }
        //    else if (soundType == SoundType.MISSILELAUNCH)
        //    {
        //        m_missileLaunchBuffer.SetCurrentPosition(0);
        //        m_missileLaunchBuffer.Stop();
        //    }
        //    else if (soundType == SoundType.LASER)
        //    {
        //        m_laserBuffer.SetCurrentPosition(0);
        //        m_laserBuffer.Stop();
        //    }
        //    else if (soundType == SoundType.BEEP)
        //    {
        //        m_beep.SetCurrentPosition(0);
        //        m_beep.Stop();
        //    }
        //}

        //public void Destroy()
        //{
        //    if (m_device != null)
        //    {
        //        m_device.Dispose();
        //        m_device = null;
        //    }

        //    m_gunBuffer.Dispose();
        //    m_explosionBuffer.Dispose();
        //    m_explosion1Buffer.Dispose();
        //    m_missileLaunchBuffer.Dispose();
        //    m_laserBuffer.Dispose();
        //    m_introMusicBuffer.Dispose();
        //    m_beep.Dispose();
        //}
    }
}
