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
    /// Carlos Moffatt
    /// </summary>

    class NaveFase2
    {
        #region atributos
        Texture2D desenhoNave;
        Vector2 posicao;
        Vector2 velocidade;
        Vector2 aceleracao;
        float angulo;
        Rectangle colisao;
        int vidas;
        int pontos;
        int jogador;
        String nomeJogador;
        Color cor;
        GameWindow janela;
        TiroFase2 tiro;
        String tipoTiro;
        //SoundEffect tiroSom;
        bool atirando;
        ContentManager Content;
        Vector2 tamanhoStage;
        #endregion

        public NaveFase2(int _jogador, Texture2D _desenho, Vector2 _posicao, Color _cor, float _angulo, string _nomeJogador, int _vidas, int _pontos, ContentManager _content, Vector2 _tamanhoStage)
        {
            jogador = _jogador;
            desenhoNave = _desenho;
            posicao = _posicao;
            cor = _cor;
            angulo = _angulo;
            nomeJogador = _nomeJogador;
            vidas = _vidas;
            pontos = _pontos;
            velocidade = Vector2.Zero;
            tipoTiro = "plasma";
            //tiroSom = _tirosom;
            atirando = false;
            Content = _content;
            tamanhoStage = _tamanhoStage;
        }

        public void Update(GameTime _gameTime, KeyboardState _teclado, KeyboardState _tecladoAnterior) {
            if (jogador == 1) {
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
                    tiro = new TiroFase2(tipoTiro, posicao, janela, angulo, Content);
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
                posicao.X = tamanhoStage.X;
            }
            else if (posicao.X > tamanhoStage.X)
            {
                posicao.X = 0;
            }

            if (posicao.Y < 0)
            {
                posicao.Y = tamanhoStage.Y;
            }
            else if (posicao.Y > tamanhoStage.Y)
            {
                posicao.Y = 0;
            }
            #endregion

            if (atirando) {
                tiro.Update(_gameTime);
            }

        }

        public void Draw(GameTime gameTime, SpriteBatch sb) {
            if (atirando) {
                tiro.Draw(gameTime, sb);
            }
            sb.Draw(desenhoNave, posicao, new Rectangle(0, 0, desenhoNave.Width, desenhoNave.Height), cor, MathHelper.ToRadians(angulo), new Vector2(desenhoNave.Width / 2, desenhoNave.Height / 2), 1, SpriteEffects.None, 0);
        }

    }
}
