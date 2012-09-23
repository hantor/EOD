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
    public class Player : DynamicGameObject
    {
        IDrawManagerService _iDrawManagerService;
        IKeyboardManagerService _iKeyboardManagerService;

        public Player(Game game)
            : base(game)
        {
            _iDrawManagerService = (IDrawManagerService)game.Services.GetService(typeof(IDrawManagerService));
            _iKeyboardManagerService = (IKeyboardManagerService)game.Services.GetService(typeof(IKeyboardManagerService));

            SetTexture(_iDrawManagerService.SquareWhite);
            SetLayerDepth(0.4f);

            SetPositionX(600.0f);
            SetPositionY(300.0f);
        }

        public override void Update(GameTime gameTime)
        {
            if (_iKeyboardManagerService.IsKeyPressed(Keys.Up) && _iKeyboardManagerService.IsKeyReleased(Keys.Down))
            {
                SetDirectionY(-1.0f);
            }
            else if (_iKeyboardManagerService.IsKeyPressed(Keys.Down) && _iKeyboardManagerService.IsKeyReleased(Keys.Up))
            {
                SetDirectionY(1.0f);
            }
            else
            {
                SetDirectionY(0.0f);
            }

            if (_iKeyboardManagerService.IsKeyPressed(Keys.Left) && _iKeyboardManagerService.IsKeyReleased(Keys.Right))
            {
                SetDirectionX(-1.0f);
            }
            else if (_iKeyboardManagerService.IsKeyPressed(Keys.Right) && _iKeyboardManagerService.IsKeyReleased(Keys.Left))
            {
                SetDirectionX(1.0f);
            }
            else
            {
                SetDirectionX(0.0f);
            }

            base.Update(gameTime);
        }
    }
}
