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

namespace AsteroidsPlus
{
    class Tiro
    {
        #region atributos
        // determina regiões personalizadas no código

        /// <summary>
        /// imagem blablabla
        /// </summary>
        private Texture2D tiroTextura;
        /// <summary>
        /// blablabla
        /// </summary>
        private Vector2 tiroPosicao;

        float tiroAngulo;

        private Color tiroCor;
        GameWindow janela;

        // Boolean trava;

        // abaixo finaliza a determinação
        #endregion

        public Tiro(Texture2D tiroTextura, Vector2 posicao, Color tiroCor, float tiroAngulo, GameWindow janela)
        {
            this.tiroAngulo = tiroAngulo;
            this.janela = janela;
        }

        protected override void Update(GameTime gameTime)
        {
        }

        protected override Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(this.textura, this.posicao, this.cor);
            spriteBatch.Draw(textura, posicao, new Rectangle(0, 0, textura.Width, textura.Height), cor, angulo, new Vector2(textura.Width / 2, textura.Height / 2), 1, SpriteEffects.None, 0);
        }
    }
}
