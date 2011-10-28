using System;

namespace WumpusAgentGame
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Index game = new Index())
            {
                game.Run();
            }
        }
    }
#endif
}

