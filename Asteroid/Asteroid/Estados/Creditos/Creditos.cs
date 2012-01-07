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
    class Creditos
    {
        Boolean playing_musica;
        Song musica;
        Texture2D fundo;

        public Creditos(ContentManager Content)
        {
            fundo = Content.Load<Texture2D>("Estados/Creditos/creditos");
        }
        public void Update(
           GameTime time,
           KeyboardState teclado,
           KeyboardState tecladoanterior
           )
        {
            if (teclado.IsKeyDown(Keys.Enter))
            {
                Game1.estadoAtual = Game1.estados.FASE1;
            }
        }
        public void Draw(
            GameTime gameTime,
            SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                fundo,
                new Rectangle(0,0, 800, 480),
                Color.White);
        }
    }
}
