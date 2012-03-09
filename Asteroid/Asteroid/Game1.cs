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
using Asteroid.Estados.Fase01;

namespace Asteroid
{
    /// <summary>
    /// Jogo da turma DEVS103b
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        KeyboardState teclado;
        KeyboardState tecladoanterior;

        bool troca = false;

        GamePadState controle;
        GamePadState controleanterior;

        public static SpriteFont fonte;

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
        Fase16 fase16;

        Intro intro;

        MenuInicial menu;
        
        Creditos creditos;

        Controles controles;

        Status status;

        GameOver gameOver;

        TheEnd theEnd;

        public enum dispositivos_controle { TECLADO, JOYSTICK };

        public static dispositivos_controle controleAtual = dispositivos_controle.TECLADO;

        public enum estados { INTRO, MENU, CREDITOS, CONTROLES, GAME_OVER, THE_END, PAUSE, STATUS, FASE1, FASE2, FASE3, FASE4, FASE5, FASE6, FASE7, FASE8, FASE9, FASE10, FASE11, FASE12, FASE13, FASE14, FASE15, FASE16 };

        public static estados estadoAtual = estados.MENU;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 480;
            graphics.ApplyChanges();

            Window.Title = "Jogo da turma DEVS103b";

            IsMouseVisible = false;

            Content.RootDirectory = "Content";
           
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        // MUDAR A FUNÇÃO RESETAR() QUANDO TROCAR A FUNÇÃO LOADCONTENT!

        protected override void LoadContent()
        {
            #region Loads

            spriteBatch = new SpriteBatch(GraphicsDevice);

            Iniciar();
         
            fonte = Content.Load<SpriteFont>("Arial");

            #endregion

        }

        // MUDAR A FUNÇÃO RESETAR() QUANDO TROCAR A FUNÇÃO LOADCONTENT!
        //não seria mais fácil simplesmente ao resetar chamar o load de novo?

        public void Iniciar()
        {
            #region Resetar loads

            Asteroide.lista.Clear();

            fase1 = new Fase1(Content, Window);
            fase2 = new Fase2(Content, Window);
            fase3 = new Fase3(Content, Window);
            fase4 = new Fase4(Content, Window);
            fase5 = new Fase5(Content, Window);
            fase6 = new Fase6(Content, Window);
            fase7 = new Fase7(Content, Window);
            fase8 = new Fase8(Content, Window);
            fase9 = new Fase9(Content, Window);
            fase10 = new Fase10(Content, Window);
            fase11 = new Fase11(Content, Window);
            fase12 = new Fase12(Content, Window);
            fase13 = new Fase13(Content, Window);
            fase14 = new Fase14(Content, Window);
            fase15 = new Fase15(Content, Window);
            fase16 = new Fase16(Content, Window);

            intro = new Intro(Content, Window);

            menu = new MenuInicial(Content, Window);

            controles = new Controles(Content, Window);

            creditos = new Creditos(Content, Window);

            status = new Status(Content, Window);

            gameOver = new GameOver(Content, Window);

            theEnd = new TheEnd(Content, Window);

            #endregion
        }   

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            teclado = Keyboard.GetState();
            controle = GamePad.GetState(PlayerIndex.One);

            //F2 vai de janela para tela cheia e vice-versa
             if ((teclado.IsKeyDown(Keys.F2) && !(tecladoanterior.IsKeyDown(Keys.F2))))
             {
                 graphics.ToggleFullScreen();
             }


            switch (estadoAtual)
            {
                case estados.INTRO:
                    if ((teclado.IsKeyDown(Keys.Enter)) && !(tecladoanterior.IsKeyDown(Keys.Enter))) 
                        estadoAtual = estados.MENU;
                    break;

                case estados.MENU:
                    if (((teclado.IsKeyDown(Keys.Enter) && !(tecladoanterior.IsKeyDown(Keys.Enter))) || (controle.IsButtonDown(Buttons.A) && !(controleanterior.IsButtonDown(Buttons.A)))) && menu.cont == 1) estadoAtual = estados.FASE1;
                    if (((teclado.IsKeyDown(Keys.Enter) && !(tecladoanterior.IsKeyDown(Keys.Enter))) || (controle.IsButtonDown(Buttons.A) && !(controleanterior.IsButtonDown(Buttons.A)))) && menu.cont == 2) estadoAtual = estados.CONTROLES;
                    if (((teclado.IsKeyDown(Keys.Enter) && !(tecladoanterior.IsKeyDown(Keys.Enter))) || (controle.IsButtonDown(Buttons.A) && !(controleanterior.IsButtonDown(Buttons.A)))) && menu.cont == 3) estadoAtual = estados.CREDITOS;
                    if (((teclado.IsKeyDown(Keys.Enter) && !(tecladoanterior.IsKeyDown(Keys.Enter))) || (controle.IsButtonDown(Buttons.A) && !(controleanterior.IsButtonDown(Buttons.A)))) && menu.cont == 4) estadoAtual = estados.STATUS;
                    if (((teclado.IsKeyDown(Keys.Enter) && !(tecladoanterior.IsKeyDown(Keys.Enter))) || (controle.IsButtonDown(Buttons.A) && !(controleanterior.IsButtonDown(Buttons.A)))) && menu.cont == 5) this.Exit();
                    menu.Update(gameTime, teclado, controle, Content);
                    break;

                case estados.CREDITOS:
                    if ((teclado.IsKeyDown(Keys.Escape) && !(tecladoanterior.IsKeyDown(Keys.Escape))) || (controle.IsButtonDown(Buttons.Back) && !(controleanterior.IsButtonDown(Buttons.Back))))
                    {
                        estadoAtual = estados.MENU;
                    }
               
                    break;

                case estados.CONTROLES:
                    controles.Update(gameTime, teclado, tecladoanterior, controle);
                    if ((teclado.IsKeyDown(Keys.Escape) && !(tecladoanterior.IsKeyDown(Keys.Escape))) || (controle.IsButtonDown(Buttons.Back) && !(controleanterior.IsButtonDown(Buttons.Back))))
                    {
                        estadoAtual = estados.MENU;
                    }
                    break;

                case estados.STATUS:
                    {
                        status.Update(gameTime, teclado, tecladoanterior, controle, controleanterior);
                        if ((teclado.IsKeyDown(Keys.Escape) && !(tecladoanterior.IsKeyDown(Keys.Escape))) || (controle.IsButtonDown(Buttons.Back) && !(controleanterior.IsButtonDown(Buttons.Back))))
                        {
                            estadoAtual = estados.MENU;
                        }
                    }

                    break;

                case estados.FASE1:
                    fase1.Update(gameTime, teclado, tecladoanterior, controle, controleanterior);
                    if ((teclado.IsKeyDown(Keys.F) && !(tecladoanterior.IsKeyDown(Keys.F))) || (controle.IsButtonDown(Buttons.RightShoulder) && !(controleanterior.IsButtonDown(Buttons.RightShoulder))))
                    {
                        Shot.removeAllShots();
                        MediaPlayer.Stop();
                        estadoAtual = estados.FASE2;
                    }
                   
                    if ((teclado.IsKeyDown(Keys.Escape) && !(tecladoanterior.IsKeyDown(Keys.Escape))) || (controle.IsButtonDown(Buttons.Back) && !(controleanterior.IsButtonDown(Buttons.Back))))
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.MENU;
                    }
                    break;

                case estados.FASE2:
                    fase2.Update(gameTime, teclado, tecladoanterior, controle, controleanterior);
                    troca = true;
                    if ((teclado.IsKeyDown(Keys.F) && !(tecladoanterior.IsKeyDown(Keys.F))) || (controle.IsButtonDown(Buttons.RightShoulder) && !(controleanterior.IsButtonDown(Buttons.RightShoulder))))
                    {
                        Shot.removeAllShots();
                        MediaPlayer.Stop();
                        estadoAtual = estados.FASE3;
                    }
                    if ((teclado.IsKeyDown(Keys.B) && !(tecladoanterior.IsKeyDown(Keys.B))) || (controle.IsButtonDown(Buttons.RightShoulder) && !(controleanterior.IsButtonDown(Buttons.RightShoulder))))
                    {
                        Shot.removeAllShots();
                        MediaPlayer.Stop();
                        estadoAtual = estados.FASE1;
                    }
                    if ((teclado.IsKeyDown(Keys.Escape) && !(tecladoanterior.IsKeyDown(Keys.Escape))) || (controle.IsButtonDown(Buttons.Back) && !(controleanterior.IsButtonDown(Buttons.Back))))
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.MENU;
                    }
                    break;

                case estados.FASE3:
                    fase3.Update(gameTime, teclado, tecladoanterior, controle, controleanterior);
                    if ((teclado.IsKeyDown(Keys.F) && !(tecladoanterior.IsKeyDown(Keys.F))) || (controle.IsButtonDown(Buttons.RightShoulder) && !(controleanterior.IsButtonDown(Buttons.RightShoulder))))
                    {
                        Shot.removeAllShots();
                        MediaPlayer.Stop();
                        estadoAtual = estados.FASE4;
                    }
                    if ((teclado.IsKeyDown(Keys.B) && !(tecladoanterior.IsKeyDown(Keys.B))) || (controle.IsButtonDown(Buttons.RightShoulder) && !(controleanterior.IsButtonDown(Buttons.RightShoulder))))
                    {
                        Shot.removeAllShots();
                        MediaPlayer.Stop();
                        estadoAtual = estados.FASE2;
                    }
                    if ((teclado.IsKeyDown(Keys.Escape) && !(tecladoanterior.IsKeyDown(Keys.Escape))) || (controle.IsButtonDown(Buttons.Back) && !(controleanterior.IsButtonDown(Buttons.Back))))
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.MENU;
                    }
                    break;

                case estados.FASE4:
                    fase4.Update(gameTime, teclado, tecladoanterior, controle, controleanterior);
                    if ((teclado.IsKeyDown(Keys.F) && !(tecladoanterior.IsKeyDown(Keys.F))) || (controle.IsButtonDown(Buttons.RightShoulder) && !(controleanterior.IsButtonDown(Buttons.RightShoulder))))
                    {
                        Shot.removeAllShots();
                        MediaPlayer.Stop();
                        estadoAtual = estados.FASE5;
                    }
                    if ((teclado.IsKeyDown(Keys.B) && !(tecladoanterior.IsKeyDown(Keys.B))) || (controle.IsButtonDown(Buttons.RightShoulder) && !(controleanterior.IsButtonDown(Buttons.RightShoulder))))
                    {
                        Shot.removeAllShots();
                        MediaPlayer.Stop();
                        estadoAtual = estados.FASE3;
                    }
                    if ((teclado.IsKeyDown(Keys.Escape) && !(tecladoanterior.IsKeyDown(Keys.Escape))) || (controle.IsButtonDown(Buttons.Back) && !(controleanterior.IsButtonDown(Buttons.Back))))
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.MENU;
                    }
                    break;

                case estados.FASE5:
                    fase5.Update(gameTime, teclado, tecladoanterior, controle, controleanterior);
                    if ((teclado.IsKeyDown(Keys.F) && !(tecladoanterior.IsKeyDown(Keys.F))) || (controle.IsButtonDown(Buttons.RightShoulder) && !(controleanterior.IsButtonDown(Buttons.RightShoulder))))
                    {
                        Shot.removeAllShots();
                        MediaPlayer.Stop();
                        estadoAtual = estados.FASE6;
                    }
                    if ((teclado.IsKeyDown(Keys.B) && !(tecladoanterior.IsKeyDown(Keys.B))) || (controle.IsButtonDown(Buttons.RightShoulder) && !(controleanterior.IsButtonDown(Buttons.RightShoulder))))
                    {
                        Shot.removeAllShots();
                        MediaPlayer.Stop();
                        estadoAtual = estados.FASE4;
                    }
                    if ((teclado.IsKeyDown(Keys.Escape) && !(tecladoanterior.IsKeyDown(Keys.Escape))) || (controle.IsButtonDown(Buttons.Back) && !(controleanterior.IsButtonDown(Buttons.Back))))
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.MENU;
                    }
                    break;

                case estados.FASE6:
                    fase6.Update(gameTime, teclado, tecladoanterior, controle, controleanterior);
                    if ((teclado.IsKeyDown(Keys.F) && !(tecladoanterior.IsKeyDown(Keys.F))) || (controle.IsButtonDown(Buttons.RightShoulder) && !(controleanterior.IsButtonDown(Buttons.RightShoulder))))
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.FASE7;
                    }
                    if ((teclado.IsKeyDown(Keys.B) && !(tecladoanterior.IsKeyDown(Keys.B))) || (controle.IsButtonDown(Buttons.RightShoulder) && !(controleanterior.IsButtonDown(Buttons.RightShoulder))))
                    {
                        Shot.removeAllShots();
                        MediaPlayer.Stop();
                        estadoAtual = estados.FASE5;
                    }
                    if ((teclado.IsKeyDown(Keys.Escape) && !(tecladoanterior.IsKeyDown(Keys.Escape))) || (controle.IsButtonDown(Buttons.Back) && !(controleanterior.IsButtonDown(Buttons.Back))))
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.MENU;
                    }
                    break;

                case estados.FASE7:
                    fase7.Update(gameTime, teclado, tecladoanterior, controle, controleanterior);
                    if (Fase7.Objetivo >= 7)
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.FASE8;
                    }
                    if ((teclado.IsKeyDown(Keys.F) && !(tecladoanterior.IsKeyDown(Keys.F))) || (controle.IsButtonDown(Buttons.RightShoulder) && !(controleanterior.IsButtonDown(Buttons.RightShoulder))))
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.FASE8;
                    }
                    if ((teclado.IsKeyDown(Keys.B) && !(tecladoanterior.IsKeyDown(Keys.B))) || (controle.IsButtonDown(Buttons.RightShoulder) && !(controleanterior.IsButtonDown(Buttons.RightShoulder))))
                    {

                        Shot.removeAllShots(); 
                       MediaPlayer.Stop();
                        estadoAtual = estados.FASE6;
                    }
                    if ((teclado.IsKeyDown(Keys.Escape) && !(tecladoanterior.IsKeyDown(Keys.Escape))) || (controle.IsButtonDown(Buttons.Back) && !(controleanterior.IsButtonDown(Buttons.Back))))
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.MENU;
                    }
                    break;

                case estados.FASE8:
                    fase8.Update(gameTime, teclado, tecladoanterior, controle, controleanterior);
                    if ((teclado.IsKeyDown(Keys.F) && !(tecladoanterior.IsKeyDown(Keys.F))) || (controle.IsButtonDown(Buttons.RightShoulder) && !(controleanterior.IsButtonDown(Buttons.RightShoulder))))
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.FASE9;
                    }
                    if ((teclado.IsKeyDown(Keys.B) && !(tecladoanterior.IsKeyDown(Keys.B))) || (controle.IsButtonDown(Buttons.RightShoulder) && !(controleanterior.IsButtonDown(Buttons.RightShoulder))))
                    {
                        Shot.removeAllShots();
                        MediaPlayer.Stop();
                        estadoAtual = estados.FASE7;
                    }
                    if ((teclado.IsKeyDown(Keys.Escape) && !(tecladoanterior.IsKeyDown(Keys.Escape))) || (controle.IsButtonDown(Buttons.Back) && !(controleanterior.IsButtonDown(Buttons.Back))))
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.MENU;
                    }
                    break;

                case estados.FASE9:
                    fase9.Update(gameTime, teclado, tecladoanterior, controle, controleanterior);
                    if ((teclado.IsKeyDown(Keys.F) && !(tecladoanterior.IsKeyDown(Keys.F))) || (controle.IsButtonDown(Buttons.RightShoulder) && !(controleanterior.IsButtonDown(Buttons.RightShoulder))))
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.FASE10;
                    }
                    if ((teclado.IsKeyDown(Keys.B) && !(tecladoanterior.IsKeyDown(Keys.B))) || (controle.IsButtonDown(Buttons.RightShoulder) && !(controleanterior.IsButtonDown(Buttons.RightShoulder))))
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.FASE8;
                    }
                    if ((teclado.IsKeyDown(Keys.Escape) && !(tecladoanterior.IsKeyDown(Keys.Escape))) || (controle.IsButtonDown(Buttons.Back) && !(controleanterior.IsButtonDown(Buttons.Back))))
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.MENU;
                    }
                    break;

                case estados.FASE10:
                    fase10.Update(gameTime, teclado, tecladoanterior, controle, controleanterior);
                    if ((teclado.IsKeyDown(Keys.F) && !(tecladoanterior.IsKeyDown(Keys.F))) || (controle.IsButtonDown(Buttons.RightShoulder) && !(controleanterior.IsButtonDown(Buttons.RightShoulder))))
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.FASE11;
                    }
                    if ((teclado.IsKeyDown(Keys.B) && !(tecladoanterior.IsKeyDown(Keys.B))) || (controle.IsButtonDown(Buttons.RightShoulder) && !(controleanterior.IsButtonDown(Buttons.RightShoulder))))
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.FASE9;
                    }
                    if ((teclado.IsKeyDown(Keys.Escape) && !(tecladoanterior.IsKeyDown(Keys.Escape))) || (controle.IsButtonDown(Buttons.Back) && !(controleanterior.IsButtonDown(Buttons.Back))))
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.MENU;
                    }
                    break;

                case estados.FASE11:
                    fase11.Update(gameTime, teclado, tecladoanterior, controle, controleanterior);
                    if ((teclado.IsKeyDown(Keys.F) && !(tecladoanterior.IsKeyDown(Keys.F))) || (controle.IsButtonDown(Buttons.RightShoulder) && !(controleanterior.IsButtonDown(Buttons.RightShoulder))))
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.FASE12;
                    }
                    if ((teclado.IsKeyDown(Keys.B) && !(tecladoanterior.IsKeyDown(Keys.B))) || (controle.IsButtonDown(Buttons.RightShoulder) && !(controleanterior.IsButtonDown(Buttons.RightShoulder))))
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.FASE10;
                    }
                    if ((teclado.IsKeyDown(Keys.Escape) && !(tecladoanterior.IsKeyDown(Keys.Escape))) || (controle.IsButtonDown(Buttons.Back) && !(controleanterior.IsButtonDown(Buttons.Back))))
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.MENU;
                    }
                    break;

                case estados.FASE12:
                    fase12.Update(gameTime, teclado, tecladoanterior, controle, controleanterior);
                    if ((teclado.IsKeyDown(Keys.F) && !(tecladoanterior.IsKeyDown(Keys.F))) || (controle.IsButtonDown(Buttons.RightShoulder) && !(controleanterior.IsButtonDown(Buttons.RightShoulder))))
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.FASE13;
                    }
                    if ((teclado.IsKeyDown(Keys.B) && !(tecladoanterior.IsKeyDown(Keys.B))) || (controle.IsButtonDown(Buttons.RightShoulder) && !(controleanterior.IsButtonDown(Buttons.RightShoulder))))
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.FASE11;
                    }
                    if ((teclado.IsKeyDown(Keys.Escape) && !(tecladoanterior.IsKeyDown(Keys.Escape))) || (controle.IsButtonDown(Buttons.Back) && !(controleanterior.IsButtonDown(Buttons.Back))))
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.MENU;
                    }
                    break;

                case estados.FASE13:
                    fase13.Update(gameTime, teclado, tecladoanterior, controle, controleanterior);
                    if ((teclado.IsKeyDown(Keys.F) && !(tecladoanterior.IsKeyDown(Keys.F))) || (controle.IsButtonDown(Buttons.RightShoulder) && !(controleanterior.IsButtonDown(Buttons.RightShoulder))))
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.FASE14;
                    }
                    if ((teclado.IsKeyDown(Keys.B) && !(tecladoanterior.IsKeyDown(Keys.B))) || (controle.IsButtonDown(Buttons.RightShoulder) && !(controleanterior.IsButtonDown(Buttons.RightShoulder))))
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.FASE12;
                    }
                    if ((teclado.IsKeyDown(Keys.Escape) && !(tecladoanterior.IsKeyDown(Keys.Escape))) || (controle.IsButtonDown(Buttons.Back) && !(controleanterior.IsButtonDown(Buttons.Back))))
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.MENU;
                    }
                    break;

                case estados.FASE14:
                    fase14.Update(gameTime, teclado, tecladoanterior, controle, controleanterior);
                    if ((teclado.IsKeyDown(Keys.F) && !(tecladoanterior.IsKeyDown(Keys.F))) || (controle.IsButtonDown(Buttons.RightShoulder) && !(controleanterior.IsButtonDown(Buttons.RightShoulder))))
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.FASE15;
                    }
                    if ((teclado.IsKeyDown(Keys.B) && !(tecladoanterior.IsKeyDown(Keys.B))) || (controle.IsButtonDown(Buttons.RightShoulder) && !(controleanterior.IsButtonDown(Buttons.RightShoulder))))
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.FASE13;
                    }
                    if ((teclado.IsKeyDown(Keys.Escape) && !(tecladoanterior.IsKeyDown(Keys.Escape))) || (controle.IsButtonDown(Buttons.Back) && !(controleanterior.IsButtonDown(Buttons.Back))))
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.MENU;
                    }
                    break;

                case estados.FASE15:
                    fase15.Update(gameTime, teclado, tecladoanterior, controle, controleanterior);
                    if ((teclado.IsKeyDown(Keys.F) && !(tecladoanterior.IsKeyDown(Keys.F))) || (controle.IsButtonDown(Buttons.RightShoulder) && !(controleanterior.IsButtonDown(Buttons.RightShoulder))))
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.FASE16;
                    }
                    if ((teclado.IsKeyDown(Keys.B) && !(tecladoanterior.IsKeyDown(Keys.B))) || (controle.IsButtonDown(Buttons.RightShoulder) && !(controleanterior.IsButtonDown(Buttons.RightShoulder))))
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.FASE14;
                    }
                    if ((teclado.IsKeyDown(Keys.Escape) && !(tecladoanterior.IsKeyDown(Keys.Escape))) || (controle.IsButtonDown(Buttons.Back) && !(controleanterior.IsButtonDown(Buttons.Back))))
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.MENU;
                    }
                    break;

                case estados.FASE16:
                    fase16.Update(gameTime, teclado, tecladoanterior, controle, controleanterior);
                    if ((teclado.IsKeyDown(Keys.F) && !(tecladoanterior.IsKeyDown(Keys.F))) || (controle.IsButtonDown(Buttons.RightShoulder) && !(controleanterior.IsButtonDown(Buttons.RightShoulder))))
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.GAME_OVER;
                        Iniciar();
                    }
                    if ((teclado.IsKeyDown(Keys.B) && !(tecladoanterior.IsKeyDown(Keys.B))) || (controle.IsButtonDown(Buttons.RightShoulder) && !(controleanterior.IsButtonDown(Buttons.RightShoulder))))
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.FASE15;
                    }
                    if ((teclado.IsKeyDown(Keys.Escape) && !(tecladoanterior.IsKeyDown(Keys.Escape))) || (controle.IsButtonDown(Buttons.Back) && !(controleanterior.IsButtonDown(Buttons.Back))))
                    {
                        MediaPlayer.Stop();
                        estadoAtual = estados.MENU;
                    }
                    break;

                case estados.GAME_OVER:
                    gameOver.Update(gameTime, teclado);
                    Iniciar();
                    break;

                case estados.THE_END:
                    theEnd.Update(gameTime, teclado);
                    Iniciar();
                    break;

            }

            tecladoanterior = teclado;
            controleanterior = controle;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

                switch (estadoAtual)
                {
                    case estados.INTRO:
                        intro.Draw(gameTime, spriteBatch);
                        break;
                    case estados.MENU:
                        menu.Draw(gameTime, spriteBatch);
                        break;
                    case estados.CREDITOS:
                        creditos.Draw(gameTime, spriteBatch);
                        break;
                    case estados.CONTROLES:
                        controles.Draw(gameTime, spriteBatch);
                        break;
                    case estados.STATUS:
                        status.Draw(gameTime, spriteBatch);
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
                        fase4.Draw(gameTime, spriteBatch);
                        break;
                    case estados.FASE5:
                        fase5.Draw(gameTime, spriteBatch);
                        break;
                    case estados.FASE6:
                        fase6.Draw(gameTime, spriteBatch);
                        break;
                    case estados.FASE7:
                        fase7.Draw(gameTime, spriteBatch);
                        break;
                    case estados.FASE8:
                         fase8.Draw(gameTime, spriteBatch);
                        break;
                    case estados.FASE9:
                        fase9.Draw(gameTime, spriteBatch);
                        break;
                    case estados.FASE10:
                        fase10.Draw(gameTime, spriteBatch);
                        break;
                    case estados.FASE11:
                        fase11.Draw(gameTime, spriteBatch);
                        break;
                    case estados.FASE12:
                        fase12.Draw(gameTime, spriteBatch);
                        break;
                    case estados.FASE13:
                        fase13.Draw(gameTime, spriteBatch);
                        break;
                    case estados.FASE14:
                        fase14.Draw(gameTime, spriteBatch);
                        break;
                    case estados.FASE15:
                        fase15.Draw(gameTime, spriteBatch);
                        break;
                    case estados.FASE16:
                        fase16.Draw(gameTime, spriteBatch);
                        break;
                    case estados.GAME_OVER:
                        gameOver.Draw(gameTime, spriteBatch);
                        break;
                    case estados.THE_END:
                        theEnd.Draw(gameTime, spriteBatch);
                        break;
                }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}