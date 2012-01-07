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
    class MenuInicial
    {
        public int cont = 1;
        Vector2 posComecar;
        Comecar comecar;

        Vector2 posControles;
        Controles controles;

        Vector2 posCreditos;
        menuCredito creditos;
        
        Sair sair;
        Vector2 posSair;

        int cont_tecla;
        int max = 20;

        public MenuInicial(ContentManager Content, GameWindow Window)
        {
            posComecar.X = 100;
            posComecar.Y = Window.ClientBounds.Height / 5;
            comecar = new Comecar(Content, cont, posComecar);

            posControles.X = 100;
            posControles.Y = 2 * Window.ClientBounds.Height / 5;
            controles = new Controles(Content, cont, posControles);

            posCreditos.X = 100;
            posCreditos.Y = 3 * Window.ClientBounds.Height / 5;
            creditos = new menuCredito(Content, cont, posCreditos);

            posSair.X = 100;
            posSair.Y = 4 * Window.ClientBounds.Height / 5;
            sair = new Sair(Content, cont, posSair);
        }
        public void Update(GameTime time, KeyboardState teclado, ContentManager Content)
        {
            cont_tecla++;
            if (cont_tecla >= max) cont_tecla = max;

            #region Escolha botão
            if ((teclado.IsKeyDown(Keys.S) || teclado.IsKeyDown(Keys.Down)) && cont_tecla == max)
            {
                cont++;
                cont_tecla = 0;
            }
            if ((teclado.IsKeyDown(Keys.W) || teclado.IsKeyDown(Keys.Up)) && cont_tecla == max)
            {
                cont--;
                cont_tecla = 0;
            }
            if (cont > 4) cont = 1;
            if (cont < 1) cont = 4;
            #endregion
            #region Seleção dos botões
            if (cont == 1)
            {
                comecar = new Comecar(Content, cont, posComecar);
                sair = new Sair(Content, cont, posSair);
                controles = new Controles(Content, cont, posControles);
                creditos = new menuCredito(Content, cont, posCreditos);
            }
            if (cont == 2)
            {
                comecar = new Comecar(Content, cont, posComecar);
                sair = new Sair(Content, cont, posSair);
                controles = new Controles(Content, cont, posControles);
                creditos = new menuCredito(Content, cont, posCreditos);
            }
            if (cont == 3)
            {
                comecar = new Comecar(Content, cont, posComecar);
                sair = new Sair(Content, cont, posSair);
                controles = new Controles(Content, cont, posControles);
                creditos = new menuCredito(Content, cont, posCreditos);
            }
            if (cont == 4)
            {
                comecar = new Comecar(Content, cont, posComecar);
                sair = new Sair(Content, cont, posSair);
                controles = new Controles(Content, cont, posControles);
                creditos = new menuCredito(Content, cont, posCreditos);
            }
            #endregion
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            comecar.Draw(gameTime, spriteBatch);
            sair.Draw(gameTime, spriteBatch);
            controles.Draw(gameTime, spriteBatch);
            creditos.Draw(gameTime, spriteBatch);
        }
    }
}
