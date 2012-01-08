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
    class Status
    {
        int pontos = 10;
        int VelCurva = 0;
        int Veltiro = 0;
        int Velnave = 0;

        int cont_tecla;
        int max = 15;
        int cont = 0;

        btnVelNave addVelNave;
        Vector2 posVelNave;

        btnVelTiro addVelTiro;
        Vector2 posVelTiro;

        btnVelCurva addVelCurva;
        Vector2 posVelCurva;

        btnReset resetar;
        Vector2 posResetar;

        ContentManager content;

        public Status(ContentManager Content)
        {
            this.content = Content;

            posVelNave.X = 500;
            posVelNave.Y = 115;

            posVelTiro.X = 500;
            posVelTiro.Y = 165;

            posVelCurva.X = 500;
            posVelCurva.Y = 215;

            posResetar.X = 500;
            posResetar.Y = 290;
        }
        public void Update(GameTime time, KeyboardState teclado, KeyboardState tecladoanterior, GamePadState controle)
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
            if (cont > 4) cont = 1;
            if (cont < 1) cont = 4;
            #endregion
            #region Botões
            if (cont == 1)
            {
                addVelNave = new btnVelNave(content, cont, posVelNave);
                addVelTiro = new btnVelTiro(content, cont, posVelTiro);
                addVelCurva = new btnVelCurva(content, cont, posVelCurva);
                resetar = new btnReset(content, cont, posResetar);
            }
            if (cont == 2)
            {
                addVelNave = new btnVelNave(content, cont, posVelNave);
                addVelTiro = new btnVelTiro(content, cont, posVelTiro);
                addVelCurva = new btnVelCurva(content, cont, posVelCurva);
                resetar = new btnReset(content, cont, posResetar);
            }
            if (cont == 3)
            {
                addVelNave = new btnVelNave(content, cont, posVelNave);
                addVelTiro = new btnVelTiro(content, cont, posVelTiro);
                addVelCurva = new btnVelCurva(content, cont, posVelCurva);
                resetar = new btnReset(content, cont, posResetar);
            }
            if (cont == 4)
            {
                addVelNave = new btnVelNave(content, cont, posVelNave);
                addVelTiro = new btnVelTiro(content, cont, posVelTiro);
                addVelCurva = new btnVelCurva(content, cont, posVelCurva);
                resetar = new btnReset(content, cont, posResetar);
            }
            #endregion
            #region escolher botão
            if (cont == 1 && (controle.IsButtonDown(Buttons.A) || teclado.IsKeyDown(Keys.Enter)) && pontos > 0 && cont_tecla == max)
            {
                Velnave += 1;
                pontos -= 1;
                cont_tecla = 0;
            }
            if (cont == 2 && (controle.IsButtonDown(Buttons.A) || teclado.IsKeyDown(Keys.Enter)) && pontos > 0 && cont_tecla == max)
            {
                Veltiro += 1;
                pontos -= 1;
                cont_tecla = 0;
            }
            if (cont == 3 && (controle.IsButtonDown(Buttons.A) || teclado.IsKeyDown(Keys.Enter)) && pontos > 0 && cont_tecla == max)
            {
                VelCurva += 1;
                pontos -= 1;
                cont_tecla = 0;
            }
            if (cont == 4 && (controle.IsButtonDown(Buttons.A) || teclado.IsKeyDown(Keys.Enter)) && cont_tecla == max)
            {
                Velnave = 0;
                Veltiro = 0;
                VelCurva = 0;
                pontos = 10;
                cont_tecla = 0;
            }
            #endregion


        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(fundo, new Rectangle(0, 0, 800, 480), Color.White);
            if (cont != 0)
            {
            addVelNave.Draw(gameTime, spriteBatch);
            addVelTiro.Draw(gameTime, spriteBatch);
            addVelCurva.Draw(gameTime, spriteBatch);
            resetar.Draw(gameTime, spriteBatch);
            }
            spriteBatch.DrawString(Game1.fonte, "Pontos restantes: " + pontos, new Vector2(50f), Color.White);
            spriteBatch.DrawString(Game1.fonte, "Velocidade da nave: " + Velnave, new Vector2(100, 125), Color.White);
            spriteBatch.DrawString(Game1.fonte, "Velocidade do tiro: " + Veltiro, new Vector2(100, 175), Color.White);
            spriteBatch.DrawString(Game1.fonte, "Velocidade da curva: " + VelCurva, new Vector2(100, 225), Color.White);
            spriteBatch.DrawString(Game1.fonte, "Resetar ", new Vector2(100, 300), Color.White);
            spriteBatch.DrawString(Game1.fonte, "Aperte ESC para voltar ao menu", new Vector2(10, 450), Color.White);

        }
    }
}
