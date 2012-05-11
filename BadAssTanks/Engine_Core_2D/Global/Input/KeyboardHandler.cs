
namespace BadAssTanks
{
    //
    //
    // The basic functionality of this code was taken from the Microsoft DirectInput sample for
    // retrieving keyboard input included in the DirectX 9.0c October Release of the SDK. It has been
    // modified to suit the needs of this application.
    //
    //
    public class KeyboardHandler
    {
        //private Device m_keyboard;
        //private int m_defaultBufferSize = 8;

        //private ArrayList m_keys;

        //private Form m_hWindow;

        //private CooperativeLevelFlags m_coopLevelFlags;
        //private ReadMode m_mode;
        //private Exclusiveness m_excl;
        //private Focus m_focus;

        //private bool m_winKeyActive;

        //public enum ReadMode
        //{
        //    IMMEDIATE, BUFFERED
        //}

        //public enum Exclusiveness
        //{
        //    EXCLUSIVE, NONEXCLUSIVE
        //}

        //public enum Focus
        //{
        //    FOREGROUND, BACKGROUND
        //}

        ///// <summary>
        ///// Constructor to create the keyboard handler. Accepts the read mode that dictates
        ///// how the handler will attempt to access data. Initializes the timer to the desired
        ///// polling interval.
        ///// </summary>
        ///// <param name="mode"></param>
        //public KeyboardHandler(ref ArrayList keys, ReadMode mode, Exclusiveness excl, 
        //    Focus focus, bool winKeyActive, int timerIntervalInMilli, Form window)
        //{
        //    m_hWindow = window;

        //    m_keys = keys;
        //    m_mode = mode;
        //    m_excl = excl;
        //    m_focus = focus;
        //    m_winKeyActive = winKeyActive;

        //    // Create the keyboard
        //    this.CreateKeyboard();
        //}

        ///// <summary>
        ///// Creates the keyboard device object.  This will be called internally in order
        ///// to make sure there is one keyboard for each handler object.
        ///// </summary>
        //private void CreateKeyboard()
        //{
        //    // Check and see if the device is created already -- if so, unacquire and reacquire
        //    if (m_keyboard != null)
        //    {
        //        this.Destroy();
        //    }

        //    // Setup the exclusiveness of the keyboard
        //    if (m_excl == Exclusiveness.EXCLUSIVE)
        //    {
        //        m_coopLevelFlags = CooperativeLevelFlags.Exclusive;
        //    }
        //    else
        //    {
        //        m_coopLevelFlags = CooperativeLevelFlags.NonExclusive;
        //    }

        //    // Set the focus level
        //    if (m_focus == Focus.FOREGROUND)
        //    {
        //        m_coopLevelFlags |= CooperativeLevelFlags.Foreground;
        //    }
        //    else
        //    {
        //        m_coopLevelFlags |= CooperativeLevelFlags.Background;
        //    }

        //    // Disable the windows key only allowed if foreground nonexclusive mode
        //    if (!m_winKeyActive && m_excl != Exclusiveness.EXCLUSIVE && m_focus == Focus.FOREGROUND)
        //    {
        //        m_coopLevelFlags |= CooperativeLevelFlags.NoWindowsKey;
        //    }

        //    try
        //    {
        //        m_keyboard = new Device(SystemGuid.Keyboard);
        //        m_keyboard.SetCooperativeLevel(m_hWindow, m_coopLevelFlags);
        //    }
        //    catch (InputException e)
        //    {
        //        this.Destroy();
        //        MessageBox.Show("Unable to create Keyboard object: " + e.Message);
        //    }
        //    catch (DirectXException e)
        //    {
        //        this.Destroy();
        //        MessageBox.Show("Unable to create Keyboard object: " + e.Message);
        //    }

        //    // Since DirectInput uses unbuffered I/O (buffersize = 0) by default
        //    // you need to set a nonzero buffer size for buffered data
        //    if (m_mode == ReadMode.BUFFERED)
        //    {
        //        try
        //        {
        //            m_keyboard.Properties.BufferSize = m_defaultBufferSize;
        //        }
        //        catch (DirectXException e)
        //        {
        //            MessageBox.Show("Could not set buffer size: " + e.Message);
        //        }
        //    }

        //    try
        //    {
        //        m_keyboard.Acquire();
        //    }
        //    catch (OtherApplicationHasPriorityException e)
        //    {
        //        String msg = e.Message;
        //    }
        //}

        ///// <summary>
        ///// Event handler for handling the keyboard input poll. Fired after every timer interval.
        ///// </summary>
        ///// <param name="obj"></param>
        ///// <param name="e"></param>
        //private void OnKeyboardPolled(object obj, EventArgs e)
        //{
        //    if (m_mode == ReadMode.BUFFERED)
        //    {
        //        if (!ReadBufferedData())
        //        {
        //            this.Destroy();
        //            MessageBox.Show("Error reading buffered keyboard input.");
        //        }
        //    }
        //    else
        //    {
        //        if (!ReadImmediateData())
        //        {
        //            this.Destroy();
        //            MessageBox.Show("Error reading immediate keyboard input.");
        //        }
        //    }
        //}

        ///// <summary>
        ///// Release the keyboard to ensure it isn't held by the application
        ///// when it exits.
        ///// </summary>
        //public void Destroy()
        //{
        //    m_keyboard.Unacquire();
        //    m_keyboard.Dispose();
        //    m_keyboard = null;
        //}

        ///// <summary>
        ///// Read the keyboard's state when in buffered mode.
        ///// </summary>
        ///// <returns></returns>
        //public bool ReadBufferedData()
        //{
        //    BufferedDataCollection data = null;

        //    if (m_keyboard == null)
        //        return true;

        //    InputException ie = null;

        //    try
        //    {
        //        data = m_keyboard.GetBufferedData();
        //    }
        //    catch (InputException e)
        //    {
        //        ie = e;
        //    }

        //    if (ie != null)
        //        return false;

        //    if (data == null)
        //        return true;

        //    return true;
        //}

        ///// <summary>
        ///// Read the keyboard's state when in immediate mode.
        ///// </summary>
        ///// <returns></returns>
        //public bool ReadImmediateData()
        //{
        //    KeyboardState kbState = null;

        //    if (m_keyboard == null)
        //        return true;

        //    try
        //    {
        //        kbState = m_keyboard.GetCurrentKeyboardState();
        //    }
        //    catch (DirectXException)
        //    {
        //        try
        //        {
        //            m_keyboard.Acquire();
        //        }
        //        catch (InputLostException)
        //        {
        //        }
        //        catch (InputException)
        //        {
        //        }

        //        return true;
        //    }

        //    for (Key key = Key.Escape; key <= Key.MediaSelect; key++)
        //    {
        //        if (kbState[key])
        //            m_keys.Add(key);
        //    }

        //    return true;
        //}
    }
}
