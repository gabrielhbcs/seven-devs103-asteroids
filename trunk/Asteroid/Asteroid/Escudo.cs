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
    class Escudo
    {
        Vector2 posicao;
        Texture2D textura;

        public Escudo( Texture2D textura)
        {
            this.textura = textura;
        }
        public void Update(Vector2 posicao)
        {
            this.posicao.X = posicao.X - textura.Width / 2;
            this.posicao.Y = posicao.Y - textura.Height / 2;
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textura, posicao, Color.White);
        }
    }
}
