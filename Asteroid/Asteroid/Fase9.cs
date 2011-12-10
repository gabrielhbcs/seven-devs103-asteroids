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
    /// lucas abend
    /// </summary>
    class Fase9
    {
        // SpriteBatch spriteBatch;
        ContentManager conteudo;
        GameWindow janela;
        Texture2D nave;
        Texture2D desenho;
        Vector2 posicao1;
        // Vector2 posicao2;
        Nave_fase9 jogador1;
        // Nave_fase9 jogador2;
        KeyboardState teclado;
        KeyboardState tecladoAnterior;
        Song musica;
        bool inicio_fase9 = true;
        bool playing = false;

        public Fase9(ContentManager conteudo, GameWindow janela)
        {
            this.conteudo = conteudo;
            this.janela = janela;
            // spriteBatch = new SpriteBatch(GraphicsDevice);
            nave = conteudo.Load<Texture2D>("Nave");
            desenho = conteudo.Load<Texture2D>("Fundo_espaco");
            musica = conteudo.Load<Song>("Kalimba");

            posicao1.X = (janela.ClientBounds.Width / 2) - nave.Width / 2 - 150;
            posicao1.Y = (janela.ClientBounds.Height / 2) - nave.Height / 2;
            jogador1 = new Nave_fase9(nave, posicao1, Color.Red, janela, conteudo.Load<SoundEffect>("ding"));

            /* posicao2.X = (janela.ClientBounds.Width / 2) - nave.Width / 2 + 150;
            posicao2.Y = (janela.ClientBounds.Height / 2) - nave.Height / 2;
            jogador2 = new Nave_fase9(nave, posicao2, Color.Blue, janela, conteudo.Load<SoundEffect>("ding")); */
        }

        public void Update(GameTime time, /* int keyboardType,*/ KeyboardState teclado, KeyboardState tecladoAnterior)
        {
            if (inicio_fase9)
            {
                inicio_fase9 = false;
                MediaPlayer.Play(musica);
                MediaPlayer.Volume = .5f;
                playing = true;
                // Console.WriteLine(musica);
            }

            jogador1.Update(time, 1, teclado, tecladoAnterior);

            if (teclado.IsKeyDown(Keys.PageUp) && !(tecladoAnterior.IsKeyDown(Keys.PageUp)))
            {
                MediaPlayer.Volume += 0.1f;
                // Console.WriteLine(MediaPlayer.Volume);
            }

            if (teclado.IsKeyDown(Keys.PageDown) && !(tecladoAnterior.IsKeyDown(Keys.PageDown)))
            {
                MediaPlayer.Volume -= 0.1f;
                // Console.WriteLine(MediaPlayer.Volume);
            }

            if (teclado.IsKeyDown(Keys.P) && !(tecladoAnterior.IsKeyDown(Keys.P)))
            {
                if (playing)
                {
                    MediaPlayer.Pause();
                    playing = false;
                }
                else
                {
                    MediaPlayer.Resume();
                    playing = true;
                }
                // Console.WriteLine(MediaPlayer.Volume);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // spriteBatch.Draw(desenho, new Rectangle(0, 0, desenho.Width, desenho.Height), Color.Blue, new Vector2(desenho.Width / 2, desenho.Height / 2), 1, SpriteEffects.None, 0);
            spriteBatch.Draw(desenho, new Rectangle(0, 0, janela.ClientBounds.Width, janela.ClientBounds.Height), Color.Blue);

            jogador1.Draw(gameTime, spriteBatch);
        }
    }
}
