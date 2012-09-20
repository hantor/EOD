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

namespace Escape_or_Die.Components
{
    public class KeyboardManagerComponent : GameComponent, IKeyboardManagerService
    {
        KeyboardState _previousKeyboardState;
        KeyboardState _currentKeyboardState;

        public KeyboardManagerComponent(Game game)
            : base(game)
        {
            _previousKeyboardState = new KeyboardState();
            _currentKeyboardState = new KeyboardState();
        }

        public override void Initialize()
        {
            _previousKeyboardState = Keyboard.GetState();
            _currentKeyboardState = _previousKeyboardState;

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            _previousKeyboardState = _currentKeyboardState;
            _currentKeyboardState = Keyboard.GetState();

            base.Update(gameTime);
        }

        public bool WasKeyPressed(Keys key)
        {
            if (_previousKeyboardState.IsKeyUp(key) && _currentKeyboardState.IsKeyDown(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool WasKeyReleased(Keys key)
        {
            if (_previousKeyboardState.IsKeyDown(key) && _currentKeyboardState.IsKeyUp(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsKeyPressed(Keys key)
        {
            if (_previousKeyboardState.IsKeyDown(key) && _currentKeyboardState.IsKeyDown(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsKeyReleased(Keys key)
        {
            if (_previousKeyboardState.IsKeyUp(key) && _currentKeyboardState.IsKeyUp(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
