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
    /// Todos os objetos que aparecem na tela, sejam ele o jogador, naves inimigas
    /// ou asteróides
    /// Classe abstrata
    /// </summary>
    abstract class Objeto {
        
        /// <summary>
        /// Imagem
        /// </summary>
        protected Texture2D textura;

        /// <summary>
        /// 
        /// </summary>
        protected Vector2 posicao;

        /// <summary>
        /// 
        /// </summary>
        protected Vector2 velocidade;

        /// <summary>
        /// 
        /// </summary>
        protected Vector2 aceleracao;

        /// <summary>
        /// 
        /// </summary>
        protected float angulo;
        //visivel somente nas classes derivadas

        /// <summary>
        /// 
        /// </summary>
        protected Rectangle colisao;
        //padrão: só visível na própria classe

        //ruim: public pode ser alterado de qualquer lugar/instância

        /// <summary>
        /// 
        /// </summary>
        protected Color cor;

        /// <summary>
        /// 
        /// </summary>
        protected GameWindow gw;
        
        public Objeto(
            Texture2D _desenho,
            Vector2 _posicao,
            float _angulo,
            GameWindow gw)
        {
            textura = _desenho;
            posicao = _posicao;
            angulo = _angulo;
            velocidade = Vector2.Zero;
            this.gw = gw;
            this.cor = Color.White;
        }


        

    }
}
