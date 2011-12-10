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
    /// arthur
    /// </summary>
    class Fase1//fazer com herança
    {
        Boolean playing_musica;
        Song musica;
        Texture2D fundo;

        /// <summary>
        /// Construtor da fase1
        /// </summary>
        public Fase1(ContentManager Content)
        {
            playing_musica = false;
            musica = Content.Load<Song>("Kalimba"); 
        }
        public void Update(
            GameTime time, 
            KeyboardState teclado,
            KeyboardState tecladoanterior
            )
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
        }
        public void Draw(
            GameTime gameTime,
            SpriteBatch spriteBatch)
        {

        }

    }
}
