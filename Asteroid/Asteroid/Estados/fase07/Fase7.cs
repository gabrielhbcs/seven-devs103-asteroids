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
    /// gabriel
    /// </summary>
    class Fase7
    {
        String autor;
        Nave_jogador jogador1;
        Texture2D fundo;
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


        public Fase7(ContentManager Content, GameWindow Window)
        {
            this.gw = Window;
            autor = "FASE 7 - Gabriel";
            Texture2D texturaNave = Content.Load<Texture2D>(Endereco + "Nave");
            Texture2D texturaEscudo = Content.Load<Texture2D>(Endereco + "Escudo");
            Texture2D texturaTiro = Content.Load<Texture2D>(Endereco + "Tiro");
            Texture2D texturaBarra = Content.Load<Texture2D>(Endereco + "Barra");
            fundo = Content.Load<Texture2D>(Endereco + "Galaxia");
            musica = Content.Load<Song>(Endereco + "Space music");
            posicao.X = Window.ClientBounds.Width / 2 - texturaNave.Width / 2;
            posicao.Y = Window.ClientBounds.Height / 2 - texturaNave.Height / 2;
            //jogador1 = new NaveGabriel(texturaNave, Color.White, posicao, 0f, "Teste", 3, 0, Window, texturaEscudo, Content.Load<SoundEffect>("chord"), texturaTiro, texturaBarra);
            jogador1 = new Nave_jogador(1, texturaNave, posicao, 0f, gw, "Teste", 10, 0, Content);
            Texto.X = 0;
            Texto.Y = Window.ClientBounds.Height - 30;

            Console.Write(Window.ClientBounds.Height);


        }
        public void Update(GameTime time, KeyboardState teclado, KeyboardState tecladoanterior)
        {
            if (Comecar_fase7)
            {
                Comecar_fase7 = false;
                MediaPlayer.Play(musica);
                MediaPlayer.Volume = .5f;
            }
            contVolume++;
            if (contVolume > max) contVolume = max;

            jogador1.Update(time, teclado, tecladoanterior);

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
            spriteBatch.Draw(fundo, new Rectangle(0, 0, gw.ClientBounds.Width, gw.ClientBounds.Height), Color.White);

            spriteBatch.DrawString(Game1.fonte, "PONTOS: ", new Vector2(5, 5), Color.White);
            spriteBatch.DrawString(Game1.fonte, autor,
                new Vector2(
                    gw.ClientBounds.Width - Game1.fonte.MeasureString(autor).X - 5,
                    5), Color.White);

            jogador1.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(Game1.fonte, "Objetivo: Atravesse a galáxia 7 vezes para a direita", Texto, Color.White);


        }
    }
}
