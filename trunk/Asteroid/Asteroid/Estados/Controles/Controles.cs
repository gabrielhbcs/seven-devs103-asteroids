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
    class Controles
    {
        Texture2D fundo;
        int cont = 0;

        btnSelect selTeclado;
        Vector2 posTeclado;

        btnSelect selGamepad;
        Vector2 posGamepad;

        ContentManager conteudo;

        int cont_tecla = 0;
        int max = 20;

        public Controles(ContentManager _content)
        {
            this.conteudo = _content;
            fundo = conteudo.Load<Texture2D>("Estados/Controles/controles");

            posTeclado.X = 40;
            posTeclado.Y = 105;

            posGamepad.X = 445;
            posGamepad.Y = 105;

            selTeclado = new btnSelect(conteudo, 1, posTeclado);
            selGamepad = new btnSelect(conteudo, 2, posGamepad);

            if (Game1.controleAtual == Game1.dispositivos_controle.TECLADO) {cont=1;}
            if (Game1.controleAtual == Game1.dispositivos_controle.JOYSTICK) {cont=2;}
        }

        public void Update(GameTime time, KeyboardState teclado, KeyboardState tecladoanterior, GamePadState controle)
        {
            cont_tecla++;
            if (cont_tecla >= max) cont_tecla = max;

            if ((teclado.IsKeyDown(Keys.D) || teclado.IsKeyDown(Keys.Right) || controle.IsButtonDown(Buttons.DPadRight) || controle.IsButtonDown(Buttons.LeftThumbstickRight)) && cont_tecla==max)
            {
                cont++;
                cont_tecla = 0;
            }
            if ((teclado.IsKeyDown(Keys.A) || teclado.IsKeyDown(Keys.Left) || controle.IsButtonDown(Buttons.DPadLeft) || controle.IsButtonDown(Buttons.LeftThumbstickLeft)) && cont_tecla == max)
            {
                cont--;
                cont_tecla = 0;
            }

            if (cont > 2) cont = 1;
            if (cont < 1) cont = 2;
            if (cont == 1) { Game1.controleAtual = Game1.dispositivos_controle.TECLADO; }
            if (cont == 2) { Game1.controleAtual = Game1.dispositivos_controle.JOYSTICK; }

            selTeclado.Update(time, cont, conteudo);
            selGamepad.Update(time, cont, conteudo);
        }

        public void Draw(
            GameTime gameTime,
            SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                fundo,
                new Rectangle(0, 0, 800, 480),
                Color.White);
            selTeclado.Draw(gameTime, spriteBatch);
            selGamepad.Draw(gameTime, spriteBatch);
        }
    }

}
