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

using Escape_or_Die.Services;

namespace Escape_or_Die.Objects
{
    public abstract class GameObject
    {
        IDrawManagerService _iDrawManagerService;

        Texture2D _texture;
        Vector2 _position;
        Rectangle _sourceRectangle;
        Color _color;
        float _rotation;
        Vector2 _origin;
        Vector2 _scale;
        SpriteEffects _effects;
        float _layerDepth;

        public GameObject(Game game)
        {
            _iDrawManagerService = (IDrawManagerService)game.Services.GetService(typeof(IDrawManagerService));
            _iDrawManagerService.AddGameObject(this);

            _texture = _iDrawManagerService.SquareWhite;
            _position = Vector2.Zero;
            _sourceRectangle = new Rectangle(0, 0, _texture.Width, _texture.Height);
            _color = Color.White;
            _rotation = 0.0f;
            _origin = new Vector2((float)_sourceRectangle.Width / 2.0f, (float)_sourceRectangle.Height / 2.0f);
            SetScale(new Vector2(1.0f, 1.0f));
            SetEffects(SpriteEffects.None);
            SetLayerDepth(0.0f);
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public Texture2D GetTexture()
        {
            return _texture;
        }

        public virtual void SetTexture(Texture2D texture)
        {
            _texture = texture;
            _sourceRectangle.Width = _texture.Width;
            _sourceRectangle.Height = _texture.Height;
            _origin.X = (float)_sourceRectangle.Width / 2.0f;
            _origin.Y = (float)_sourceRectangle.Height / 2.0f;
        }

        public Vector2 GetPosition()
        {
            return _position;
        }

        public float GetPositionX()
        {
            return _position.X;
        }

        public virtual void SetPositionX(float x)
        {
            _position.X = x;
        }

        public float GetPositionY()
        {
            return _position.Y;
        }

        public virtual void SetPositionY(float y)
        {
            _position.Y = y;
        }

        public Rectangle GetSourceRectangle()
        {
            return _sourceRectangle;
        }

        public Color GetColor()
        {
            return _color;
        }

        public float GetRotation()
        {
            return _rotation;
        }

        public Vector2 GetOrigin()
        {
            return _origin;
        }

        public float GetOriginX()
        {
            return _origin.X;
        }

        public float GetOriginY()
        {
            return _origin.Y;
        }

        public Vector2 GetScale()
        {
            return _scale;
        }

        public virtual void SetScale(Vector2 scale)
        {
            _scale = scale;
        }

        public SpriteEffects GetEffects()
        {
            return _effects;
        }

        public virtual void SetEffects(SpriteEffects effects)
        {
            _effects = effects;
        }

        public float GetLayerDepth()
        {
            return _layerDepth;
        }

        public virtual void SetLayerDepth(float layerDepth)
        {
            _layerDepth = layerDepth;
        }
    }
}
