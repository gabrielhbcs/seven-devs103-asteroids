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
        String autor;
        Boolean playing_musica;
        Song musica;
        Texture2D texturaFundo;
        Vector2 posicaoInicial_j1;
        Vector2 posicao_a1;
        Texture2D texturaNave;
        Texture2D texturaAsteroids;
        Nave_jogador jogador1;

        List<Nave_inimigo> lista_asteroids = new List<Nave_inimigo>();
        Random randomizador = new Random();

        GameWindow gw;
        /// <summary>
        /// Construtor da fase
        /// </summary>
        public Fase4(ContentManager Content, GameWindow gw)
        {
            playing_musica = false;
            musica = Content.Load<Song>("Kalimba");

            texturaFundo = Content.Load<Texture2D>("Estados/Fase04/fundoFase4");
            texturaNave = Content.Load<Texture2D>("Estados/Fase04/naveFase4");
            texturaAsteroids = Content.Load<Texture2D>("Estados/Fase04/asteroidsFase4");

            posicaoInicial_j1.X = (gw.ClientBounds.Width - texturaNave.Bounds.Width) / 2;
            posicaoInicial_j1.Y = (gw.ClientBounds.Height - texturaNave.Bounds.Height) / 2;
            jogador1 = new Nave_jogador(1, texturaNave, posicaoInicial_j1, 0, gw, Content);

            posicao_a1.X = randomizador.Next(gw.ClientBounds.Width);
            posicao_a1.Y = randomizador.Next(gw.ClientBounds.Height);
            lista_asteroids.Add(new Nave_inimigo(1, texturaAsteroids, posicao_a1, 0f, gw, 15, Content));
        }
        public void Update(GameTime gameTime, KeyboardState teclado, KeyboardState tecladoAnterior, GamePadState _controle, GamePadState _controleanterior)
        {
            if (!playing_musica)
            {
                MediaPlayer.Play(musica);
                playing_musica = true;
            }
            jogador1.Update(gameTime, teclado, tecladoAnterior, _controle, _controleanterior);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(fundo, posFundo, Color.White);

            spriteBatch.DrawString(Game1.fonte, "PONTOS: ", new Vector2(5, 5), Color.White);
            spriteBatch.DrawString(Game1.fonte, autor, new Vector2(gw.ClientBounds.Width - Game1.fonte.MeasureString(autor).X - 5, 5), Color.White);

            jogador1.Draw(gameTime, spriteBatch);

            foreach (Nave_inimigo asteroids in lista_asteroids)
            {
                asteroids.Draw(gameTime, spriteBatch);
            }
        }
    }
}