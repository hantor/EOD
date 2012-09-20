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

namespace Escape_or_Die.Services
{
    public interface IKeyboardManagerService
    {
        bool WasKeyPressed(Keys key);
        bool WasKeyReleased(Keys key);

        bool IsKeyPressed(Keys key);
        bool IsKeyReleased(Keys key);
    }
}
