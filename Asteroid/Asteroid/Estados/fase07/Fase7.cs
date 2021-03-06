﻿using System;
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
    /// Gabriel Henrique
    /// </summary>
    class Fase7
    {
        String autor;
        Nave_jogador jogador1;
        Texture2D fundo1;
        Texture2D fundo2;
        Song musica;
        int contVolume;
        int max = 25;
        bool tocandoMusica = true;
        Vector2 posicao;
        public bool proxima_fase;
        bool Comecar_fase7 = true;
        string Endereco = "Estados/Fase07/";
        Vector2 Texto;
        GameWindow gw;
        public static int Objetivo = 0;
        Rectangle Tamanho1;
        Rectangle Tamanho2;

        List<Nave_inimigo> inimigos = new List<Nave_inimigo>();
        Vector2 posI;
        Texture2D texturaI;
        Nave_inimigo inimigo;


        public Fase7(ContentManager Content, GameWindow Window)
        {
            #region loads principais
            this.gw = Window;
            autor = "FASE 7 - Gabriel Henrique";
            Texture2D texturaNave = Content.Load<Texture2D>(Endereco + "Nave");
            fundo1 = Content.Load<Texture2D>(Endereco + "Galaxia");
            fundo2 = Content.Load<Texture2D>(Endereco + "Galaxia");
            musica = Content.Load<Song>(Endereco + "Space music");
            posicao.X = Window.ClientBounds.Width / 2 - texturaNave.Width / 2;
            posicao.Y = Window.ClientBounds.Height / 2 - texturaNave.Height / 2;
            //jogador1 = new NaveGabriel(texturaNave, Color.White, posicao, 0f, "Teste", 3, 0, Window, texturaEscudo, Content.Load<SoundEffect>("chord"), texturaTiro, texturaBarra);
            jogador1 = new Nave_jogador(1, texturaNave, posicao, 0f, gw, Content);            
            Texto.X = 0;
            Texto.Y = Window.ClientBounds.Height - 30;
            jogador1.morto = false;
            #endregion
            #region Load do fundo
            Tamanho1.Width = gw.ClientBounds.Width;
            Tamanho1.Height = gw.ClientBounds.Height;
            Tamanho1.X = 0;
            Tamanho1.Y = 0;

            Tamanho2.Width = gw.ClientBounds.Width;
            Tamanho2.Height = gw.ClientBounds.Height;
            Tamanho2.X = gw.ClientBounds.Width;
            Tamanho2.Y = 0;
            #endregion
            #region Load do inimigo
            texturaI = Content.Load<Texture2D>(Endereco + "asteroid");
            posI.X = 100;
            posI.Y = 100;
            inimigo = new Nave_inimigo(1, texturaI, posI, 0f, gw, 3, Content);
            inimigos.Add(inimigo);
            texturaI = Content.Load<Texture2D>(Endereco + "asteroid");
            posI.X = 500;
            posI.Y = 400;
            inimigo = new Nave_inimigo(1, texturaI, posI, 0f, gw, 3, Content);
            inimigos.Add(inimigo);
            #endregion
        }
        public void Update(GameTime time, KeyboardState teclado, KeyboardState tecladoanterior, GamePadState _controle, GamePadState _controleanterior)
        {
            #region HitTest do inimigo com a nave e tiro
            for (int i = 0; i< inimigos.Count; i++)
            {
                inimigos[i].Update(time);

                if (jogador1.hitBox.Intersects(inimigos[i].hitBox))
                {
                    jogador1.morto = true;
                    MediaPlayer.Stop();
                }
                for (int i2 = 0; i2 < Shot.listaTiros.Count; i2++)
                {
                    if (Shot.listaTiros[i2].posicao.Intersects(inimigos[i].hitBox))
                    {
                        Console.WriteLine("Colisao");
                        inimigos.RemoveAt(i);
                        Shot.listaTiros.RemoveAt(i2);
                    }
                }
            }
            #endregion


            Tamanho1.X -= 5;
            Tamanho2.X -= 5;

            if (Tamanho1.X <= -gw.ClientBounds.Width)
            {
                Tamanho1.X *= -1;
            }
            if (Tamanho2.X <= -gw.ClientBounds.Width)
            {
                Tamanho2.X *= -1;
            }

            if (Comecar_fase7)
            {
                Comecar_fase7 = false;
                MediaPlayer.Play(musica);
                MediaPlayer.Volume = .5f;
            }
            contVolume++;
            if (contVolume > max) contVolume = max;

            jogador1.Update(time, teclado, tecladoanterior, _controle, _controleanterior);

            if (teclado.IsKeyDown(Keys.Q)) proxima_fase = true;

            #region Volume
            if (teclado.IsKeyDown(Keys.PageDown) && contVolume >= max)
            {
                MediaPlayer.Volume -= 0.1f;
            }
            if (teclado.IsKeyDown(Keys.PageUp) && contVolume >= max)
            {
                MediaPlayer.Volume += 0.1f;
            }
            if (teclado.IsKeyDown(Keys.P) && contVolume >= max && tocandoMusica)
            {
                MediaPlayer.Pause();
                tocandoMusica = false;
                contVolume = 0;
            }
            if (teclado.IsKeyDown(Keys.P) && contVolume >= max && !tocandoMusica)
            {
                MediaPlayer.Resume();
                tocandoMusica = true;
                contVolume = 0;
            }
            #endregion
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            #region Desenhar fundo
            //spriteBatch.Draw(fundo1, Tamanho1, Color.White);
            spriteBatch.Draw(fundo1, new Rectangle(0, 0, gw.ClientBounds.Width,
                gw.ClientBounds.Height), Color.White);
            spriteBatch.Draw(fundo2, new Rectangle(0, 0, gw.ClientBounds.Width,
                gw.ClientBounds.Height), Color.White);
            //spriteBatch.Draw(fundo2, Tamanho2, Color.White);
            #endregion
            #region Textos
            spriteBatch.DrawString(Game1.fonte, "PONTOS: " , new Vector2(5, 5), Color.White);
            spriteBatch.DrawString(Game1.fonte, autor,new Vector2(gw.ClientBounds.Width - Game1.fonte.MeasureString(autor).X - 5, 5), Color.White);
            #endregion
            #region Jogador e objetivo(texto)
            jogador1.Draw(gameTime, spriteBatch);
            //spriteBatch.DrawString(Game1.fonte, "Objetivo: Atravesse a galáxia 7 vezes para a direita", Texto, Color.White);
            #endregion
            #region Desenhar inimigo
            foreach (Nave_inimigo inimigo in inimigos)
            {
                inimigo.Draw(gameTime, spriteBatch);
            }
            #endregion

        }

    }

}
