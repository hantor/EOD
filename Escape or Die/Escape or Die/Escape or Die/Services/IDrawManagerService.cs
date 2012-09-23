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

using Escape_or_Die.Objects;

namespace Escape_or_Die
{
    public interface IDrawManagerService
    {
        Texture2D SquareWhite { get; }
        Texture2D SquareBlack { get; }

        void AddGameObject(GameObject gameObject);
        void RemoveGameObject(GameObject gameObject);
    }
}
