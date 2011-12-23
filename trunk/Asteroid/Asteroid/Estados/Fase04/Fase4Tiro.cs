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
    class Fase4Tiro
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

        public Fase4Tiro(Texture2D tiroTextura, Vector2 tiroPosicao, Color tiroCor, float tiroAngulo, GameWindow janela)
        {
            this.tiroAngulo = tiroAngulo;
            this.janela = janela;
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(this.textura, this.posicao, this.cor);
            spriteBatch.Draw(tiroTextura, tiroPosicao, new Rectangle(0, 0, tiroTextura.Width, tiroTextura.Height), tiroCor, tiroAngulo, new Vector2(tiroTextura.Width / 2, tiroTextura.Height / 2), 1, SpriteEffects.None, 0);
        }
    }
}
