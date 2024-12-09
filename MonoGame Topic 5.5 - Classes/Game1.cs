﻿using Microsoft.Xna.Framework;
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



        Texture2D tribbleBrownTexture;

        Texture2D tribbleCreamTexture;

        Texture2D tribbleGreyTexture;

        Random generator;
        Texture2D tribbleOrangeTexture;
        List<Tribble> tribbles;
        List<Texture2D> texture;
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
            tribbles = new List<Tribble>();
            texture = new List<Texture2D>();
            generator = new Random();
            base.Initialize();
            texture.Add(tribbleGreyTexture);
            texture.Add(tribbleOrangeTexture);
            texture.Add(tribbleBrownTexture);
            texture.Add(tribbleCreamTexture);
            tribbles.Add(new Tribble(tribbleGreyTexture, new Rectangle(300, 0, 100, 100), new Vector2(10, 0)));
            tribbles.Add(new Tribble(tribbleCreamTexture, new Rectangle(0, 300, 100, 100), new Vector2(10, 10)));
            tribbles.Add(new Tribble(tribbleBrownTexture, new Rectangle(600, 200, 100, 100), new Vector2(0, 10)));

            for (int i = 0; i < 1000; i++)
                tribbles.Add(new Tribble(tribbleOrangeTexture, new Rectangle(generator.Next(700), generator.Next(400), generator.Next(10, 100), generator.Next(10, 100)), new Vector2(generator.Next(-20, 20), generator.Next(-20, 20))));
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
            for (int i = 0 ; i < tribbles.Count; i++)
            {
                tribbles[i].Move(window);
            }




            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SeaGreen);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            for (int i = 0;  i < tribbles.Count; i++)
                tribbles[i].Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
