using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using Escape_or_Die.Components;
using Escape_or_Die.Services;

namespace Escape_or_Die
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class EscapeorDie : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        CollisionDetectionComponent _collisionDetectionComponent;
        KeyboardManagerComponent _keyboardManagerComponent;
        DrawManagerComponent _drawManagerComponent;
        Player _player;

        public EscapeorDie()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;

            Content.RootDirectory = "Content";

            _collisionDetectionComponent = new CollisionDetectionComponent(this);
            _keyboardManagerComponent = new KeyboardManagerComponent(this);
            _drawManagerComponent = new DrawManagerComponent(this);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            Components.Add(_collisionDetectionComponent);
            Components.Add(_keyboardManagerComponent);
            Components.Add(_drawManagerComponent);

            Services.AddService(typeof(ICollisionDetectionService), _collisionDetectionComponent);
            Services.AddService(typeof(IKeyboardManagerService), _keyboardManagerComponent);
            Services.AddService(typeof(IDrawManagerService), _drawManagerComponent);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            _player = new Player(this);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            _player.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}