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
    class Shot
    {
        #region atributos
        static Texture2D textura;
        Vector2 posicao;
        Vector2 velocidade;
        float angulo;
        Rectangle hitBox;
        GameWindow janela;
        String tipo;
        ContentManager Content;
        public static List<Shot> listaTiros = new List<Shot>();

        #endregion

        public Shot(Vector2 _posicao, GameWindow _janela, float _angulo, ContentManager _content)
        {
            janela = _janela;
            angulo = _angulo;
            velocidade = Vector2.Zero;
            posicao = _posicao;
            posicao.X = _posicao.X + ((float)Math.Cos(Math.PI * angulo / 180) * 30);
            posicao.Y = _posicao.Y + ((float)Math.Sin(Math.PI * angulo / 180) * 30);
            Content = _content;
            textura = Content.Load<Texture2D>("Estados/Fase02/tiroFase2");
            hitBox = new Rectangle((int)posicao.X, (int) posicao.Y, textura.Width, textura.Height);
        }

        public static void Update(GameTime _gameTime) 
        {
            for (int i = 0; i< listaTiros.Count; i++)
            {
                listaTiros[i].velocidade.X = (float)Math.Cos(Math.PI * listaTiros[i].angulo / 180) * Status.VelTiro;
                listaTiros[i].velocidade.Y = (float)Math.Sin(Math.PI * listaTiros[i].angulo / 180) * Status.VelTiro;
                listaTiros[i].posicao += listaTiros[i].velocidade;

                listaTiros[i].hitBox.X = (int) listaTiros[i].posicao.X;
                listaTiros[i].hitBox.Y = (int) listaTiros[i].posicao.Y;

                if (listaTiros[i].posicao.X > listaTiros[i].janela.ClientBounds.Width)
                {
                    listaTiros.RemoveAt(i);
                }
                else if (listaTiros[i].posicao.X < 0)
                {
                    listaTiros.RemoveAt(i);
                } else if (listaTiros[i].posicao.Y > listaTiros[i].janela.ClientBounds.Height)
                {
                    listaTiros.RemoveAt(i);
                }
                else if (listaTiros[i].posicao.Y < 0)
                {
                    listaTiros.RemoveAt(i);
                }
            }
		}
         
        //TODO Colisão com o inimigo
        public bool Colisao(Rectangle hit)
        {
            if (hitBox.Intersects(hit)) return true;
            return false;
        }

        public static void Draw(GameTime gameTime, SpriteBatch sb)
        {
            //sb.Draw(textura, posicao, new Rectangle(0, 0, textura.Width, textura.Height), Color.White, MathHelper.ToRadians(angulo), new Vector2(textura.Width / 2, textura.Height / 2), 1, SpriteEffects.None, 0);

            foreach (Shot tiro in Shot.listaTiros)
            {
                sb.Draw(textura, tiro.posicao, new Rectangle(0, 0, textura.Width, textura.Height), Color.White, MathHelper.ToRadians(tiro.angulo), new Vector2(textura.Width / 2, textura.Height / 2), 1, SpriteEffects.None, 0);
            }
        }

        public void Remove()
        {
            
        }

    }
}
