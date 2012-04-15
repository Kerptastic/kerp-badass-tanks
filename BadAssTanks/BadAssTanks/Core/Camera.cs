using System;
using System.Drawing;

namespace BadAssTanks
{
    public class Camera
    {
        //private Device m_device;

        //private Vector3 m_position;
        //private Vector3 m_target;
        //private Vector3 m_up;

        ///// <summary>
        ///// Creates a new camera for viewing the world.
        ///// </summary>
        ///// <param name="device"> Reference to the Direct3D device linked to the game. </param>
        //public Camera(Device device)
        //{
        //    m_device = device;
        //}

        ///// <summary>
        ///// Initializes the camera and its vectors.
        ///// </summary>
        ///// <param name="position"> Position where the camera is located. </param>
        ///// <param name="target"></param>
        ///// <param name="up"></param>
        //public void InitializeCamera(Vector3 position, Vector3 target, Vector3 up)
        //{
        //    m_position = position;
        //    m_target = target;
        //    m_up = up;
        //}

        ///// <summary>
        ///// Move the camera in the desired X and Y direction.
        ///// </summary>
        ///// <param name="addX"> The amount to move the camera in the X direction. </param>
        ///// <param name="addY"> The amount to move the camera in the Y direction. </param>
        //public void Move(float addX, float addY)
        //{
        //    m_position = new Vector3(m_position.X + addX, m_position.Y + addY, m_position.Z);
        //    m_target = new Vector3(m_target.X + addX, m_target.Y + addY, m_target.Z); 
        //}

        ///// <summary>
        ///// Reset the camera.
        ///// </summary>
        //public void ResetCamera()
        //{
        //    m_device.RenderState.CullMode = Cull.None;

        //    m_device.Transform.View = Matrix.LookAtLH(m_position, m_target, m_up);
        //    m_device.Transform.Projection = Matrix.PerspectiveFovLH((float)Math.PI / 2.4f, 1.0f, 1.0f, 100.0f);
            
        //    m_device.RenderState.Lighting = true;
           
        //    m_device.Lights[0].Type = LightType.Directional;
        //    m_device.Lights[0].Diffuse = Color.White;
        //    m_device.Lights[0].Direction = new Vector3(0.0f, 0.0f, -1.0f);
        //    m_device.Lights[0].Enabled = true;
        //}

        //public void SetPosition(float x, float y)
        //{
        //    this.InitializeCamera(new Vector3(x, y, -10.0f), new Vector3(0.0f, 0.0f, 0.0f),
        //        new Vector3(0.0f, 1.0f, 0.0f));
        //}
       
        ///// <summary>
        ///// Destroy the unmanaged memory.
        ///// </summary>
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
