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
        String autor;
        ContentManager conteudo;
        GameWindow gw;
        Texture2D nave;
        Texture2D desenho;
        Vector2 posicao1;
        // Vector2 posicao2;
        Nave_jogador jogador1;
        //Nave_fase9 jogador1;
        // Nave_fase9 jogador2;
        Asteroide asteroide_gerenciador;

        Song musica;
        bool inicio_fase9 = true;
        bool playing = false;

        string file_path = "Estados/Fase09/";

        public Fase9(ContentManager conteudo, GameWindow janela)
        {
            autor = "FASE 9 - Lucas Abend";

            this.conteudo = conteudo;
            this.gw = janela;
            // spriteBatch = new SpriteBatch(GraphicsDevice);
            nave = conteudo.Load<Texture2D>(file_path + "Nave_fase9");
            desenho = conteudo.Load<Texture2D>("Fundo_espaco");
            musica = conteudo.Load<Song>("Kalimba");

            posicao1.X = (janela.ClientBounds.Width / 2) - nave.Width / 2 - 150;
            posicao1.Y = (janela.ClientBounds.Height / 2) - nave.Height / 2;
            //jogador1 = new Nave_fase9(nave, posicao1, Color.Red, janela, conteudo.Load<SoundEffect>("ding"));
            jogador1 = new Nave_jogador(1, nave, posicao1, 0f, gw,  conteudo);

            /* posicao2.X = (janela.ClientBounds.Width / 2) - nave.Width / 2 + 150;
            posicao2.Y = (janela.ClientBounds.Height / 2) - nave.Height / 2;
            jogador2 = new Nave_fase9(nave, posicao2, Color.Blue, janela, conteudo.Load<SoundEffect>("ding")); */

            asteroide_gerenciador = new Asteroide(conteudo.Load<Texture2D>("Asteroides"), Vector2.Zero, 0.0f, gw, conteudo);
        }

        public void Update(GameTime time, /* int keyboardType,*/ KeyboardState teclado, KeyboardState tecladoAnterior, GamePadState _controle, GamePadState _controleanterior)
        {
            if (inicio_fase9)
            {
                inicio_fase9 = false;
                MediaPlayer.Play(musica);
                MediaPlayer.Volume = .5f;
                playing = true;
                // Console.WriteLine(musica);
            }

            //jogador1.Update(time, 1, teclado, tecladoAnterior);
            jogador1.Update(time, teclado, tecladoAnterior, _controle, _controleanterior);

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

            asteroide_gerenciador.Update(time);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // spriteBatch.Draw(desenho, new Rectangle(0, 0, desenho.Width, desenho.Height), Color.Blue, new Vector2(desenho.Width / 2, desenho.Height / 2), 1, SpriteEffects.None, 0);
            spriteBatch.Draw(desenho, new Rectangle(0, 0, gw.ClientBounds.Width, gw.ClientBounds.Height), Color.Blue);

            asteroide_gerenciador.Draw(gameTime, spriteBatch);

            spriteBatch.DrawString(Game1.fonte, "PONTOS: ", new Vector2(5, 5), Color.White);
            spriteBatch.DrawString(Game1.fonte, autor,
                new Vector2(
                    gw.ClientBounds.Width - Game1.fonte.MeasureString(autor).X - 5,
                    5), Color.White);

            jogador1.Draw(gameTime, spriteBatch);
        }
    }
}
