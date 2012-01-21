using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Asteroid
{
    class TheEnd
    {
        private ContentManager Content;

        public TheEnd(ContentManager Content)
        {
            this.Content = Content;
        }

        public void Update(GameTime gameTime, KeyboardState teclado)
        {
            if (teclado.IsKeyDown(Keys.Enter))
            {
                Game1.estadoAtual = Game1.estados.MENU;
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Console.WriteLine("Desenhar GameOver");
        }
    }
}
