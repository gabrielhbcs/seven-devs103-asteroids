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
    /// Classe Nave do Jogador HERDANDO as características dos objetos que aparecem em cena
    /// </summary>
    class Nave_jogador:Objeto
    {
        int jogador;
        string nome;
        int vidas;
        int pontos;

        TiroFase2 tiro;
        String tipoTiro;
        //SoundEffect tiroSom;
        bool atirando;
        SpriteBatch sb;

        public Nave_jogador(
            int jogador,
            Texture2D textura,
            Vector2 posicao,
            float angulo,
            GameWindow gw,
            string nome,
            int vidas,
            int pontos,
            ContentManager Content
            )
            : base(
            textura,
            posicao,
            angulo,
            gw,
            Content)
            
        {
            this.jogador = jogador;
            tipoTiro = "plasma";
            //tiroSom = _tirosom;
            atirando = false;
            this.nome = nome;
            this.vidas = vidas;
            this.pontos = pontos;
        }


        public void Update(GameTime _gameTime, KeyboardState _teclado, KeyboardState _tecladoAnterior)
        {
            if (jogador == 1)
            {
                #region ESQUERDA
                if (_teclado.IsKeyDown(Keys.A))
                {
                    angulo -= 2;
                }
                #endregion

                #region DIREITA
                if (_teclado.IsKeyDown(Keys.D))
                {
                    angulo += 2;
                }
                #endregion

                #region CIMA (Acelera)
                if (_teclado.IsKeyDown(Keys.W))
                {
                    velocidade.X += (float)Math.Cos(Math.PI * angulo / 180) * 0.02f;
                    velocidade.Y += (float)Math.Sin(Math.PI * angulo / 180) * 0.02f;
                }
                #endregion

                #region SPACE (Atira)
                if (_teclado.IsKeyDown(Keys.Space) && _tecladoAnterior.IsKeyUp(Keys.Space))
                {
                    //tiroSom.Play();
                    // COICE do tiro
                    velocidade.X -= (float)Math.Cos(Math.PI * angulo / 180) * 0.3f;
                    velocidade.Y -= (float)Math.Sin(Math.PI * angulo / 180) * 0.3f;
                    tiro = new TiroFase2(tipoTiro, posicao, gw, angulo, Content);
                    
                    atirando = true;
                }
                #endregion
            }

            #region Jogador 2 (Não implementado)
            if (jogador == 2)
            {
                if (_teclado.IsKeyDown(Keys.A))
                {
                }

                if (_teclado.IsKeyDown(Keys.D))
                {
                }

                if (_teclado.IsKeyDown(Keys.W))
                {
                }
            }
            #endregion

            //Console.WriteLine("JOGADOR "+ jogador + " / PosY=" + posicao.Y);

            #region Verificar os limites de velocidade (Falta parametrizar)
            if (velocidade.X > 4) { velocidade.X = 4; }
            if (velocidade.Y > 4) { velocidade.Y = 4; }
            if (velocidade.X < -4) { velocidade.X = -4; }
            if (velocidade.Y < -4) { velocidade.Y = -4; }
            #endregion

            posicao += velocidade;

            #region Verifica nave nos limites da tela
            if (posicao.X < 0)
            {
                posicao.X = gw.ClientBounds.Width;
            }
            else if (posicao.X > gw.ClientBounds.Width)
            {
                posicao.X = 0;
            }

            if (posicao.Y < 0)
            {
                posicao.Y = gw.ClientBounds.Height;
            }
            else if (posicao.Y > gw.ClientBounds.Height)
            {
                posicao.Y = 0;
            }
            #endregion

            if (atirando)
            {
                tiro.Update(_gameTime);
            }

        }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            sb.Draw(
                textura,
                posicao,
                new Rectangle(0, 0, textura.Width, textura.Height),
                cor,
                MathHelper.ToRadians(angulo),
                new Vector2(textura.Width / 2, textura.Height / 2),
                1,
                SpriteEffects.None,
                0);

            if (atirando)
            {
                tiro.Draw(gameTime, sb);
            }

            //sb.Draw(textura, Vector2.Zero, Color.White);
        }


    }//fim classe
}//fim namespace
