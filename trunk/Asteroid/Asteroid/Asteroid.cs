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
    /// Classe para criar as pedras que giram pelo espaço
    /// herda de objeto
    /// </summary>
    class Asteroide : Objeto
    {
        static List<Asteroide> lista = new List<Asteroide>();

        new static Texture2D textura;

        const int fps = 12;
        const int frame_x = 128;
        const int frame_y = 128;
        const int qtd_frames = 8;

        static int timetorespawn = 0;

        Random random = new Random();
        
        /// <summary>
        /// Construtor padrão passando os parâmetros para a classe Objeto
        /// </summary>
        /// <param name="textura">uma imagem com os frames</param>
        /// <param name="posicao">cada asteroide tem sua posicao</param>
        /// <param name="angulo">cada asteroide tem seu angulo - nao vamos usar</param>
        /// <param name="gw">informações sobre o tamanho da janela</param>
        /// <param name="Content">para carregar conteúdo</param>
        public Asteroide(
            Texture2D textura,
            Vector2 posicao,
            float angulo,
            GameWindow gw,
            ContentManager Content)
            :base (textura, posicao, angulo, gw, Content)
        {
            Asteroide.textura = textura;
            this.posicao = posicao;
            this.angulo = angulo;
            this.gw = gw;
            this.Content = Content;
            
            velocidade = new Vector2(1, 1);//sortear

            //assim que todo asteróide é criado ele é adicionado à lista de asteróides
            Asteroide.lista.Add(this);
        }

        public Asteroide(Vector2 posicao)
        {
            this.posicao = posicao;

            this.velocidade = new Vector2(
                (float)random.Next(-2, 3),
                (float)random.Next(-2, 3));

           if (this.velocidade.X == 0) { this.velocidade.X++; }
           if (this.velocidade.Y == 0) { this.velocidade.Y++; }

            Asteroide.lista.Add(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gt"></param>
        public void Update(GameTime gt)
        {
            #region Lógica para fazer aparecer os asteróides

            //aparece um a cada par de segundo
            Asteroide.timetorespawn += (int)gt.ElapsedGameTime.Milliseconds;

            Console.WriteLine(Asteroide.timetorespawn);

            if (Asteroide.timetorespawn > 2000)
            {
                Asteroide.lista.Add(new Asteroide(new Vector2(
                    (float)random.Next(gw.ClientBounds.Width),
                    (float)random.Next(gw.ClientBounds.Height))));

                //Asteroide a = new Asteroide(new Vector2(100, 110));

                Asteroide.timetorespawn = 0;
            }

            #endregion
            //o Update é chamado uma vez só para a classe e atualiza todos os objetos da lista
            for (int i = 0; i < Asteroide.lista.Count; i++)
            {
                lista[i].posicao += lista[i].velocidade;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gt"></param>
        /// <param name="sb"></param>
        public void Draw(GameTime gt, SpriteBatch sb)
        {
            int frame = (int)(gt.TotalGameTime.TotalSeconds * 12) % 8;
            //o Draw é chamado uma vez só para a classe e desenha todos os objetos da lista
            for (int i = 0; i < lista.Count; i++)
            {
                sb.Draw(Asteroide.textura, lista[i].posicao, new Rectangle(frame * 128, 0, 128, 128), Color.White);
            }
        }

    }
}
