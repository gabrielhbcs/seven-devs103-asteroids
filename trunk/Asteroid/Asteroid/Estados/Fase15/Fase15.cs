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
    /// Christian Andrade
    /// </summary>
    class Fase15
    {
        Boolean playing_musica;
        Song musica;
        Texture2D backgroundTexture;
        Vector2 bgPosition;
        Nave_jogador Nave;
        Texture2D naveTexture;
        Objeto objetosemtipo;
        Texture2D desenhoParam;
        Vector2 posicao;
        Vector2 stageSize;
        GameWindow gw;

         public Fase15(ContentManager Content, GameWindow gw){
            
        }
        public void Update(GameTime time, KeyboardState teclado, KeyboardState tecladoanterior)
        {
           
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch){
            spriteBatch.Draw(backgroundTexture, bgPosition, Color.White);
        }

    }
}
