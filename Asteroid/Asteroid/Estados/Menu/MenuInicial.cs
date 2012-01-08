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
        Controles_Botao controles;

        Vector2 posCreditos;
        menuCredito creditos;

        Vector2 posStatus;
        menuStatus status;
        
        Sair sair;
        Vector2 posSair;

        int cont_tecla;
        int max = 10;

        public MenuInicial(ContentManager Content, GameWindow Window)
        {
            posComecar.X = 100;
            posComecar.Y = Window.ClientBounds.Height / 6;
            comecar = new Comecar(Content, cont, posComecar);

            posControles.X = 100;
            posControles.Y = 2 * Window.ClientBounds.Height / 6;
            controles = new Controles_Botao(Content, cont, posControles);

            posCreditos.X = 100;
            posCreditos.Y = 3 * Window.ClientBounds.Height / 6;
            creditos = new menuCredito(Content, cont, posCreditos);

            posStatus.X = 100;
            posStatus.Y = 4 * Window.ClientBounds.Height / 6;

            posSair.X = 100;
            posSair.Y = 5 * Window.ClientBounds.Height / 6;
            sair = new Sair(Content, cont, posSair);
        }
        public void Update(GameTime time, KeyboardState teclado, GamePadState controle, ContentManager Content)
        {
            cont_tecla++;
            if (cont_tecla >= max) cont_tecla = max;

            #region Escolha botão
            if ((teclado.IsKeyDown(Keys.S) || teclado.IsKeyDown(Keys.Down) || controle.IsButtonDown(Buttons.DPadDown) || controle.IsButtonDown(Buttons.LeftThumbstickDown)) && cont_tecla == max)
            {
                cont++;
                cont_tecla = 0;
            }
            if ((teclado.IsKeyDown(Keys.W) || teclado.IsKeyDown(Keys.Up) || controle.IsButtonDown(Buttons.DPadUp) || controle.IsButtonDown(Buttons.LeftThumbstickUp)) && cont_tecla == max)
            {
                cont--;
                cont_tecla = 0;
            }
            if (cont > 5) cont = 1;
            if (cont < 1) cont = 5;
            #endregion
            #region Seleção dos botões
            if (cont == 1)
            {
                comecar = new Comecar(Content, cont, posComecar);
                sair = new Sair(Content, cont, posSair);
                controles = new Controles_Botao(Content, cont, posControles);
                creditos = new menuCredito(Content, cont, posCreditos);
                status = new menuStatus(Content, cont, posStatus);
            }
            if (cont == 2)
            {
                comecar = new Comecar(Content, cont, posComecar);
                sair = new Sair(Content, cont, posSair);
                controles = new Controles_Botao(Content, cont, posControles);
                creditos = new menuCredito(Content, cont, posCreditos);
                status = new menuStatus(Content, cont, posStatus);
            }
            if (cont == 3)
            {
                comecar = new Comecar(Content, cont, posComecar);
                sair = new Sair(Content, cont, posSair);
                controles = new Controles_Botao(Content, cont, posControles);
                creditos = new menuCredito(Content, cont, posCreditos);
                status = new menuStatus(Content, cont, posStatus);
            }
            if (cont == 4)
            {
                comecar = new Comecar(Content, cont, posComecar);
                sair = new Sair(Content, cont, posSair);
                controles = new Controles_Botao(Content, cont, posControles);
                creditos = new menuCredito(Content, cont, posCreditos);
                status = new menuStatus(Content, cont, posStatus);
            }
            if (cont == 5)
            {
                comecar = new Comecar(Content, cont, posComecar);
                sair = new Sair(Content, cont, posSair);
                controles = new Controles_Botao(Content, cont, posControles);
                creditos = new menuCredito(Content, cont, posCreditos);
                status = new menuStatus(Content, cont, posStatus);
            }
            #endregion
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            comecar.Draw(gameTime, spriteBatch);
            sair.Draw(gameTime, spriteBatch);
            controles.Draw(gameTime, spriteBatch);
            creditos.Draw(gameTime, spriteBatch);
            status.Draw(gameTime, spriteBatch);
        }
    }
}
