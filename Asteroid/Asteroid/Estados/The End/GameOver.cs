﻿using System;
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
    class GameOver
    {
        private ContentManager Content;

        public GameOver(ContentManager Content)
        {
            this.Content = Content;
        }

        public void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Console.WriteLine("Desenhar GameOver");
        }

    }
}
