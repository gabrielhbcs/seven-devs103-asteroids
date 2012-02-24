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
    class Intro
    {
        Texture2D fundo;

        GameWindow gw;

        public Intro(ContentManager Content, GameWindow gw)
        {
            this.gw = gw;

            fundo = Content.Load<Texture2D>("Estados/Intro/intro");
        }

        public void Draw(
            GameTime gameTime,
            SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                fundo,
                new Rectangle(0, 0, gw.ClientBounds.Width,
                gw.ClientBounds.Height),
                Color.White);
        }
    }
}
