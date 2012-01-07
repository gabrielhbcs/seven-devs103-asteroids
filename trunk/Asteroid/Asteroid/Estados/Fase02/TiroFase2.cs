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

namespace Asteroid {
    class TiroFase2 {
        #region atributos
        static Texture2D textura;
        Vector2 posicao;
        Vector2 velocidade;
        float angulo;
        Rectangle colisao;
        int dano;
        GameWindow janela;
        bool visivel; //ativo
        String tipo;
        ContentManager Content;
        #endregion

        public TiroFase2(String _tipo, Vector2 _posicao, GameWindow _janela, float _angulo, ContentManager _content)
        {
            Console.WriteLine("TIroFase2");
            janela = _janela;
            angulo = _angulo;
            tipo = _tipo;
            velocidade = Vector2.Zero;
            posicao = _posicao;
            posicao.X = _posicao.X + ((float)Math.Cos(Math.PI * angulo / 180) * 30);
            posicao.Y = _posicao.Y + ((float)Math.Sin(Math.PI * angulo / 180) * 30);
            Content = _content;
            textura = Content.Load<Texture2D>("Estados/Fase02/tiroFase2");
            //TODO tirar este load daqui
            //TODO fazer uma Lista de tiros
        }

        public void Update(GameTime _gameTime) {
            this.velocidade.X = (float)Math.Cos(Math.PI * angulo / 180) * 10;
            this.velocidade.Y = (float)Math.Sin(Math.PI * angulo / 180) * 10;
            posicao += velocidade;
        }

        public void Draw(GameTime gameTime, SpriteBatch sb) {
            //if (tipo == "plasma") {
            
            Console.WriteLine("Desenhando");
            sb.Draw(textura, posicao, new Rectangle(0, 0, textura.Width, textura.Height), Color.White, MathHelper.ToRadians(angulo), new Vector2(textura.Width / 2, textura.Height / 2), 1, SpriteEffects.None, 0);
            
            //}
        }

    }
}
