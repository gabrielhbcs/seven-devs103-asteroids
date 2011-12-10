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

namespace Asteroid
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        KeyboardState teclado;
        KeyboardState tecladoanterior;
        
        Fase1 fase1;
        Fase2 fase2;
        Fase3 fase3;
        Fase4 fase4;
        Fase5 fase5;
        Fase6 fase6;
        Fase7 fase7;
        Fase8 fase8;
        Fase9 fase9;
        Fase10 fase10;
        Fase11 fase11;
        Fase12 fase12;
        Fase13 fase13;
        Fase14 fase14;
        Fase15 fase15;
        Creditos creditos;

        public enum estados { CREDITOS, FASE1, FASE2, FASE3, FASE4, FASE5, FASE6, FASE7, FASE8, FASE9, FASE10, FASE11, FASE12, FASE13, FASE14, FASE15 };
        
        public static estados estadoAtual = estados.FASE1;
        
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
            spriteBatch = new SpriteBatch(GraphicsDevice);

            fase1 = new Fase1(Content);
            fase2 = new Fase2(Content);
            fase3 = new Fase3(Content, Window);
            //fase4 = new Fase4(Content);
            //fase5 = new Fase5(Content);
            //fase6 = new Fase6(Content);
            fase7 = new Fase7(Content);
            //fase8 = new Fase8(Content);
            // fase9 = new Fase9(Content);
            //fase10 = new Fase10(Content);
            //  fase11 = new Fase11(Content);
            // fase12 = new Fase12(Content);
            // fase13 = new Fase13(Content);
            //fase14 = new Fase14(Content);
            //fase15 = new Fase15(Content);

            creditos = new Creditos(Content);
            
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
            teclado = Keyboard.GetState();
            switch (estadoAtual)
            {
                case estados.CREDITOS:
                    creditos.Update(gameTime, teclado, tecladoanterior);
                    break;
                case estados.FASE1:
                    fase1.Update(gameTime, teclado, tecladoanterior);
                    break;
                case estados.FASE2:
                    fase2.Update(gameTime, teclado, tecladoanterior);
                    break;

                case estados.FASE3:
                    fase3.Update(gameTime, teclado, tecladoanterior);
                    break;

                case estados.FASE4:
                    //fase4.Update(gameTime, teclado, tecladoanterior);
                    break;

                case estados.FASE5:
                    //fase5.Update(gameTime, teclado, tecladoanterior);
                    break;

                case estados.FASE6:
                    //fase6.Update(gameTime, teclado, tecladoanterior);
                    break;

                case estados.FASE7:
                    fase7.Update(gameTime, teclado, tecladoanterior);
                    break;

                case estados.FASE8:
                    //fase8.Update(gameTime, teclado, tecladoanterior);
                    break;

                case estados.FASE9:
                    //fase9.Update(gameTime, teclado, tecladoanterior);
                    break;

                case estados.FASE10:
                    //fase10.Update(gameTime, teclado, tecladoanterior);
                    break;

                case estados.FASE11:
                    //fase11.Update(gameTime, teclado, tecladoanterior);
                    break;

                case estados.FASE12:
                    //fase12.Update(gameTime, teclado, tecladoanterior);
                    break;

                case estados.FASE13:
                    //fase13.Update(gameTime, teclado, tecladoanterior);
                    break;

                case estados.FASE14:
                    //fase14.Update(gameTime, teclado, tecladoanterior);
                    break;

                case estados.FASE15:
                    //fase15.Update(gameTime, teclado, tecladoanterior);
                    break;   
            }
            tecladoanterior = teclado;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
                switch (estadoAtual)
                {
                    case estados.CREDITOS:
                        creditos.Draw(gameTime, spriteBatch);
                        break;
                    case estados.FASE1:
                        fase1.Draw(gameTime, spriteBatch);
                       break;
                    case estados.FASE2:
                        fase2.Draw(gameTime, spriteBatch);
                        break;

                    case estados.FASE3:
                        fase3.Draw(gameTime, spriteBatch);
                        break;
                    case estados.FASE4:
                        //fase4.Draw(gameTime, spriteBatch);
                        break;
                    case estados.FASE5:
                        //fase5.Draw(gameTime, spriteBatch);
                        break;
                    case estados.FASE6:
                        //fase6.Draw(gameTime, spriteBatch);
                        break;
                    case estados.FASE7:
                        fase7.Draw(gameTime, spriteBatch);
                        break;
                    case estados.FASE8:
                        // fase8.Draw(gameTime, spriteBatch);
                        break;
                    case estados.FASE9:
                        // fase9.Draw(gameTime, spriteBatch);
                        break;
                    case estados.FASE10:
                        //fase10.Draw(gameTime, spriteBatch);
                        break;
                    case estados.FASE11:
                        // fase11.Draw(gameTime, spriteBatch);
                        break;
                    case estados.FASE12:
                        // fase12.Draw(gameTime, spriteBatch);
                        break;
                    case estados.FASE13:
                        //fase13.Draw(gameTime, spriteBatch);
                        break;
                    case estados.FASE14:
                        // fase14.Draw(gameTime, spriteBatch);
                        break;
                    case estados.FASE15:
                        //fase15.Draw(gameTime, spriteBatch);
                        break;

                }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
