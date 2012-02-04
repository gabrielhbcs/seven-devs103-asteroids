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

        //protected = visivel somente na classe e nas classes derivadas

        //padrão: private = só visível na própria classe

        //ruim: public = pode ser visto e alterado de qualquer lugar/instância

        /// <summary>
        /// Imagem do objeto
        /// </summary>
        protected Texture2D textura;

        /// <summary>
        /// Posição que a imagem do objeto ocupa na tela
        /// </summary>
        protected Vector2 posicao;

        /// <summary>
        /// Velocidade (módulo) que a imagem do objeto se locomove pela tela
        /// </summary> 
        protected Vector2 velocidade;
        
        /// <summary>
        /// Angulo qua a imagem do objeto está rotacionada a tela
        /// </summary>
        protected float angulo;
        
        /// <summary>
        /// Cor de camada
        /// </summary>
        protected Color cor;

        /// <summary>
        /// Recebe informações sobre o tamanho da janela
        /// </summary>
        protected GameWindow gw;

        /// <summary>
        /// Recebe o objeto do XNA capaz de carregar conteúdo
        /// </summary>
        protected ContentManager Content;

        public Objeto(
            Texture2D textura,
            Vector2 posicao,
            float angulo,
            GameWindow gw,
            ContentManager Content)
        {
            this.textura = textura;
            this.posicao = posicao;
            this.angulo = angulo;
            this.velocidade = Vector2.Zero;
            this.gw = gw;
            this.cor = Color.White;
            this.Content = Content;
        }

        public Objeto()
        {

        }
    }
}
