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
    class Nave1
    {
        #region Atributos
        Vector2 posicao;
        Texture2D desenho;
        Vector2 velocidade;
        float aceleracao;
        float angulo;
        Rectangle colisao;
        int vidas;
        int pontos;
        Color cor;
        KeyboardState teclado;
        GameWindow gw;
        string nomeJogador;
        SoundEffect somtiro;
        #endregion

        public Nave1(Texture2D desenhoParam, Vector2 posicaoParam, Color corParam, GameWindow gwParam, SoundEffect _somtiro)
        {
            this.desenho = desenhoParam;
            this.posicao = posicaoParam;
            this.cor = corParam;
            this.gw = gwParam;
            this.angulo = 0;
            this.nomeJogador = "Jogador";
            this.vidas = 5;
            this.pontos = 0;
            this.aceleracao = 0;
            this.somtiro = _somtiro;
        }

        public void Update(GameTime time, KeyboardState teclado, KeyboardState tecladoAnterior)
        {
            if (this.aceleracao > 0)
            {
                this.aceleracao -= 0.01f;
            }
            else if (this.aceleracao < 0)
            {
                this.aceleracao = 0;
            }

            if (teclado.IsKeyDown(Keys.Left))
            {
                this.angulo -= 0.1f;
            }

            if (teclado.IsKeyDown(Keys.Right))
            {
                this.angulo += 0.1f;
            }

            if (teclado.IsKeyDown(Keys.Up))
            {
                this.aceleracao += 0.1f;
            }
            if (teclado.IsKeyDown(Keys.Down))
            {
                this.aceleracao -= 0.1f;
            }

            if ((teclado.IsKeyDown(Keys.Space)) && !(tecladoAnterior.IsKeyDown(Keys.Space)))
            {
                this.somtiro.Play();
                Console.WriteLine(this.somtiro.Duration);
            }

            this.posicao.X += (float)(Math.Cos(angulo)) * this.aceleracao;
            this.posicao.Y += (float)(Math.Sin(angulo)) * this.aceleracao;

            if (posicao.X > gw.ClientBounds.Width)
            {
                posicao.X = 0 - this.desenho.Width;
            }

            if (posicao.X < 0 - this.desenho.Width)
            {
                posicao.X = gw.ClientBounds.Width;
            }

            if (posicao.Y > gw.ClientBounds.Height)
            {
                posicao.Y = 0 - this.desenho.Height;
            }

            if (posicao.Y < 0 - this.desenho.Height)
            {
                posicao.Y = gw.ClientBounds.Height;
            }

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(desenho, posicao, new Rectangle(0, 0, desenho.Width, desenho.Height), cor, angulo, new Vector2(desenho.Width / 2, desenho.Height / 2), 1, SpriteEffects.None, 0);
        }
    }
}
