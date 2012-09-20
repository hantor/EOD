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

using Escape_or_Die.Interfaces;
using Escape_or_Die.Services;

namespace Escape_or_Die
{
    /// <summary>
    /// Implement proper steering.
    /// </summary>
    public class Player : GameObject, IDynamicCollideable
    {
        ICollisionDetectionService _iCollisionDetectionService;
        IKeyboardManagerService _iKeyboardManagerService;
        IDrawManagerService _iDrawManagerService;

        Sprite _sprite;
        Rectangle _collisionRectangle;

        public Player(Game game)
        {
            _iKeyboardManagerService = (IKeyboardManagerService)game.Services.GetService(typeof(IKeyboardManagerService));
            
            _iDrawManagerService = (IDrawManagerService)game.Services.GetService(typeof(IDrawManagerService));
            _collisionRectangle = new Rectangle(0, 0, _iDrawManagerService.SquareWhite.Width, _iDrawManagerService.SquareWhite.Height);

            _sprite = new Sprite(_iDrawManagerService.SquareWhite);
            _sprite.SetPosition(100.0f, 100.0f);

            _iDrawManagerService.AddSprite(_sprite);

            _iCollisionDetectionService = (ICollisionDetectionService)game.Services.GetService(typeof(ICollisionDetectionService));
            _iCollisionDetectionService.AddDynamicCollideable(this);
            _collisionRectangle = new Rectangle((int)(_sprite.Position.X - _sprite.Origin.X), (int)(_sprite.Position.Y - _sprite.Origin.Y), _iDrawManagerService.SquareWhite.Width, _iDrawManagerService.SquareWhite.Height);
        }

        public override void Update(GameTime gameTime)
        {
            if (_iKeyboardManagerService.IsKeyPressed(Keys.Up))
            {
                _sprite.SetPosition(_sprite.Position.X, _sprite.Position.Y + (-200.0f * (float)gameTime.ElapsedGameTime.TotalSeconds));
            }

            if (_iKeyboardManagerService.IsKeyPressed(Keys.Down))
            {
                _sprite.SetPosition(_sprite.Position.X, _sprite.Position.Y + (200.0f * (float)gameTime.ElapsedGameTime.TotalSeconds));
            }

            if (_iKeyboardManagerService.IsKeyPressed(Keys.Left))
            {
                _sprite.SetPosition(_sprite.Position.X + (-200.0f * (float)gameTime.ElapsedGameTime.TotalSeconds), _sprite.Position.Y);
            }

            if (_iKeyboardManagerService.IsKeyPressed(Keys.Right))
            {
                _sprite.SetPosition(_sprite.Position.X + (200.0f * (float)gameTime.ElapsedGameTime.TotalSeconds), _sprite.Position.Y);
            }

            base.Update(gameTime);
        }

        public void OnCollisionWithStaticCollideable(IStaticCollideable staticCollideable)
        {
        }

        public void OnCollisionWithDynamicCollideable(IDynamicCollideable dynamicCollideable)
        {
        }

        public Rectangle CollisionRectangle
        {
            get
            {
                return _collisionRectangle;
            }
        }
    }
}
