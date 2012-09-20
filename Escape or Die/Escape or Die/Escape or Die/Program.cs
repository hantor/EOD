using System;

namespace Escape_or_Die
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (EscapeorDie game = new EscapeorDie())
            {
                game.Run();
            }
        }
    }
#endif
}

