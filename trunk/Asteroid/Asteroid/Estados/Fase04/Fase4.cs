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
    /// fabio
    /// </summary>
    class Fase4 // fazer com herança
    {
        Boolean playing_musica;
        Song musica;
        Vector2 posicaoInicial_j1;
        Texture2D texturaNave;
        Nave_jogador jogador1;

        /// <summary>
        /// Construtor da fase
        /// </summary>
        public Fase4(ContentManager Content, GameWindow gw)
        {
            playing_musica = false;
            musica = Content.Load<Song>("Kalimba");

            texturaNave = Content.Load<Texture2D>("Estados/Fase04/naveFase4");
            posicaoInicial_j1.X = (gw.ClientBounds.Width - texturaNave.Bounds.Width) / 2;
            posicaoInicial_j1.Y = (gw.ClientBounds.Height - texturaNave.Bounds.Height) / 2;
            jogador1 = new Nave_jogador(1, texturaNave, posicaoInicial_j1, 0, gw, "Fábio", 3, 0);
        }
        public void Update(GameTime gameTime, KeyboardState teclado, KeyboardState tecladoAnterior)
        {
            if (!playing_musica)
            {
                MediaPlayer.Play(musica);
                playing_musica = true;
            }
            jogador1.Update(gameTime, teclado, tecladoAnterior);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(fundo, posFundo, Color.White);

            spriteBatch.DrawString(Game1.fonte, "PONTOS: ", new Vector2(5, 5), Color.White);
            spriteBatch.DrawString(Game1.fonte, "FASE 4 - Fabio", new Vector2(560, 5), Color.White);

            jogador1.Draw(gameTime, spriteBatch);
        }
    }
}