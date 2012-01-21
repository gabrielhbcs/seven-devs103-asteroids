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

namespace Asteroid.Estados.Fase01
{
    /// <summary>
    /// Arthur 
    /// </summary>
    class Fase1//fazer com herança
    {
        String autor;
        Boolean playing_musica;
        Song musica;
        Texture2D texturaFundo;
        Texture2D texturaNave;

        Vector2 posicao_j1;
        Nave_jogador jogador1;
        GameWindow gw;

        /// <summary>
        /// Construtor da fase1
        /// </summary>
        public Fase1(ContentManager Content, GameWindow gw)
        {
            this.gw = gw;
            autor = "FASE 1 - Arthur";

            playing_musica = false;
            musica = Content.Load<Song>("Kalimba");
            texturaFundo = Content.Load<Texture2D>("Estados/Fase01/FundoFase1");
            texturaNave = Content.Load<Texture2D>("Estados/Fase01/NaveFase1");
            posicao_j1.X = (gw.ClientBounds.Width / 2) - texturaNave.Width / 2 - 150;
            posicao_j1.Y = (gw.ClientBounds.Height / 2) - texturaNave.Height / 2;

            jogador1 = new Nave_jogador(
                1,
                texturaNave,
                posicao_j1,
                0f,
                gw,
                Content);

            Console.WriteLine("PASSANDO PELO CONTRUTOR DA FASE 1");

            //objetosemtipo = new Object(desenhoParam, Vector2.Zero, 0f, gw);//NAO posso fazer isso
        }
        public void Update(GameTime time, KeyboardState teclado, KeyboardState tecladoanterior, GamePadState _controle, GamePadState _controleanterior)
        {
            jogador1.Update(time, teclado, tecladoanterior, _controle, _controleanterior);
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


        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texturaFundo, new Rectangle(0, 0, 800, 600), Color.White);

            spriteBatch.DrawString(Game1.fonte, "PONTOS: ", new Vector2(5, 5), Color.White);
            spriteBatch.DrawString(Game1.fonte, autor,
                new Vector2(
                    gw.ClientBounds.Width-Game1.fonte.MeasureString(autor).X - 5,
                    5), Color.White);

            jogador1.Draw(gameTime, spriteBatch);
        }

    }
}
