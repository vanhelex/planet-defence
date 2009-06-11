using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using WindowsGame1.LOGICA;

namespace WindowsGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        protected KeyboardState oldKeyboardState;
        SpriteBatch spriteBatch;
        Planeta planeta;
        Torre torre;
        Heroe heroe;
        Heroe heroe2;
        Enemigo[] enemigos;
        Enemigo[] enemigos2;
        public static int cant_enemigos = 50;
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
            planeta = new Planeta(Content.Load<Model>("MODELOS/planeta"));
            torre = new Torre(Content.Load<Model>("MODELOS/torreta"));
            heroe = new Heroe(Content.Load<Model>("MODELOS/Cube"));
            heroe2 = new Heroe(Content.Load<Model>("MODELOS/Cube"));
            enemigos = new Enemigo[cant_enemigos];
            enemigos2 = new Enemigo[cant_enemigos];
            for(int i = 0; i<cant_enemigos; i++)
            {
                enemigos[i] = new Enemigo(Content.Load<Model>("MODELOS/spaceship"));
                enemigos[i].escala = 0.015f;
                enemigos[i].rotacion.X = i * (float)Math.PI*2/cant_enemigos;
                enemigos[i].rotacion.Y = (float)Math.PI/3;
                

                enemigos2[i] = new Enemigo(Content.Load<Model>("MODELOS/Cube"));
                enemigos2[i].rotacion.X = i * (float)Math.PI * 2 / cant_enemigos;
                enemigos2[i].rotacion.Y = (float)(Math.PI*-1) / 3;
            }

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            HandleActionInput();
            for (int i = 0; i < cant_enemigos;i++ )
            {
                enemigos[i].rotacion.X += enemigos[i].velocidad;
            }

            for (int i = 0; i < cant_enemigos; i++)
            {
                enemigos2[i].rotacion.X += enemigos2[i].velocidad;
            }
                //heroe.rotacion.Y += 0.01f;
                //heroe.escala += (float)Math.Sin(gameTime.TotalGameTime.TotalSeconds)/1000;
                base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //Update(gameTime);
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            planeta.paint(graphics);
            torre.paint(graphics);
            heroe.paint(graphics);
//            heroe2.paint(graphics);
            for (int i = 0; i < cant_enemigos; i++)
                enemigos[i].paint(graphics);
            for (int i = 0; i < cant_enemigos; i++)
                enemigos2[i].paint(graphics);
            base.Draw(gameTime);
        }
        private void HandleActionInput()
        {
            // Get the Keyboard and GamePad state
            KeyboardState keyboardState = Keyboard.GetState();

            oldKeyboardState = keyboardState;


            KeyboardState keyboard = Keyboard.GetState();

            #region Player1
            if (keyboard.IsKeyDown(Keys.Up))
            {
                heroe.rotacion.X -= heroe.velocidad;
            }
            if (keyboard.IsKeyDown(Keys.Down))
            {
                heroe.rotacion.X += heroe.velocidad;
            }
            if (keyboard.IsKeyDown(Keys.Left))
            {
                heroe.rotacion.Y -= heroe.velocidad;
            }
            if (keyboard.IsKeyDown(Keys.Right))
            {
                heroe.rotacion.Y += heroe.velocidad;
            }
            #endregion

            #region Player2
            if (keyboard.IsKeyDown(Keys.W))
            {
                torre.rotacion.X -= torre.velocidad;
            }
            if (keyboard.IsKeyDown(Keys.S))
            {
                torre.rotacion.X += torre.velocidad;
            }
            if (keyboard.IsKeyDown(Keys.A))
            {
                torre.rotacion.Y -= torre.velocidad;
            }
            if (keyboard.IsKeyDown(Keys.D))
            {
                torre.rotacion.Y += torre.velocidad;
            }
            #endregion


        }
    }
}
