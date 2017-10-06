using System;
using Impression;

namespace Example04SoundEffect
{
    class Program
    {
        static void Main(string[] args)
		{
			using(var game = new Example04SoundEffectGame())
            {
                game.Run();
            }
		}
    }
}