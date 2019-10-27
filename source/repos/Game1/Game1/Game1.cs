using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D bild;
        Texture2D logo;
        double posx;
        double posy;
        double frame;
        SoundEffect sound1;
        SoundEffect sound2;
        bool sound;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            bild = this.Content.Load<Texture2D>("Background");
            logo = this.Content.Load<Texture2D>("Unilogo");
            sound1 = Content.Load<SoundEffect>("Logo_hit");
            sound2 = Content.Load<SoundEffect>("Logo_miss");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MouseState mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                if (mouseState.X > this.Window.ClientBounds.Width / 2 - this.Window.ClientBounds.Width / 8 + (int)posx &&
                    mouseState.Y > this.Window.ClientBounds.Height / 2 - this.Window.ClientBounds.Width / 8 + (int)posy &&
                    mouseState.X < this.Window.ClientBounds.Width / 2 + this.Window.ClientBounds.Width / 8 + (int)posx &&
                    mouseState.Y < this.Window.ClientBounds.Height / 2 + this.Window.ClientBounds.Width / 8 + (int)posy)
                    sound = true;
                else
                    sound = false;
                if (sound)
                    sound1.Play();
                else
                    sound2.Play();
            }

            IsMouseVisible = true;
            frame+=0.03;
            posx= 100*System.Math.Cos(frame);
            posy= 100*System.Math.Sin(frame);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(bild, destinationRectangle: new Rectangle(0, 0, this.Window.ClientBounds.Width, this.Window.ClientBounds.Height));
            spriteBatch.Draw(logo, destinationRectangle: new Rectangle(this.Window.ClientBounds.Width/2- this.Window.ClientBounds.Width/8 + (int)posx,
                this.Window.ClientBounds.Height/2- this.Window.ClientBounds.Width /8+ (int)posy,
                this.Window.ClientBounds.Width/4,
                this.Window.ClientBounds.Width/4));
            //spriteBatch.Draw(bild, Vector2.Zero);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
