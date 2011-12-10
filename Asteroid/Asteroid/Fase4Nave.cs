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

namespace AsteroidsPlus
{
    /// <summary>
    /// asassasaasassaas
    /// </summary>
    class Nave
    {

        #region atributos
        // determina regioções personalizadas no código

        /// <summary>
        /// imagem blablabla
        /// </summary>
        Texture2D textura;
        /// <summary>
        /// blablabla
        /// </summary>
        Vector2 posicao;
        Vector2 velocidade;
        float angulo;
        string nomeJogador;
        short vidas;
        ulong pontos;
        Color cor;
        GameWindow janela;

        List<Keys> Controles;

        Tiro tiro;
        Texture2D tiroTextura;

        // Boolean trava;

        SoundEffect tiroSom;
        private Texture2D texturaNave;
        private Vector2 posicaoInicial;
        private Color color;
        private float p;
        private string p_2;
        private int p_3;
        private int p_4;
        private GameWindow Window;
        private SoundEffect soundEffect;

        // abaixo finaliza a determinação
        #endregion

        /// <summary>
        /// Cria a minha nave com valores padroes blablabla
        /// </summary>
        /// <param name="textura"></param>
        /// <param name="posicao">por favor passe a posicao do meio da tela</param>
        /// <param name="cor"></param>
        public Nave(Texture2D textura, Vector2 posicao, Color cor)
        {
            this.textura = textura;
            this.posicao = posicao;
            this.cor = cor;
            this.angulo = 0;
            this.nomeJogador = "Jogador";
            this.vidas = 5;
            this.pontos = 0;
        }
        // C# substitui automaticamente
        public Nave(Texture2D textura, Vector2 posicao, Color cor, float angulo, string nomeJogador, short vidas, ulong pontos, GameWindow janela, List<Keys> control, SoundEffect som)
        {
            this.angulo = angulo;
            this.nomeJogador = nomeJogador;
            this.vidas = vidas;
            this.pontos = pontos;
            this.janela = janela;
            this.Controles = control;

            this.tiroSom = som;
        }

        //public Nave(float p, string p_2, int p_3, int p_4)
        //{
        //    // TODO: Complete member initialization
        //    this.p = p;
        //    this.p_2 = p_2;
        //    this.p_3 = p_3;
        //    this.p_4 = p_4;
        //}
        

        public void Update(GameTime gameTime, KeyboardState teclado, KeyboardState tecladoAnterior)
        {
            if (this.posicao.X <= (0 - this.textura.Width))
            {
                this.posicao.X = (janela.ClientBounds.Width + 17);
            }
            if ((this.posicao.X - this.textura.Width) >= (janela.ClientBounds.Width - 17))
            {
                this.posicao.X = (0 - this.textura.Width);
            }

            if (this.posicao.Y <= (0 - this.textura.Height))
            {
                this.posicao.Y = janela.ClientBounds.Height;
            }
            if ((this.posicao.Y - this.textura.Height) >= (janela.ClientBounds.Height - 17))
            {
                this.posicao.Y = (0 - this.textura.Height);
            }

            
            if (teclado.IsKeyDown(Controles[0])){ this.angulo -= 0.15f; }

            if (teclado.IsKeyDown(Controles[1])) { this.angulo += 0.15f; }

            if (teclado.IsKeyDown(Controles[2]))
            {
                this.posicao.X += (float)(Math.Sin(angulo)) *2;
                this.posicao.Y -= (float)(Math.Cos(angulo)) *2;
                Console.WriteLine(posicao);
            }

            if (teclado.IsKeyDown(Controles[3]) && !tecladoAnterior.IsKeyDown(Controles[3]))
            {
                this.tiroSom.Play();
                Console.WriteLine(tiroSom);
            }

            //if (teclado.IsKeyDown(Keys.Down))
            //    this.posicao.Y++;

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(this.textura, this.posicao, this.cor);
            spriteBatch.Draw(textura, posicao, new Rectangle(0, 0, textura.Width, textura.Height), cor, angulo, new Vector2(textura.Width/2, textura.Height/2), 1, SpriteEffects.None, 0);
        }
    }
}