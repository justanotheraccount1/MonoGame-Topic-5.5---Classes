using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using System;

namespace MonoGame_Topic_5._5___Classes
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;

        Tribble tribble1, tribble2, tribble3, tribble4;

        Texture2D tribbleBrownTexture;

        Texture2D tribbleCreamTexture;

        Texture2D tribbleGreyTexture;
        Rectangle tribbleGreyRect;
        Vector2 tribbleGreySpeed;

        Texture2D tribbleOrangeTexture;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.Window.Title = "Lesson 3 - Animation Part 1";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            window = new Rectangle(0, 0, 800, 500);
            _graphics.PreferredBackBufferWidth = window.Width;  // set this value to the desired width of your window
            _graphics.PreferredBackBufferHeight = window.Height;   // set this value to the desired height of your window
            _graphics.ApplyChanges();


            base.Initialize();

            tribble1 = new Tribble(tribbleGreyTexture, new Rectangle(300, 0, 100, 100), new Vector2(10, 0));
            tribble2 = new Tribble(tribbleCreamTexture, new Rectangle(0, 300, 100, 100), new Vector2(10, 10));
            tribble3 = new Tribble(tribbleBrownTexture, new Rectangle(600, 200, 100, 100), new Vector2(0, 10));
            tribble4 = new Tribble(tribbleOrangeTexture, new Rectangle(400, 100, 100, 100), new Vector2(20, 20));
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");


        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            tribble1.Move(window);
            tribble2.Move(window);
            tribble3.Move(window);
            tribble4.Move(window);




            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SeaGreen);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(tribble1.Texture, tribble1.Rectangle, Color.White);
            _spriteBatch.Draw(tribble2.Texture, tribble2.Rectangle, Color.White);
            _spriteBatch.Draw(tribble3.Texture, tribble3.Rectangle, Color.White);
            _spriteBatch.Draw(tribble4.Texture, tribble4.Rectangle, Color.White);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
