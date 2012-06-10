using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KerpEngine.Engine_2D.Sprites
{
    /// <summary>
    /// Base class defining the behavior required for all Sprites in the
    /// Game Engine. It is implied that a Sprite will be a 2D image on a screen.
    /// </summary>
    public abstract class CustomSprite
    {
        /// <summary>
        /// The Texture that will be drawn for this Sprite.
        /// </summary>
        protected Texture2D _texture;
        public Texture2D Texture { get { return _texture; } set { _texture = value; } }
        /// <summary>
        /// The width of the Sprite.
        /// </summary>
        protected float _width;
        public float Width { get { return _width; } }
        /// <summary>
        /// The height of the Sprite.
        /// </summary>
        protected float _height;
        public float Height { get { return _height; } }
        /// <summary>
        /// The vertices to be used when drawing to the screen using the
        /// GraphicsDevice instead of the SpriteBatch.
        /// </summary>
        protected VertexPositionNormalTexture[] _vertices;
        /// <summary>
        /// The indices to reference which vertices to draw when using the
        /// GraphicsDevice instead of the SpritBatch when drawing to the screen.
        /// </summary>
        protected int[] _indices;

        /// <summary>
        /// Creates a new Sprite with the given Texture, width, and height.
        /// </summary>
        /// <param name="texture">The Texture that will be drawn for this Sprite.</param>
        /// <param name="width">The width of the sprite before any scaling.</param>
        /// <param name="height">The height of the sprite before any scaling.</param>
        public CustomSprite(Texture2D texture, float width, float height)
        {
            _texture = texture;
            _width = width;
            _height = height;

            this.SetupSprite();
        }

        /// <summary>
        /// Setup the vertices for the Sprite to be drawn to the screen.
        /// </summary>
        private void SetupSprite()
        {
            _vertices = new VertexPositionNormalTexture[4];
            _indices = new int[6];
            
            //the normal is facing the camera, with -Z pointing out of the screen
            Vector3 normal = new Vector3(0.0f, 0.0f, -1.0f);

            //setup upper left Vector3
            _vertices[0].Position = new Vector3(-_width / 2.0f, _height / 2.0f, 0.0f);
            _vertices[0].TextureCoordinate = new Vector2(0.0f, 0.0f);
            _vertices[0].Normal = normal;

            //setup upper right Vector3
            _vertices[1].Position = new Vector3(_width / 2.0f, _height / 2.0f, 0.0f);
            _vertices[1].TextureCoordinate = new Vector2(1.0f, 0.0f);
            _vertices[1].Normal = normal;

            //setup lower left Vector3
            _vertices[2].Position = new Vector3(-_width / 2.0f, -_height / 2.0f, 0.0f);
            _vertices[2].TextureCoordinate = new Vector2(0.0f, 1.0f);
            _vertices[2].Normal = normal;

            //setup lower right Vector3
            _vertices[3].Position = new Vector3(_width / 2.0f, -_height / 2.0f, 0.0f);
            _vertices[3].TextureCoordinate = new Vector2(1.0f, 1.0f);
            _vertices[3].Normal = normal;

            //setup the indices, first 3 for triangle 1, second 3 for triangle 2
            //
            //  Triangle 1     Triangle 2
            //    0---1              1
            //    |  /              /|
            //    | /      +       / |
            //    |/              /  | 
            //    2              2---3
            _indices[0] = 0;
            _indices[1] = 1;
            _indices[2] = 2;
            _indices[3] = 1;
            _indices[4] = 3;
            _indices[5] = 2;
        }

        /// <summary>
        /// Draws the Sprite to the screen using a 3D method of display, thus
        /// not using a SpriteBatch.
        /// </summary>
        /// <param name="device">The GraphicsDevice to perform the drawing.</param>
        /// <param name="effect">The effect to use while drawing.</param>
        public abstract void Draw(GraphicsDevice device, BasicEffect effect);

        /// <summary>
        /// Draws this Sprite to the Screen using a SpriteBatch.
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch to perform the drawing.</param>
        /// <param name="position">The position to draw the Sprite on the screen.</param>
        /// <param name="rotation">The rotation of the Sprite to be drawn.</param>
        /// <param name="scale">The scale of the Sprite to be drawn.</param>
        /// <param name="textureTint">The tint to draw the Sprite.</param>
        /// <param name="effects">The SpriteEffects to draw with the Sprite.</param>
        /// <param name="layerDepth">The layer at which to draw the Sprite.</param>
        public abstract void Draw(SpriteBatch spriteBatch, Vector3 position, float rotation, float scale,
            Color textureTint, SpriteEffects effects, float layerDepth);

        /// <summary>
        /// Draws this Sprite to the Screen using a SpriteBatch.
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch to perform the drawing.</param>
        /// <param name="position">The position to draw the Sprite on the screen.</param>
        /// <param name="rotationOrigin">The point to perform the rotation around.</param>
        /// <param name="rotation">The rotation of the Sprite to be drawn.</param>
        /// <param name="scale">The scale of the Sprite to be drawn.</param>
        /// <param name="textureTint">The tint to draw the Sprite.</param>
        /// <param name="effects">The SpriteEffects to draw with the Sprite.</param>
        /// <param name="layerDepth">The layer at which to draw the Sprite.</param>
        public abstract void Draw(SpriteBatch spriteBatch, Vector3 position, Vector3 rotationOrigin, float rotation,
            float scale, Color textureTint, SpriteEffects effects, float layerDepth);

        /// <summary>
        /// Draws this Sprite to the Screen using a SpriteBatch.
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch to perform the drawing.</param>
        /// <param name="position">The position to draw the Sprite on the screen.</param>
        /// <param name="rotationOrigin">The point to perform the rotation around.</param>
        /// <param name="rotation">The rotation of the Sprite to be drawn.</param>
        /// <param name="scale">The scale of the Sprite to be drawn.</param>
        /// <param name="sourceRectangle">The texels to draw for this Sprite.</param>
        /// <param name="textureTint">The tint to draw the Sprite.</param>
        /// <param name="effects">The SpriteEffects to draw with the Sprite.</param>
        /// <param name="layerDepth">The layer at which to draw the Sprite.</param>
        public abstract void Draw(SpriteBatch spriteBatch, Vector3 position, Vector3 rotationOrigin, float rotation, 
            float scale, Rectangle? sourceRectangle, Color textureTint,  SpriteEffects effects, float layerDepth);
    }
}
