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

namespace Escape_or_Die.Services
{
    public interface ICollisionDetectionService
    {
        void AddStaticCollideable(IStaticCollideable staticCollideable);
        void RemoveStaticCollideable(IStaticCollideable staticCollideable);

        void AddDynamicCollideable(IDynamicCollideable dynamicCollideable);
        void RemoveDynamicCollideable(IDynamicCollideable dynamicCollideable);
    }
}