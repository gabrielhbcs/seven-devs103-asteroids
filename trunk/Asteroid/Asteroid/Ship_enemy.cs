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
    /// Classe Nave do inimigo HERDANDO as características dos objetos que aparecem em cena
    /// </summary>
    class Nave_inimigo : Objeto
    {
        int inimigo;
        int tiros;

        //TiroFase2 tiro;
        //SoundEffect tiroSom;

        public Rectangle hitBox;

        bool atirando;

        double dx;
        double dy;
        int w;
        int _t;
        Random randomizador = new Random();

        public Nave_inimigo(
            int inimigo,
            Texture2D textura,
            Vector2 posicao,
            float angulo,
            GameWindow gw,
            int tiros,
            ContentManager Content)
            : base(
            textura,
            posicao,
            angulo,
            gw,
            Content)
        {
            this.inimigo = inimigo;
            atirando = false;
            this.tiros = tiros;

            this.w = randomizador.Next(30);

            hitBox = new Rectangle((int) posicao.X,(int) posicao.Y, textura.Width, textura.Height);

        }


        //novo construtor criado para receber velocidade angular _w do inimigo. com esse construtor os inimigos se movimentam na tela realizando orbitas.
        public Nave_inimigo(
            int inimigo,
            Texture2D textura,
            Vector2 posicao,
            float angulo,
            GameWindow gw,
            int tiros,
            ContentManager Content,
            int _w)
            : base(
            textura,
            posicao,
            angulo,
            gw,
            Content)
        {
            this.inimigo = inimigo;
            atirando = false;
            this.tiros = tiros;

            w = _w;

            //hitBox = new Rectangle((int)(posicao.X), ((int)posicao.Y), textura.Width, textura.Height);

        }

        public void Update(GameTime _gameTime)
        {
            // A nave inimiga começa com 15 tiros
            // A nave gira para a direção que está a nave do jogador e ATIRA
            // SE ACABAR A MUNIÇÃO
                // A nave gira para a direção que está a nave do jogador, e acelera (Tipo nave Kamikaze)

            angulo -= MathHelper.ToRadians(this.w);

            velocidade.X = (float)Math.Cos(Math.PI * angulo / 180) * 0.05f;
            velocidade.Y = (float)Math.Sin(Math.PI * angulo / 180) * 0.05f;

            dx = velocidade.X * _gameTime.ElapsedGameTime.Milliseconds;
            dy = velocidade.Y * _gameTime.ElapsedGameTime.Milliseconds;


            // ATIROU COICE do tiro
            //velocidade.X -= (float)Math.Cos(Math.PI * angulo / 180) * 0.3f;
            // velocidade.Y -= (float)Math.Sin(Math.PI * angulo / 180) * 0.3f;
                    //tiro = new TiroFase2(tipoTiro, posicao, janela, angulo, Content);
                    //atirando = true;

            //#region Verificar os limites de velocidade (Falta parametrizar)
            //if (velocidade.X > 4) { velocidade.X = 4; }
            //if (velocidade.Y > 4) { velocidade.Y = 4; }
            //if (velocidade.X < -4) { velocidade.X = -4; }
            //if (velocidade.Y < -4) { velocidade.Y = -4; }
            //#endregion

            //posicao. += velocidade;



            posicao.X +=(float) dx;
            posicao.Y +=(float) dy;


            hitBox.X = (int)(posicao.X - 15);
            hitBox.Y = (int)(posicao.Y - 22);


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
                //tiro.Update(_gameTime);
            }

        }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            //sb.Draw(texturaTeste, hitBox, Color.White);

            sb.Draw(
                textura,
                posicao,
                new Rectangle(0, 0, textura.Width, textura.Height),
                cor,
                MathHelper.ToRadians(angulo),
                new Vector2(textura.Width/2, textura.Height/2),
                1,
                SpriteEffects.None,
                0);

            //sb.Draw(textura, posicao, Color.White);
        }


    }//fim classe
}//fim namespace
