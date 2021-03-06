﻿using System;
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
        new static Comecar comecar;

        Vector2 posControles;
        new static Controles_Botao controles;

        Vector2 posCreditos;
        new static menuCredito creditos;

        Vector2 posStatus;
        new static menuStatus status;

        new static Sair sair;
        Vector2 posSair;

        Texture2D fundo;

        int cont_tecla;
        int max = 10;

        GameWindow gw;

        public MenuInicial(ContentManager Content, GameWindow gw)
        {
            this.gw = gw;

            cont = 1;

            fundo = Content.Load<Texture2D>("Estados/Menu/tela_inicial");

            posComecar.X = 50;
            posComecar.Y = gw.ClientBounds.Height / 6;

            posControles.X = 50;
            posControles.Y = 2 * gw.ClientBounds.Height / 6;

            posCreditos.X = 50;
            posCreditos.Y = 3 * gw.ClientBounds.Height / 6;

            posStatus.X = 50;
            posStatus.Y = 4 * gw.ClientBounds.Height / 6;

            posSair.X = 50;
            posSair.Y = 5 * gw.ClientBounds.Height / 6;
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
            comecar = new Comecar(Content, cont, posComecar);
            controles = new Controles_Botao(Content, cont, posControles);
            creditos = new menuCredito(Content, cont, posCreditos);
            status = new menuStatus(Content, cont, posStatus);
            sair = new Sair(Content, cont, posSair);
            #endregion
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                fundo,
                new Rectangle(0, 0, gw.ClientBounds.Width,
                gw.ClientBounds.Height),
                Color.White);

            comecar.Draw(gameTime, spriteBatch);
            sair.Draw(gameTime, spriteBatch);
            controles.Draw(gameTime, spriteBatch);
            creditos.Draw(gameTime, spriteBatch);
            status.Draw(gameTime, spriteBatch);
        }
    }
}
