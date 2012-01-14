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
    /// Daniel Coimbra
    /// </summary>
    class Fase3 //fazer com herança
    {
        String autor;
        Boolean playing_musica;
        Song musica;
        Texture2D texturaFundo;
        Texture2D texturaNave;
        Texture2D texturaInimigo;
        Vector2 posicao_j1;
        Vector2 posicao_i1;
        Nave_jogador jogador1;
        Nave_inimigo inimigo1;
        GameWindow gw;
        Random randomizador = new Random();
        List<Nave_inimigo> listaInimigos = new List<Nave_inimigo>();
        ContentManager _Content;
        int inimigosRestantes;

        string file_path = "Estados/Fase03/";

        /// <summary>
        /// Construtor da fase1
        /// </summary>
        public Fase3(ContentManager Content, GameWindow gw)
        {
            this.gw = gw;
            autor = "FASE 3 - Daniel Coimbra";

            _Content = Content;

            #region init audio
            playing_musica = false;
            musica = Content.Load<Song>(file_path + "fase3");
            #endregion

            inimigosRestantes = 5;
            texturaFundo = Content.Load<Texture2D>(file_path + "fundo_fase3");
            texturaNave = Content.Load<Texture2D>(file_path + "Nave_fase3");
            posicao_j1.X = (gw.ClientBounds.Width / 2) - texturaNave.Width / 2 - 150;
            posicao_j1.Y = (gw.ClientBounds.Height / 2) - texturaNave.Height / 2;
            jogador1 = new Nave_jogador(1, texturaNave, posicao_j1, 0f, gw, Content);

            texturaInimigo = Content.Load<Texture2D>("Estados/Fase02/nave_inimiga1");

            for (int i = 0; i < 5; i++)
            {
                posicao_i1.X = randomizador.Next(gw.ClientBounds.Width);
                posicao_i1.Y = randomizador.Next(gw.ClientBounds.Height);
                inimigo1 = new Nave_inimigo(0, texturaInimigo, posicao_i1, 0f, gw, 15, Content, randomizador.Next(60));
                listaInimigos.Add(inimigo1);
            }
        }

        public void Update(GameTime gameTime, KeyboardState teclado, KeyboardState tecladoanterior, GamePadState _controle, GamePadState _controleanterior)
        {
            #region controle audio
            if (!playing_musica)
            {
                playing_musica = true;
                MediaPlayer.Play(musica);
                MediaPlayer.Volume = 0.5f;
            }

            //if ( ( teclado.IsKeyDown(Keys.PageUp) ) && !( tecladoanterior.IsKeyDown(Keys.PageUp) ) )
            //{
            //    MediaPlayer.Volume += 0.1f;
            //}

            //if ( ( teclado.IsKeyDown(Keys.PageDown) ) && !( tecladoanterior.IsKeyDown(Keys.PageDown) ) )
            //{
            //    MediaPlayer.Volume -= 0.1f;
            //}
            #endregion

            if ((teclado.IsKeyDown(Keys.Enter)) && !(tecladoanterior.IsKeyDown(Keys.Enter)))
            {
                Game1.estadoAtual = Game1.estados.FASE2;
            }

            jogador1.Update(gameTime, teclado, tecladoanterior, _controle, _controleanterior);

            for (int i = 0; i < listaInimigos.Count; i++)
            {
                listaInimigos[i].Update(gameTime);

                // checa a colisao da nava com os inimigos
                if (jogador1.Colisao(listaInimigos[i].hitBox))
                {
                    Nave_jogador.vidas--;
                }
            }

            for (int i = 0; i < Shot.listaTiros.Count; i++)
            {
                for (int j = 0; j < listaInimigos.Count; j++)
                {
                    if (Shot.listaTiros[i].Colisao(listaInimigos[j].hitBox))
                    {
                        listaInimigos.RemoveAt(j);
                        inimigosRestantes--;
                    }
                }
            }

            if (listaInimigos.Count < 5)
            {
                posicao_i1.X = randomizador.Next(gw.ClientBounds.Width);
                posicao_i1.Y = randomizador.Next(gw.ClientBounds.Height);
                inimigo1 = new Nave_inimigo(0, texturaInimigo, posicao_i1, 0f, gw, 15, _Content);
                listaInimigos.Add(inimigo1);
            }

            if (inimigosRestantes == 0)
            {
                Game1.estadoAtual = Game1.estados.FASE4;
            }

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texturaFundo, new Rectangle(0, 0, 800, 480), Color.White);

            spriteBatch.DrawString(
                Game1.fonte
                , "Inimigos restantes: " + inimigosRestantes
                , new Vector2(5, 5)
                , Color.White
            );

            spriteBatch.DrawString(
                Game1.fonte
                , "Naves: " + Nave_jogador.vidas
                , new Vector2(Game1.fonte.MeasureString("Inimigos restantes: 999").X, 5)
                , Color.White
            );

            spriteBatch.DrawString(
                Game1.fonte
                , autor
                , new Vector2(gw.ClientBounds.Width - Game1.fonte.MeasureString(autor).X - 5, 5)
                , Color.White
            );

            jogador1.Draw(gameTime, spriteBatch);

            for (int i = 0; i < listaInimigos.Count; i++)
            {
                listaInimigos[i].Draw(gameTime, spriteBatch);
            }
        }

    }
}