using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using Escape_or_Die.Components;

namespace Escape_or_Die
{
    public class Sprite
    {
        Texture2D _texture;
        Vector2 _position;
        Rectangle _sourceRectangle;
        Color _color;
        float _rotation;
        Vector2 _origin;
        Vector2 _scale;
        SpriteEffects _effects;
        float _layerDepth;

        public Texture2D Texture { get { return _texture; } }
        public Vector2 Position { get { return _position; } }
        public Rectangle SourceRectangle { get { return _sourceRectangle; } }
        public Color Color { get { return _color; } }
        public float Rotation { get { return _rotation; } }
        public Vector2 Origin { get { return _origin; } }
        public Vector2 Scale { get { return _scale; } }
        public SpriteEffects Effects { get { return _effects; } }
        public float LayerDepth { get { return _layerDepth; } }

        public Sprite(Texture2D texture)
        {
            _texture = texture;
            _position = Vector2.Zero;
            _sourceRectangle = new Rectangle(0, 0, _texture.Width, _texture.Height);
            _color = Color.White;
            _rotation = 0.0f;
            _origin = new Vector2((float)_sourceRectangle.Width / 2.0f, (float)_sourceRectangle.Height / 2.0f);
            _scale = new Vector2(1.0f);
            _effects = SpriteEffects.None;
            _layerDepth = 0.0f;
        }

        public void SetPosition(float x, float y)
        {
            _position.X = x;
            _position.Y = y;
        }
    }
}