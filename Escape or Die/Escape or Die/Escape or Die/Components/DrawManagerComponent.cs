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

namespace Escape_or_Die
{
    public class DrawManagerComponent : DrawableGameComponent, IDrawManagerService
    {
        SpriteBatch _spriteBatch;
        List<Sprite> _sprites;

        Texture2D _squareWhite;
        Texture2D _squareBlack;

        public Texture2D SquareWhite { get { return _squareWhite; } }
        public Texture2D SquareBlack { get { return _squareBlack; } }

        public DrawManagerComponent(Game game)
            : base(game)
        {
            _sprites = new List<Sprite>();
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _squareWhite = Game.Content.Load<Texture2D>("square_white");
            _squareBlack = Game.Content.Load<Texture2D>("square_black");
        }

        protected override void UnloadContent()
        {
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            IEnumerator<Sprite> spritesEnumerator = _sprites.GetEnumerator();
            while (spritesEnumerator.MoveNext())
            {
                _spriteBatch.Draw(
                    spritesEnumerator.Current.Texture,
                    spritesEnumerator.Current.Position,
                    spritesEnumerator.Current.SourceRectangle,
                    spritesEnumerator.Current.Color,
                    spritesEnumerator.Current.Rotation,
                    spritesEnumerator.Current.Origin,
                    spritesEnumerator.Current.Scale,
                    spritesEnumerator.Current.Effects,
                    spritesEnumerator.Current.LayerDepth
                    );
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }


        public void AddSprite(Sprite sprite)
        {
            IEnumerator<Sprite> spritesEnumerator = _sprites.GetEnumerator();
            bool exists = false;

            while (spritesEnumerator.MoveNext())
            {
                if (spritesEnumerator.Current == sprite)
                {
                    exists = true;
                }
            }

            if (!exists)
            {
                _sprites.Add(sprite);
            }
        }

        public void RemoveSprite(Sprite sprite)
        {
            IEnumerator<Sprite> spritesEnumerator = _sprites.GetEnumerator();
            bool exists = false;

            while (spritesEnumerator.MoveNext())
            {
                if (spritesEnumerator.Current == sprite)
                {
                    exists = true;
                }
            }

            if (exists)
            {
                _sprites.Remove(sprite);
            }
        }
    }
}
