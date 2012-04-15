

namespace BadAssTanks
{
    public class TextSprite// : CustomSprite
    {
        //private Device m_device = null; 
        //private Sprite m_sprite = null;
        //private String m_text;

        //private Drawing.Font m_font = null;
        //private Direct3D.Font m_d3dText = null;

        //private float m_xPos, m_yPos, m_facingAngle;

        //private Color m_color;

        ///// <summary>
        ///// Constructor to create the sprite.
        ///// </summary>
        ///// <param name="texture"></param>
        ///// <param name="textureSize"></param>
        //public TextSprite(Device dev, String text, System.Drawing.Font font, float xPos, float yPos, float angle, Color color)
        //{
        //    m_device = dev;

        //    m_xPos = xPos;
        //    m_yPos = yPos;
        //    m_facingAngle = angle;

        //    m_text = text;
        //    m_font = font;

        //    m_d3dText = new Direct3D.Font(m_device, m_font);
        //    m_sprite = new Sprite(m_device);

        //    m_color = color;
        //}

        //public override void SetMaterialColor(Color color)
        //{
        //}

        ///// <summary>
        ///// Move the sprite the desired x and y values.
        ///// </summary>
        ///// <param name="newX"></param>
        ///// <param name="newY"></param>
        //public override void Move(MathHandler translation)
        //{
        //    m_xPos += translation.X;
        //    m_yPos += translation.Y;
        //}

        ///// <summary>
        ///// Rotate the text.
        ///// </summary>
        ///// <param name="angle"> The angle to rotate in degrees. </param>
        //public override void Rotate(float angle)
        //{
        //    //this will need to be re-examined. In order to rotate we will have to use our own bitmaps.
        //    //m_facingAngle += angle;

        //    //if (m_facingAngle >= 360.0f)
        //    //    m_facingAngle = 0.0f;
        //    //else if (m_facingAngle < 0)
        //    //    m_facingAngle += 360.0f;
        //}

        //public override void SetFacingAngle(float angleInDegrees)
        //{

        //}

        //public override void SetLocation(float x, float y)
        //{
        //    m_xPos = x;
        //    m_yPos = y;
        //}

        ///// <summary>
        ///// Returns the x position of the text.
        ///// </summary>
        ///// <returns></returns>
        //public override float GetXPos()
        //{
        //    return m_xPos;
        //}

        ///// <summary>
        ///// Returns the y position of the text.
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

        //public void SetText(String text)
        //{
        //    m_text = text;
        //}

        ///// <summary>
        ///// Draw the sprite.
        ///// </summary>
        //public override void Render()
        //{
        //    m_sprite.Begin(SpriteFlags.SortTexture | SpriteFlags.AlphaBlend);

        //    m_d3dText.DrawText(m_sprite, m_text, (int)m_xPos, (int)m_yPos, m_color);

        //    m_sprite.End();
        //}

        ///// <summary>
        ///// Destroy the memory holding the device.
        ///// </summary>
        //public override void Destroy()
        //{
        //    if (m_sprite != null)
        //    {
        //        m_sprite.Dispose();
        //        m_sprite = null;
        //    }

        //    if (m_d3dText != null)
        //    {
        //        m_d3dText.Dispose();
        //        m_d3dText = null;
        //    }

        //    if (m_font != null)
        //    {
        //        m_font.Dispose();
        //        m_font = null;
        //    }

        //    if (m_device != null)
        //    {
        //        m_device.Dispose();
        //        m_device = null;
        //    }
        //}
    }
}

