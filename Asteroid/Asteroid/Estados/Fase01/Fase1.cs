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
        Boolean playing_musica;
        Song musica;
        Texture2D fundo;
        Nave_jogador jogador1;
        Objeto objetosemtipo;

        Texture2D desenhoParam;
        Vector2 posicao;
        GameWindow gw;

        /// <summary>
        /// Construtor da fase1
        /// </summary>
        public Fase1(ContentManager Content, GameWindow gw)
        {
            playing_musica = false;
            musica = Content.Load<Song>("Kalimba");
            fundo = Content.Load<Texture2D>("Estados/Fase01/FundoFase1");
            desenhoParam = Content.Load<Texture2D>("Estados/Fase01/NaveFase1");
            posicao.X = (gw.ClientBounds.Width / 2) - desenhoParam.Width / 2 - 150;
            posicao.Y = (gw.ClientBounds.Height / 2) - desenhoParam.Height / 2;

            jogador1 = new Nave_jogador(
                1,
                desenhoParam,
                posicao,
                0f,
                gw,
                "Teste",
                10,
                0);

            //objetosemtipo = new Object(desenhoParam, Vector2.Zero, 0f, gw);//NAO posso fazer isso
        }
        public void Update(GameTime time, KeyboardState teclado, KeyboardState tecladoanterior)
        {
            jogador1.Update(time, teclado, tecladoanterior);
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
            spriteBatch.Draw(fundo, new Rectangle(0, 0, 800, 600), Color.White);

            jogador1.Draw(gameTime, spriteBatch);
        }

    }
}
