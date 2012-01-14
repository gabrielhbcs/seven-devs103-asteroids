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
    class btnSelect
    {
        Texture2D textura;
        Texture2D textura2;
        Texture2D texturaAtual;
        Vector2 pos;
        int contID;
        string endereco = "Estados/Controles/";

        public btnSelect(ContentManager Content, int _contID, Vector2 _posicao)
        {
            this.contID = _contID;
            this.pos = _posicao;
            textura = Content.Load<Texture2D>(endereco + "botao");
            textura2 = Content.Load<Texture2D>(endereco + "botao2");
            texturaAtual = textura;
        }

        public void Update(GameTime time, int _cont, ContentManager _content)
        {
            if (_cont == this.contID) {
                texturaAtual = textura2;
            } else {
                texturaAtual = textura;
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texturaAtual, pos, Color.White);
        }
    }
}
