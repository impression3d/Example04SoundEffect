using Impression;
using Impression.Graphics;
using Impression.Input;
using Impression.Audio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Example04SoundEffect
{
    public class Example04SoundEffectGame : Impression.Game
    {
		GraphicsDeviceManager graphics;

		List<SoundEffect> soundEffects;
		Random random = new Random();

		MouseState currentMouseState;
		MouseState lastMouseState;

        public Example04SoundEffectGame()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);

			switch (FrameworkContext.Platform)
			{
				case PlatformType.Windows:
				case PlatformType.Mac:
				case PlatformType.Linux:
					{
						graphics.PreferredBackBufferWidth = 1280;
						graphics.PreferredBackBufferHeight = 720;

						this.IsMouseVisible = true;
					}
					break;
                case PlatformType.WindowsStore:
                case PlatformType.WindowsMobile:
					{
						graphics.PreferredBackBufferWidth = 1280;
						graphics.PreferredBackBufferHeight = 720;

						graphics.IsFullScreen = true;

						// Frame rate is 30 fps by default for mobile device
						TargetElapsedTime = TimeSpan.FromTicks(TimeSpan.TicksPerSecond / 30L);
					}
					break;
				case PlatformType.Android:
				case PlatformType.iOS:
					{
						graphics.PreferredBackBufferWidth = 1280;
						graphics.PreferredBackBufferHeight = 720;

						graphics.IsFullScreen = true;

						// Frame rate is 30 fps by default for mobile device
						TargetElapsedTime = TimeSpan.FromTicks(TimeSpan.TicksPerSecond / 30L);
					}
					break;
			}

            this.View.Title = "Example04SoundEffect";
        }

        protected override void Initialize()
        { 
            base.Initialize();

            // do something
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            soundEffects = new List<SoundEffect>();

			// Load all sound effects
			soundEffects.Add(this.Content.Load<SoundEffect>("Audio/Electrical-Tone"));
        }

        protected override void UnloadContent()
        {
            // do something

            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
			switch (FrameworkContext.Platform)
			{
				case PlatformType.Windows:
				case PlatformType.Mac:
				case PlatformType.Linux:
					{
						if (Keyboard.GetState().IsKeyDown(Keys.Escape))
							this.Exit();
					}
					break;
				default:
					{
						// do nothings
					}
					break;
			}

			lastMouseState = currentMouseState;
			currentMouseState = Mouse.GetState();

			// Allow random fire and forget sound effect
			if (lastMouseState.LeftButton == ButtonState.Released &&
				currentMouseState.LeftButton == ButtonState.Pressed)
			{
				int randomIndex = random.Next(0, soundEffects.Count - 1);
				soundEffects[randomIndex].Play();
			}
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
			graphics.GraphicsDevice.Clear(Color.BurlyWood);

			// do something
            
            base.Draw(gameTime);
        }
    }
}