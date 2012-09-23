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
    public abstract class DynamicGameObject : GameObject
    {
        ICollisionManagerService _iCollisionManagerService;
        Rectangle _collisionRectangle;

        Vector2 _velocity;
        Vector2 _direction;
        float _speed;

        public DynamicGameObject(Game game)
            : base(game)
        {
            _iCollisionManagerService = (ICollisionManagerService)game.Services.GetService(typeof(ICollisionManagerService));
            _iCollisionManagerService.AddDynamicGameObject(this);

            _collisionRectangle = new Rectangle((int)(GetPositionX() - GetOriginX()), (int)(GetPositionY() - GetOriginY()), GetTexture().Width, GetTexture().Height);
            _direction = Vector2.Zero;
            _speed = 100.0f;
        }

        public override void Update(GameTime gameTime)
        {
            SetPositionX(GetPositionX() + _direction.X * _speed * (float)gameTime.ElapsedGameTime.TotalSeconds);
            SetPositionY(GetPositionY() + _direction.Y * _speed * (float)gameTime.ElapsedGameTime.TotalSeconds);

            _velocity = _direction * _speed;
            //Console.WriteLine("Velocity: " + _velocity);

            base.Update(gameTime);
        }

        public virtual void OnCollisionWithStaticGameObject(StaticGameObject staticGameObject)
        {
            if (this.GetPositionX() < staticGameObject.GetPositionX() &&
                this.GetPositionY() < (staticGameObject.GetPositionY() + staticGameObject.GetOriginY()) &&
                this.GetPositionY() > (staticGameObject.GetPositionY() - staticGameObject.GetOriginY()))
            {
            }
        }

        public virtual void OnCollisionWithDynamicGameObject(DynamicGameObject dynamicGameObject)
        {
        }

        public virtual void WhenNotColliding()
        {
        }

        public Rectangle GetCollisionRectangle()
        {
            return _collisionRectangle;
        }

        public float GetSpeed()
        {
            return _speed;
        }

        public Vector2 GetDirection()
        {
            return _direction;
        }

        public void SetDirectionX(float direction)
        {
            _direction.X = direction;
        }

        public void SetDirectionY(float direction)
        {
            _direction.Y = direction;
        }

        public override void SetPositionX(float x)
        {
            _collisionRectangle.X = (int)(x - GetOriginX());

            base.SetPositionX(x);
        }

        public override void SetPositionY(float y)
        {
            _collisionRectangle.Y = (int)(y - GetOriginY());

            base.SetPositionY(y);
        }
    }
}
