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
using Escape_or_Die.Objects;

namespace Escape_or_Die.Components
{
    public class CollisionManagerComponent : GameComponent, ICollisionManagerService
    {
        List<StaticGameObject> _staticGameObjects;
        List<DynamicGameObject> _dynamicGameObjects;

        public CollisionManagerComponent(Game game)
            : base(game)
        {
            _staticGameObjects = new List<StaticGameObject>();
            _dynamicGameObjects = new List<DynamicGameObject>();
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            IEnumerator<StaticGameObject> staticEnumerator = _staticGameObjects.GetEnumerator();
            IEnumerator<DynamicGameObject> dynamicEnumerator1 = _dynamicGameObjects.GetEnumerator();
            IEnumerator<DynamicGameObject> dynamicEnumerator2 = _dynamicGameObjects.GetEnumerator();

            while (dynamicEnumerator1.MoveNext())
            {
                while (staticEnumerator.MoveNext())
                {
                    if (dynamicEnumerator1.Current.GetCollisionRectangle().Intersects(staticEnumerator.Current.GetCollisionRectangle()))
                    {
                        dynamicEnumerator1.Current.OnCollisionWithStaticGameObject(staticEnumerator.Current);
                        staticEnumerator.Current.OnCollisionWithDynamicGameObject(dynamicEnumerator1.Current);
                    }
                }

                staticEnumerator.Reset();
            }

            dynamicEnumerator1.Reset();

            while (dynamicEnumerator1.MoveNext())
            {
                while (dynamicEnumerator2.MoveNext())
                {
                    if (dynamicEnumerator1.Current.GetCollisionRectangle().Intersects(dynamicEnumerator2.Current.GetCollisionRectangle()))
                    {
                        dynamicEnumerator1.Current.OnCollisionWithDynamicGameObject(dynamicEnumerator2.Current);
                    }
                }

                dynamicEnumerator2.Reset();
            }

            base.Update(gameTime);
        }

        public void AddStaticGameObject(StaticGameObject staticGameObject)
        {
            IEnumerator<StaticGameObject> staticEnumerator = _staticGameObjects.GetEnumerator();

            bool exists = false;

            while (staticEnumerator.MoveNext())
            {
                if (staticEnumerator.Current == staticGameObject)
                {
                    exists = true;
                }
            }

            if (!exists)
            {
                _staticGameObjects.Add(staticGameObject);
            }
        }

        public void RemoveStaticGameObject(StaticGameObject staticGameObject)
        {
            IEnumerator<StaticGameObject> staticEnumerator = _staticGameObjects.GetEnumerator();
            bool exists = false;

            while (staticEnumerator.MoveNext())
            {
                if (staticEnumerator.Current == staticGameObject)
                {
                    exists = true;
                }
            }

            if (exists)
            {
                _staticGameObjects.Remove(staticGameObject);
            }
        }

        public void AddDynamicGameObject(DynamicGameObject dynamicGameObject)
        {
            IEnumerator<DynamicGameObject> dynamicEnumerator = _dynamicGameObjects.GetEnumerator();
            bool exists = false;

            while (dynamicEnumerator.MoveNext())
            {
                if (dynamicEnumerator.Current == dynamicGameObject)
                {
                    exists = true;
                }
            }

            if (!exists)
            {
                _dynamicGameObjects.Add(dynamicGameObject);
            }
        }

        public void RemoveDynamicGameObject(DynamicGameObject dynamicGameObject)
        {
            IEnumerator<DynamicGameObject> dynamicEnumerator = _dynamicGameObjects.GetEnumerator();
            bool exists = false;

            while (dynamicEnumerator.MoveNext())
            {
                if (dynamicEnumerator.Current == dynamicGameObject)
                {
                    exists = true;
                }
            }

            if (exists)
            {
                _dynamicGameObjects.Remove(dynamicGameObject);
            }
        }
    }
}