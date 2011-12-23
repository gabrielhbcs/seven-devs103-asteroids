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
    /// <summary>
    /// asassasaasassaas
    /// </summary>
    class Fase4Nave
    {

        #region atributos
        // determina regioções personalizadas no código

        /// <summary>
        /// imagem blablabla
        /// </summary>
        Texture2D texturaNave;
        /// <summary>
        /// blablabla
        /// </summary>
        Vector2 posicao;
        //Vector2 velocidade;
        float angulo;
        string nomeJogador;
        short vidas;
        ulong pontos;
        Color cor;

        private ContentManager Content;
        private GameWindow janela;

        List<Keys> Controles;

        //Fase4Tiro tiro;

        // Boolean trava;

        SoundEffect tiroSom;
        
        
        //float p;
        //string p_2;
        //int p_3;
        //int p_4;
        
        // abaixo finaliza a determinação
        #endregion

        /// <summary>
        /// Cria a minha nave com valores padroes blablabla
        /// </summary>
        /// <param name="textura"></param>
        /// <param name="posicao">por favor passe a posicao do meio da tela</param>
        /// <param name="cor"></param>
        public Fase4Nave(Texture2D textura, Vector2 posicao, Color cor)
        {
            texturaNave = Content.Load<Texture2D>("Estados/Fase04/naveFase4");
            this.texturaNave = textura;
            this.posicao = posicao;
            this.cor = cor;
            this.angulo = 0;
            this.nomeJogador = "Jogador";
            this.vidas = 5;
            this.pontos = 0;
        }
        // C# substitui automaticamente
        public Fase4Nave(Texture2D textura, Vector2 posicao, Color cor, float angulo, string nomeJogador, short vidas, ulong pontos, GameWindow janela, List<Keys> control, SoundEffect som)
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
            if (this.posicao.X <= (0 - this.texturaNave.Width))
            {
                this.posicao.X = (janela.ClientBounds.Width + 17);
            }
            if ((this.posicao.X - this.texturaNave.Width) >= (janela.ClientBounds.Width - 17))
            {
                this.posicao.X = (0 - this.texturaNave.Width);
            }

            if (this.posicao.Y <= (0 - this.texturaNave.Height))
            {
                this.posicao.Y = janela.ClientBounds.Height;
            }
            if ((this.posicao.Y - this.texturaNave.Height) >= (janela.ClientBounds.Height - 17))
            {
                this.posicao.Y = (0 - this.texturaNave.Height);
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
            spriteBatch.Draw(texturaNave, posicao, new Rectangle(0, 0, texturaNave.Width, texturaNave.Height), cor, angulo, new Vector2(texturaNave.Width / 2, texturaNave.Height / 2), 1, SpriteEffects.None, 0);
        }
    }
}