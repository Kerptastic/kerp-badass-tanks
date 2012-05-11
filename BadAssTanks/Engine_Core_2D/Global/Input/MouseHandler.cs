
namespace BadAssTanks
{
    //
    //
    // The basic functionality of this code was taken from the Microsoft DirectInput sample for
    // retrieving mouse input included in the DirectX 9.0c October Release of the SDK. It has been
    // modified to suit the needs of this application.
    //
    //
    public class MouseHandler
    {
        //public struct MouseData
        //{
        //    public int xChange, yChange;
        //}

        //private Device m_mouse = null;
        //private Form m_hWindow;

        //private MouseData m_mouseData;

        //private GameEngine.IntCoords m_windowMouseCoords;
        //private GameEngine.IntCoords m_screenMouseCoords;

        //private GameEngine.IntCoords m_maxWindowSize;
        //private GameEngine.IntCoords m_maxScreenSize;

        //private bool m_trackingMouse;

        ///// <summary>
        ///// Default constructor.
        ///// </summary>
        ///// <param name="hWindow"> Handle to the window being monitored for mouse input. </param>
        //public MouseHandler(Form hWindow)
        //{
        //    m_hWindow = hWindow;

        //    m_hWindow.Activated += new EventHandler(this.FocusMouse);
        //    m_hWindow.Deactivate += new EventHandler(this.UnfocusMouse);
        //    m_hWindow.MouseLeave += new EventHandler(MouseLeave);
        //    m_hWindow.MouseEnter += new EventHandler(MouseEnter);

        //    m_maxScreenSize.x = Screen.PrimaryScreen.Bounds.Width;
        //    m_maxScreenSize.y = Screen.PrimaryScreen.Bounds.Height;

        //    this.CreateMouse();
        //}

        ///// <summary>
        ///// Create the mouse and set all of the properties
        ///// </summary>
        //private void CreateMouse()
        //{
        //    // Create the device.
        //    try
        //    {
        //        m_mouse = new Device(SystemGuid.Mouse);
        //    }
        //    catch (InputException)
        //    {
        //        MessageBox.Show("Unable to create mouse device.");
        //    }

        //    // Set the cooperative level for the device.
        //    m_mouse.SetCooperativeLevel(m_hWindow,
        //        CooperativeLevelFlags.NonExclusive | CooperativeLevelFlags.Foreground);

        //    // Acquire the device.
        //    this.FocusMouse(null, null);
        //}

        ///// <summary>
        ///// Get all of the buttons that were pressed on the mouse and process
        ///// mouse movement.
        ///// </summary>
        ///// <returns> The buttons that were pressed. </returns>
        //public byte[] ProcessMouse()
        //{
        //    MouseState mouseState = new MouseState();
        //    byte[] buttons = null;

        //    // Get the current state of the mouse device.
        //    try
        //    {
        //        if (m_mouse != null)
        //        {

        //            mouseState = m_mouse.CurrentMouseState;

        //            if (m_trackingMouse)
        //            {
        //                m_mouseData.xChange = m_mouse.CurrentMouseState.X;
        //                m_mouseData.yChange = m_mouse.CurrentMouseState.Y;
        //            }
        //        }

        //        buttons = mouseState.GetMouseButtons();
        //    }
        //    catch (DirectXException)
        //    {
        //        try
        //        {
        //            m_mouse.Acquire();
        //        }
        //        catch (InputLostException)
        //        {
        //        }
        //        catch (InputException)
        //        {
        //        }
        //    }

        //    return buttons;
        //}

        //public MouseData Poll()
        //{
        //    return m_mouseData;
        //}

        ///// <summary>
        ///// Disable the mouse device when the window is not in focus.
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void UnfocusMouse(object sender, EventArgs e)
        //{
        //    if(m_mouse != null)
        //        m_mouse.Unacquire();
        //}

        ///// <summary>
        ///// Places the mouse cursor in the center of the game window.
        ///// </summary>
        //public void CenterMouse(bool windowed)
        //{
        //    m_trackingMouse = true;

        //    m_maxWindowSize.x = m_hWindow.Size.Width;
        //    m_maxWindowSize.y = m_hWindow.Size.Height;

        //    m_maxScreenSize.x = Screen.PrimaryScreen.Bounds.Width;
        //    m_maxScreenSize.y = Screen.PrimaryScreen.Bounds.Height;

        //    GameEngine gEngine = GameEngine.GetInstance();

        //    if (!windowed)
        //    {
        //        //Cursor.Position = new Point((m_maxScreenSize.x) / 2, m_maxScreenSize.y / 2);
        //    }
        //    else
        //    {
        //        Cursor.Position = new Point(
        //            gEngine.GetWindowLocation().x + ((gEngine.GetWindowSize().Width - 4) / 2),
        //            gEngine.GetWindowLocation().y + ((gEngine.GetWindowSize().Height) / 2) + 17);
        //    }
        //}

        ///// <summary>
        ///// Retrieve the mouse coordinates inside the window.
        ///// </summary>
        ///// <returns></returns>
        //public GameEngine.IntCoords GetCoordsInWindow()
        //{
        //    GameEngine.IntCoords wLoc = GameEngine.GetInstance().GetWindowLocation();

        //    m_windowMouseCoords.x = m_screenMouseCoords.x - wLoc.x;
        //    m_windowMouseCoords.y = m_screenMouseCoords.y - wLoc.y;

        //    return m_windowMouseCoords;
        //}

        ///// <summary>
        ///// Retrieve the cursor coordinates that are tracked by Windows.
        ///// </summary>
        ///// <returns></returns>
        //public GameEngine.IntCoords GetCoordsOnScreen()
        //{
        //    m_screenMouseCoords.x = Cursor.Position.X;
        //    m_screenMouseCoords.y = Cursor.Position.Y;

        //    return m_screenMouseCoords;
        //}

        ///// <summary>
        ///// Release the mouse to ensure it isn't held by the application
        ///// when it exits.
        ///// </summary>
        //public void Destroy()
        //{
        //    m_mouse.Unacquire();
        //    m_mouse.Dispose();
        //    m_mouse = null;
        //}

        //private void MouseLeave(object sender, EventArgs e)
        //{
        //    m_trackingMouse = false;
        //}

        //private void MouseEnter(object sender, EventArgs e)
        //{
        //    m_trackingMouse = true;
        //}

        ///// <summary>
        ///// Enable the mouse when the window is in focus.
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void FocusMouse(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        m_mouse.Acquire();
        //    }
        //    catch
        //    {
        //    }
        //}

    }
}
