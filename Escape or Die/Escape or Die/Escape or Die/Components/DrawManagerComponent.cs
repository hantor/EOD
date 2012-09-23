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
    public class DrawManagerComponent : DrawableGameComponent, IDrawManagerService
    {
        SpriteBatch _spriteBatch;
        List<GameObject> _gameObjects;

        Texture2D _squareWhite;
        Texture2D _squareBlack;

        public Texture2D SquareWhite { get { return _squareWhite; } }
        public Texture2D SquareBlack { get { return _squareBlack; } }

        public DrawManagerComponent(Game game)
            : base(game)
        {
            _gameObjects = new List<GameObject>();
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

            IEnumerator<GameObject> spritesEnumerator = _gameObjects.GetEnumerator();
            while (spritesEnumerator.MoveNext())
            {
                _spriteBatch.Draw(
                    spritesEnumerator.Current.GetTexture(),
                    spritesEnumerator.Current.GetPosition(),
                    spritesEnumerator.Current.GetSourceRectangle(),
                    spritesEnumerator.Current.GetColor(),
                    spritesEnumerator.Current.GetRotation(),
                    spritesEnumerator.Current.GetOrigin(),
                    spritesEnumerator.Current.GetScale(),
                    spritesEnumerator.Current.GetEffects(),
                    spritesEnumerator.Current.GetLayerDepth()
                    );
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }


        public void AddGameObject(GameObject gameObject)
        {
            IEnumerator<GameObject> spritesEnumerator = _gameObjects.GetEnumerator();
            bool exists = false;

            while (spritesEnumerator.MoveNext())
            {
                if (spritesEnumerator.Current == gameObject)
                {
                    exists = true;
                }
            }

            if (!exists)
            {
                _gameObjects.Add(gameObject);
            }
        }

        public void RemoveGameObject(GameObject gameObject)
        {
            IEnumerator<GameObject> spritesEnumerator = _gameObjects.GetEnumerator();
            bool exists = false;

            while (spritesEnumerator.MoveNext())
            {
                if (spritesEnumerator.Current == gameObject)
                {
                    exists = true;
                }
            }

            if (exists)
            {
                _gameObjects.Remove(gameObject);
            }
        }
    }
}
