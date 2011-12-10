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
    class Barra
    {
        bool ativado;
        Rectangle tamanho;
        public bool permicao;
        int largura = 200;

        Texture2D textura;
        Vector2 posBarra;

        public Barra(Texture2D textura)
        {
            permicao = true;
            tamanho.Width = largura;
            tamanho.Height = 20;
            tamanho.X = 10;
            tamanho.Y = 10;
            this.textura = textura;
        }
        public void Update(bool ativado)
        {
            #region Diminuir e aumentar
            this.ativado = ativado;
            if (tamanho.Width >= largura) tamanho.Width = largura;
            if (tamanho.Width <= 1)
            {
                ativado = false;
                permicao = false;
            }

            if (ativado) tamanho.Width -= 3;
            if (!ativado) tamanho.Width += 1;
            if (!permicao) tamanho.Width += 1;
            if (!permicao && tamanho.Width < 50) tamanho.Width += 1;
            if (!permicao && tamanho.Width > 100) permicao = true;
            #endregion
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textura, tamanho, Color.White);
        }
    }
}
