using System;
using System.Drawing;

namespace BadAssTanks
{
    public class UnanimatedSprite : CustomSprite
    {
        //private Device m_device = null;
        //private Texture m_texture = null;
        //private Material mat = new Material();

        //private VertexBuffer m_vBuffer = null;
        //private CustomVertex.PositionNormalTextured[] m_verts = null;

        //private float m_xPos, m_yPos, m_facingAngle;

        ///// <summary>
        ///// Constructor to create the sprite.
        ///// </summary>
        ///// <param name="dev"></param>
        ///// <param name="texture"></param>
        ///// <param name="xPos"></param>
        ///// <param name="yPos"></param>
        ///// <param name="angle"></param>
        //public UnanimatedSprite(Device dev, Texture texture, float xPos, float yPos, float angle)
        //{
        //    m_device = dev;

        //    m_xPos = xPos;
        //    m_yPos = yPos;
        //    m_facingAngle = angle;

        //    m_texture = texture;

        //    mat.Diffuse = Color.White;

        //    m_vBuffer = new VertexBuffer(typeof(CustomVertex.PositionNormalTextured), 6, m_device, Usage.Dynamic | Usage.WriteOnly,
        //        CustomVertex.PositionNormalTextured.Format, Pool.Default);

        //    m_vBuffer.Created += new EventHandler(OnVBufferCreate);
        //    this.OnVBufferCreate(m_vBuffer, null);
        //}

        ///// <summary>
        ///// Move the sprite the desired x and y values.
        ///// </summary>
        ///// <param name="newX"></param>
        ///// <param name="newY"></param>
        //public override void Move(MathHandler moveVector)
        //{
        //    m_xPos += moveVector.X;
        //    m_yPos += moveVector.Y;
        //}

        ///// <summary>
        ///// Rotate the sprite.
        ///// </summary>
        ///// <param name="angle"> The angle to rotate in degrees. </param>
        //public override void Rotate(float angle)
        //{
        //    m_facingAngle += angle;

        //    if (m_facingAngle >= 360.0f)
        //        m_facingAngle = 0.0f;
        //    else if (m_facingAngle < 0)
        //        m_facingAngle += 360.0f;
        //}

        ///// <summary>
        ///// Draw the sprite.
        ///// </summary>
        //public override void Render()
        //{
        //    m_device.Material = mat;

        //    m_device.VertexFormat = CustomVertex.PositionNormalTextured.Format;
        //    m_device.SetStreamSource(0, m_vBuffer, 0);
        //    m_device.SetTexture(0, m_texture);

        //    m_device.RenderState.AlphaBlendEnable = true;
        //    m_device.DrawPrimitives(PrimitiveType.TriangleList, 0, 2);
        //    m_device.RenderState.AlphaBlendEnable = false;
        //}

        //public override void SetMaterialColor(Color color)
        //{
        //    mat.Diffuse = color;
        //}

        //public override void SetFacingAngle(float angleInDegrees)
        //{
        //    this.m_facingAngle = angleInDegrees;
        //}

        //public override void SetLocation(float x, float y)
        //{
        //    m_xPos = x;
        //    m_yPos = y;
        //}

        ///// <summary>
        ///// Returns the x position of the sprite.
        ///// </summary>
        ///// <returns></returns>
        //public override float GetXPos()
        //{
        //    return m_xPos;
        //}

        ///// <summary>
        ///// Returns the y position of the sprite.
        ///// </summary>
        ///// <returns></returns>
        //public override float GetYPos()
        //{
        //    return m_yPos;
        //}

        ///// <summary>
        ///// Get the sprites current facing angle.
        ///// </summary>
        ///// <returns></returns>
        //public override float GetFacingAngle()
        //{
        //    return m_facingAngle;
        //}

        ///// <summary>
        ///// Get the sprites current facing angle in radians.
        ///// </summary>
        ///// <returns></returns>
        //public override float GetFacingAngleInRadians()
        //{
        //    return m_facingAngle * (float)Math.PI / 180.0f;
        //}

        ///// <summary>
        ///// Destroy the memory holding the device.
        ///// </summary>
        //public override void Destroy()
        //{
        //    if (m_vBuffer != null)
        //    {
        //        m_vBuffer.Dispose();
        //        m_vBuffer = null;
        //    }
        //}

        ///// <summary>
        ///// Recreates the vertex buffer for the sprite when it is initially created
        ///// or when the device is destroyed.
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void OnVBufferCreate(object sender, EventArgs e)
        //{
        //    VertexBuffer vBuffer = (VertexBuffer)sender;

        //    m_verts = new CustomVertex.PositionNormalTextured[6];

        //    //get the surface normals for the 2 triangles

        //    //yes this is worthless but the correct way to think about it
        //    VectorMath vMath = new VectorMath();

        //    Vector3 normal1 = 
        //        vMath.GetSurfaceNormal(new Vector3(-1.0f, 1.0f, 0.0f), new Vector3(-1.0f, -1.0f, 0.0f), new Vector3(1.0f, 1.0f, 0.0f));

        //    Vector3 normal2 =
        //        vMath.GetSurfaceNormal(new Vector3(-1.0f, -1.0f, 0.0f), new Vector3(1.0f, -1.0f, 0.0f), new Vector3(1.0f, 1.0f, 0.0f));

        //    m_verts[0] = new CustomVertex.PositionNormalTextured(new Vector3(-1.0f, 1.0f, 0.0f), normal1, 0.0f, 0.0f);
        //    m_verts[1] = new CustomVertex.PositionNormalTextured(new Vector3(-1.0f, -1.0f, 0.0f), normal1, 0.0f, 1.0f);
        //    m_verts[2] = new CustomVertex.PositionNormalTextured(new Vector3(1.0f, 1.0f, 0.0f), normal1, 1.0f, 0.0f);
        //    m_verts[3] = new CustomVertex.PositionNormalTextured(new Vector3(-1.0f, -1.0f, 0.0f), normal2, 0.0f, 1.0f);
        //    m_verts[4] = new CustomVertex.PositionNormalTextured(new Vector3(1.0f, -1.0f, 0.0f), normal2, 1.0f, 1.0f);
        //    m_verts[5] = new CustomVertex.PositionNormalTextured(new Vector3(1.0f, 1.0f, 0.0f), normal2, 1.0f, 0.0f);
            
        //    vBuffer.SetData(m_verts, 0, LockFlags.None);
        //}
    }
}