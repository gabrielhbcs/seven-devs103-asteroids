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
    /// Zack
    /// </summary>
    class Fase14
    {
        String autor;
        //Boolean playing_musica;
        //Song musica;
        Texture2D texturaFundo;
        Texture2D texturaNave;
        Texture2D texturaInimigo;
        Vector2 posicao_j1;
        Vector2 posicao_i1;
        Nave_jogador jogador1;
        Nave_inimigo inimigo1;
        GameWindow gw;
        Random randomizador = new Random();

        public Fase14(ContentManager Content, GameWindow gw)
        {
            this.gw = gw;
            autor = "FASE 14 - Zack";

            //playing_musica = false;
            //musica = Content.Load<Song>("Estados/Fase02/musica_fase2");
            texturaFundo = Content.Load<Texture2D>("Estados/Fase14/fundofase14");
            texturaNave = Content.Load<Texture2D>("Estados/Fase02/naveFase2");
            posicao_j1.X = (gw.ClientBounds.Width - texturaNave.Bounds.Width) / 2;
            posicao_j1.Y = (gw.ClientBounds.Height - texturaNave.Bounds.Height) / 2;
            jogador1 = new Nave_jogador(1, texturaNave, posicao_j1, 0f, gw, Content);

            texturaInimigo = Content.Load<Texture2D>("Estados/Fase02/nave_inimiga1");
            posicao_i1.X = randomizador.Next(gw.ClientBounds.Width);
            posicao_i1.Y = randomizador.Next(gw.ClientBounds.Height);
            inimigo1 = new Nave_inimigo(0, texturaInimigo, posicao_i1, 0f, gw, 15, Content, randomizador.Next(60));
            //listaInimigos.Add(inimigo1);
        }

        public void Update(GameTime gameTime, KeyboardState teclado, KeyboardState tecladoAnterior, GamePadState _controle, GamePadState _controleanterior)
        {
            //if (!playing_musica)
            //{
            //    MediaPlayer.Play(musica);
            //    playing_musica = true;
            //}
            jogador1.Update(gameTime, teclado, tecladoAnterior, _controle, _controleanterior);
            inimigo1.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texturaFundo, new Rectangle(0, 0, gw.ClientBounds.Width,
               gw.ClientBounds.Height), Color.White);

            //spriteBatch.DrawString(Game1.fonte, "PONTOS: ", new Vector2(5, 5), Color.White);
            spriteBatch.DrawString(Game1.fonte, autor,
                new Vector2(
                    gw.ClientBounds.Width - Game1.fonte.MeasureString(autor).X - 5,
                    5), Color.White);

            jogador1.Draw(gameTime, spriteBatch);
            inimigo1.Draw(gameTime, spriteBatch);
        }

    }//fim da classe
}
