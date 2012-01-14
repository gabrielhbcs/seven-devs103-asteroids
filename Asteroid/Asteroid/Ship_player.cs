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
        /// <summary>
        /// usado para dizer qual controle vai usar (wasd, uhjk)
        /// </summary>
        int jogador;

        /// <summary>
        /// qtd de vidas do jogador
        /// </summary>
        public static int vidas;

        /// <summary>
        /// qtd de pontos do jogador
        /// </summary>
        public static int pontos;

        /// <summary>
        /// Velocidade segundo a qual a nave anda para frente
        /// Setada em Status
        /// </summary>
        public static int velocidade_linear;

        /// <summary>
        /// Velocidade segundo a qual a nave gira
        /// Setada em Status
        /// </summary>
        public static int velocidade_angular;

        //TiroFase2 tiro;
        String tipoTiro;
        bool atirando;

        public Rectangle hitBox;

        public Nave_jogador(
            int jogador,
            Texture2D textura,
            Vector2 posicao,
            float angulo,
            GameWindow gw,
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
            Nave_jogador.vidas = 7;
            Nave_jogador.pontos = 0;
            hitBox = new Rectangle((int)posicao.X, (int)posicao.Y, textura.Width, textura.Height);
        }


        public void Update(GameTime _gameTime, KeyboardState _teclado, KeyboardState _tecladoAnterior, GamePadState _controle, GamePadState _controleanterior)
        {
            if (jogador == 1)
            {
                #region ESQUERDA
                if (_teclado.IsKeyDown(Keys.A) || _controle.IsButtonDown(Buttons.DPadLeft) || _controle.IsButtonDown(Buttons.LeftThumbstickLeft))
                {
                    angulo -= 2;
                }
                #endregion

                #region DIREITA
                if (_teclado.IsKeyDown(Keys.D) || _controle.IsButtonDown(Buttons.DPadRight) || _controle.IsButtonDown(Buttons.LeftThumbstickRight))
                {
                    angulo += 2;
                }
                #endregion

                #region CIMA (Acelera)
                if (_teclado.IsKeyDown(Keys.W) || _controle.IsButtonDown(Buttons.DPadUp) || _controle.IsButtonDown(Buttons.LeftThumbstickUp))
                {
                    //velocidade.X += (float)Math.Cos(Math.PI * angulo / 180) * 0.02f;
                    //velocidade.Y += (float)Math.Sin(Math.PI * angulo / 180) * 0.02f;
                }
                #endregion

                #region SPACE (Atira)
                if ((_teclado.IsKeyDown(Keys.Space) && _tecladoAnterior.IsKeyUp(Keys.Space)) || (_controle.IsButtonDown(Buttons.A) && _controleanterior.IsButtonUp(Buttons.A)))
                {
                    //tiroSom.Play();
                    // COICE do tiro
                  // velocidade.X -= (float)Math.Cos(Math.PI * angulo / 180) * 0.3f;
                  // velocidade.Y -= (float)Math.Sin(Math.PI * angulo / 180) * 0.3f;
                    Shot.listaTiros.Add(new Shot(tipoTiro, posicao, gw, angulo, Content));
                }
                #endregion



                if (_teclado.IsKeyDown(Keys.Up) )
                {
                    posicao.Y -=1;
                }
                if (_teclado.IsKeyDown(Keys.Down))
                {
                    posicao.Y += 1;
                }
                if (_teclado.IsKeyDown(Keys.Left))
                {
                    posicao.X -= 1;
                }
                if (_teclado.IsKeyDown(Keys.Right))
                {
                    posicao.X += 1;
                }

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

            //posicao += velocidade;
            
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

            Shot.Update(_gameTime);

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

            Shot.Draw(gameTime, sb);
            

            //sb.Draw(textura, Vector2.Zero, Color.White);
        }

        public bool Colisao(Rectangle hit)
        {
            if (hitBox.Intersects(hit)) return true;
            return false;
        }

    }//fim classe
}//fim namespace
