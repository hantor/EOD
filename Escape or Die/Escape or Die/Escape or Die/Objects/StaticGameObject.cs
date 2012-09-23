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
    public abstract class StaticGameObject : GameObject
    {
        ICollisionManagerService _iCollisionManagerService;
        Rectangle _collisionRectangle;

        public StaticGameObject(Game game)
            : base(game)
        {
            _iCollisionManagerService = (ICollisionManagerService)game.Services.GetService(typeof(ICollisionManagerService));
            _iCollisionManagerService.AddStaticGameObject(this);

            _collisionRectangle = new Rectangle((int)(GetPositionX() - GetOriginX()), (int)(GetPositionY() - GetOriginY()), GetTexture().Width, GetTexture().Height);
        }

        public Rectangle GetCollisionRectangle()
        {
            return _collisionRectangle;
        }

        public virtual void OnCollisionWithDynamicGameObject(DynamicGameObject dynamicGameObject)
        {
        }

        public virtual void WhenNotColliding()
        {
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
