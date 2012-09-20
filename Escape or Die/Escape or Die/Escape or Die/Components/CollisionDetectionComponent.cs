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

namespace Escape_or_Die.Components
{
    public class CollisionDetectionComponent : GameComponent, ICollisionDetectionService
    {
        List<IStaticCollideable> _staticCollideables;
        List<IDynamicCollideable> _dynamicCollideables;

        public CollisionDetectionComponent(Game game)
            : base(game)
        {
            _staticCollideables = new List<IStaticCollideable>();
            _dynamicCollideables = new List<IDynamicCollideable>();
        }

        public override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            IEnumerator<IStaticCollideable> static_1 = _staticCollideables.GetEnumerator();
            IEnumerator<IDynamicCollideable> dynamic_1 = _dynamicCollideables.GetEnumerator();
            IEnumerator<IDynamicCollideable> dynamic_2 = _dynamicCollideables.GetEnumerator();
            
            while (dynamic_1.MoveNext())
            {
                while (static_1.MoveNext())
                {
                    if (dynamic_1.Current.CollisionRectangle.Intersects(static_1.Current.CollisionRectangle))
                    {
                        dynamic_1.Current.OnCollisionWithStaticCollideable(static_1.Current);
                        static_1.Current.OnCollisionWithDynamicCollideable(dynamic_1.Current);
                    }
                }

                static_1.Reset();
            }

            dynamic_1.Reset();

            while (dynamic_1.MoveNext())
            {
                while (dynamic_2.MoveNext())
                {
                    if (dynamic_1.Current != dynamic_2.Current)
                    {
                        if (dynamic_1.Current.CollisionRectangle.Intersects(dynamic_2.Current.CollisionRectangle))
                        {
                            dynamic_1.Current.OnCollisionWithDynamicCollideable(dynamic_2.Current);
                            dynamic_2.Current.OnCollisionWithDynamicCollideable(dynamic_1.Current);
                        }
                    }
                }

                dynamic_2.Reset();
            }

            base.Update(gameTime);
        }

        public void AddStaticCollideable(IStaticCollideable staticCollideable)
        {
            IEnumerator<IStaticCollideable> static_1 = _staticCollideables.GetEnumerator();
            bool exists = false;

            while (static_1.MoveNext())
            {
                if (static_1.Current == staticCollideable)
                {
                    exists = true;
                }
            }

            if (!exists)
            {
                _staticCollideables.Add(staticCollideable);
            }
        }

        public void RemoveStaticCollideable(IStaticCollideable staticCollideable)
        {
            IEnumerator<IStaticCollideable> static_1 = _staticCollideables.GetEnumerator();
            bool exists = false;

            while (static_1.MoveNext())
            {
                if (static_1.Current == staticCollideable)
                {
                    exists = true;
                }
            }

            if (exists)
            {
                _staticCollideables.Remove(staticCollideable);
            }
        }

        public void AddDynamicCollideable(IDynamicCollideable dynamicCollideable)
        {
            IEnumerator<IDynamicCollideable> dynamic_1 = _dynamicCollideables.GetEnumerator();
            bool exists = false;

            while (dynamic_1.MoveNext())
            {
                if (dynamic_1.Current == dynamicCollideable)
                {
                    exists = true;
                }
            }

            if (!exists)
            {
                _dynamicCollideables.Add(dynamicCollideable);
            }
        }

        public void RemoveDynamicCollideable(IDynamicCollideable dynamicCollideable)
        {
            IEnumerator<IDynamicCollideable> dynamic_1 = _dynamicCollideables.GetEnumerator();
            bool exists = false;

            while (dynamic_1.MoveNext())
            {
                if (dynamic_1.Current == dynamicCollideable)
                {
                    exists = true;
                }
            }

            if (exists)
            {
                _dynamicCollideables.Remove(dynamicCollideable);
            }
        }
    }
}