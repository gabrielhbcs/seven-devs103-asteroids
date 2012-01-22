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

        //Variáveis do escudo e barra
        public bool _escudo = false;
        Texture2D texturaEscudo;
        Texture2D texturaBarra;
        int cont_escudo; // ter um limite de tempo entre cada ativação do escudo
        int cont_max = 20;
        Barra barra;
        Escudo escudo;

        /// <summary>
        /// qtd de vidas do jogador
        /// </summary>
        public static int vidas;

        /// <summary>
        /// qtd de pontos do jogador
        /// </summary>
        public static int pontos;

        public Rectangle hitBox;

        public Nave_jogador(
            int jogador,
            Texture2D textura,
            Vector2 posicao,
            float angulo,
            GameWindow gw,
            ContentManager Content
        ) : base(
            textura,
            posicao,
            angulo,
            gw,
            Content)
        {
            texturaBarra = Content.Load<Texture2D>("Barra");
            texturaEscudo = Content.Load<Texture2D>("Escudo");
            barra = new Barra(texturaBarra);
            escudo = new Escudo(texturaEscudo);

            this.jogador = jogador;
            Nave_jogador.vidas = 7;
            Nave_jogador.pontos = 0;
            hitBox = new Rectangle((int)posicao.X, (int)posicao.Y, textura.Width, textura.Height);
        }


        public void Update(GameTime _gameTime, KeyboardState _teclado, KeyboardState _tecladoAnterior, GamePadState _controle, GamePadState _controleanterior)
        {
            if (isGameOver())
            {
                doGameOver();
            }

            if (jogador == 1)
            {
                movePlayerOne(ref _teclado, ref _tecladoAnterior, ref _controle, ref _controleanterior);
            }

            #region Criar escudo
            cont_escudo++;
            if (cont_escudo >= cont_max) cont_escudo = cont_max;
            barra.Update(_escudo);
            if (_teclado.IsKeyDown(Keys.E) && cont_escudo == cont_max)
            {
                if (!_escudo)
                {
                    _escudo = true;
                }
                else
                {
                    _escudo = false;
                }
                cont_escudo = 0;
            }
            if (!barra.permicao) _escudo = false;
            if (_escudo) escudo.Update(posicao);
            #endregion

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

            #region Verificar os limites de velocidade
            int maxSpeed = Status.VelNave * 4;
            if (isMaxSpeed(maxSpeed)) { velocidade.X = maxSpeed; }
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

            if (_escudo)
            {
                escudo.Draw(gameTime, sb);
            }
            barra.Draw(gameTime, sb);

        }

        private bool isMaxSpeed(int velocidadeMaxima)
        {
            return velocidade.X >= velocidadeMaxima || velocidade.X <= -velocidadeMaxima;
        }

        private void movePlayerOne(ref KeyboardState _teclado, ref KeyboardState _tecladoAnterior, ref GamePadState _controle, ref GamePadState _controleanterior)
        {
            #region ESQUERDA
            if (leftButtonWasPressed(ref _teclado, ref _controle))
            {
                angulo -= Status.VelCurva;
            }
            #endregion

            #region DIREITA
            if (rightButtonWasPressed(ref _teclado, ref _controle))
            {
                angulo += Status.VelCurva;
            }
            #endregion

            #region CIMA (Acelera)
            if (upButtonWasPressed(ref _teclado, ref _controle))
            {
                velocidade.X += (float)Math.Cos(Math.PI * angulo / 180) * 0.05f;
                velocidade.Y += (float)Math.Sin(Math.PI * angulo / 180) * 0.05f;
            }
            #endregion

            #region SPACE (Atira)
            if ((_teclado.IsKeyDown(Keys.Space) && _tecladoAnterior.IsKeyUp(Keys.Space)) || (_controle.IsButtonDown(Buttons.A) && _controleanterior.IsButtonUp(Buttons.A)))
            {
                shot();
            }
            #endregion

            hitBox.X = (int)posicao.X;
            hitBox.Y = (int)posicao.Y;
        }

        private void shot()
        {
            velocidade.X -= (float)Math.Cos(Math.PI * angulo / 180) * 0.3f;
            velocidade.Y -= (float)Math.Sin(Math.PI * angulo / 180) * 0.3f;
            Shot.listaTiros.Add(new Shot(posicao, gw, angulo, Content));
        }

        private static bool upButtonWasPressed(ref KeyboardState _teclado, ref GamePadState _controle)
        {
            return _teclado.IsKeyDown(Keys.W) || _controle.IsButtonDown(Buttons.DPadUp) || _controle.IsButtonDown(Buttons.LeftThumbstickUp);
        }

        private static bool rightButtonWasPressed(ref KeyboardState _teclado, ref GamePadState _controle)
        {
            return _teclado.IsKeyDown(Keys.D) || _controle.IsButtonDown(Buttons.DPadRight) || _controle.IsButtonDown(Buttons.LeftThumbstickRight);
        }

        private static bool leftButtonWasPressed(ref KeyboardState _teclado, ref GamePadState _controle)
        {
            return _teclado.IsKeyDown(Keys.A) || _controle.IsButtonDown(Buttons.DPadLeft) || _controle.IsButtonDown(Buttons.LeftThumbstickLeft);
        }

        private static void looseLife()
        {
            vidas--;
        }

        private static void doGameOver()
        {
            Game1.estadoAtual = Game1.estados.GAME_OVER;
        }

        public bool Colisao(Rectangle hit)
        {
            if (hitBox.Intersects(hit)) return true;
            return false;
        }

        public bool isGameOver()
        {
            return (vidas == 0);
        }

      
    }//fim classe
}//fim namespace
