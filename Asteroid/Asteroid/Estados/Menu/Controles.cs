﻿using System;
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
    class Controles_Botao
    {
        Texture2D textura;
        Vector2 pos;
        string endereco = "Estados/Menu/";

        public Controles_Botao(ContentManager Content, int cont, Vector2 posicao)
        {
            if (cont == 2)
            {
                textura = Content.Load<Texture2D>(endereco + "controles2");
            }
            else
            {
                textura = Content.Load<Texture2D>(endereco + "controles");
            }
            pos = posicao;

        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textura, pos, Color.White);
        }
    }
}
