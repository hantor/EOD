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
    public class StaticCrate : StaticGameObject
    {
        IDrawManagerService _iDrawManagerService;

        public StaticCrate(Game game)
            : base(game)
        {
            _iDrawManagerService = (IDrawManagerService)game.Services.GetService(typeof(IDrawManagerService));

            SetTexture(_iDrawManagerService.SquareBlack);
            SetLayerDepth(0.5f);

            SetPositionX(800.0f);
            SetPositionY(300.0f);
        }
    }
}
