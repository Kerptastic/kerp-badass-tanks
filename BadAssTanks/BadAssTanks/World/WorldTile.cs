using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace BadAssTanks
{
    class WorldTile
    {
        private CustomSprite m_sprite = null;

        private float xPos, yPos;

        public WorldTile(CustomSprite sprite)
        {
            m_sprite = sprite;
        }

        public void SetLocation(float x, float y)
        {
            xPos = x;
            yPos = y;

            m_sprite.SetLocation(x, y);
        }

        public CustomSprite GetSprite()
        {
            return m_sprite;
        }

        public void Render()
        {
            m_sprite.Render();
        }

        public void Destroy()
        {
            if(m_sprite != null)
                m_sprite.Destroy();
        }
    }
}
