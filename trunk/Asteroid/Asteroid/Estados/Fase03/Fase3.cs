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
    class Fase3//fazer com herança
    {
        Boolean playing_musica;
        Song musica;
        Texture2D fundo, naveGraph;
        Nave_jogador jogador1;
        Vector2 posicao1;
        string file_path = "Estados/Fase03/";

        /// <summary>
        /// Construtor da fase1
        /// </summary>
        public Fase3(ContentManager Content, GameWindow Window)
        {
            playing_musica = false;
            musica = Content.Load<Song>(file_path + "fase3");
            fundo = Content.Load<Texture2D>(file_path + "fundo_fase3");

            naveGraph = Content.Load<Texture2D>(file_path + "Nave_fase3");
            posicao1.X = (Window.ClientBounds.Width / 2) - naveGraph.Width / 2 - 150;
            posicao1.Y = (Window.ClientBounds.Height / 2) - naveGraph.Height / 2;
            jogador1 = new Nave_jogador(1, naveGraph, posicao1, 0f, Window, "Teste", 10, 0);
        }
        public void Update(GameTime gameTime, KeyboardState teclado, KeyboardState tecladoanterior)
        {
            if (!playing_musica)
            {
                playing_musica = true;
                MediaPlayer.Play(musica);
                MediaPlayer.Volume = 0.5f;
            }
            if ((teclado.IsKeyDown(Keys.PageUp)) && !(tecladoanterior.IsKeyDown(Keys.PageUp)))
            {
                MediaPlayer.Volume += 0.1f;
            }

            if ((teclado.IsKeyDown(Keys.PageDown)) && !(tecladoanterior.IsKeyDown(Keys.PageDown)))
            {
                MediaPlayer.Volume -= 0.1f;
            }

            if ((teclado.IsKeyDown(Keys.Enter)) && !(tecladoanterior.IsKeyDown(Keys.Enter)))
            {
                Game1.estadoAtual = Game1.estados.FASE2;
            }

            jogador1.Update(gameTime, teclado, tecladoanterior);
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(fundo, new Rectangle(0, 0, 800, 480), Color.White);
            jogador1.Draw(gameTime, spriteBatch);
        }

    }
}
