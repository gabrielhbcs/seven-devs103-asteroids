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
    class Status {
        int pontos = 0;
        public static int VelCurva = 3;
        public static int VelTiro = 4;
        public static int VelNave = 3;

        btnSelect addVelNave;
        Vector2 posVelNave;

        btnSelect addVelTiro;
        Vector2 posVelTiro;

        btnSelect addVelCurva;
        Vector2 posVelCurva;

        btnSelect resetar;
        Vector2 posResetar;

        Texture2D fundo;
        int cont = 1;

        int cont_tecla = 0;
        int max = 15;

        ContentManager conteudo;

        GameWindow gw;

        enum opcao_status { VELNAVE, VELTIRO, VELCURVA, RESETAR };
        opcao_status statusAtual = opcao_status.VELNAVE;

        public Status(ContentManager Content, GameWindow gw)
        {
            this.gw = gw;

            this.conteudo = Content;
            fundo = conteudo.Load<Texture2D>("Estados/Status/status_fundo");

            posVelNave.X = 500;
            posVelNave.Y = 115;

            posVelTiro.X = 500;
            posVelTiro.Y = 165;

            posVelCurva.X = 500;
            posVelCurva.Y = 215;

            posResetar.X = 500;
            posResetar.Y = 340;

            addVelNave = new btnSelect(conteudo, 1, posVelNave);
            addVelTiro = new btnSelect(conteudo, 2, posVelTiro);
            addVelCurva = new btnSelect(conteudo, 3, posVelCurva);
            resetar = new btnSelect(conteudo, 4, posResetar);
        }

        public void Update(GameTime time, KeyboardState teclado, KeyboardState tecladoanterior, GamePadState controle, GamePadState controleAnterior)
        {
            cont_tecla++;
            if (cont_tecla >= max) cont_tecla = max;

            if ((teclado.IsKeyDown(Keys.S) || teclado.IsKeyDown(Keys.Down) || controle.IsButtonDown(Buttons.DPadDown) || controle.IsButtonDown(Buttons.LeftThumbstickDown)) && cont_tecla==max)
            {
                cont++;
                cont_tecla = 0;
            }
            if ((teclado.IsKeyDown(Keys.W) || teclado.IsKeyDown(Keys.Up) || controle.IsButtonDown(Buttons.DPadUp) || controle.IsButtonDown(Buttons.LeftThumbstickUp)) && cont_tecla==max)
            {
                cont--;
                cont_tecla = 0;
            }

            if (cont > 4) cont = 1;
            if (cont < 1) cont = 4;

            switch (cont)
            {
                case 1:
                    statusAtual = opcao_status.VELNAVE;
                    break;
                case 2:
                    statusAtual = opcao_status.VELTIRO;
                    break;
                case 3:
                    statusAtual = opcao_status.VELCURVA;
                    break;
                case 4:
                    statusAtual = opcao_status.RESETAR;
                    break;
            }

            #region escolher botão
            if (((teclado.IsKeyDown(Keys.Enter) && tecladoanterior.IsKeyUp(Keys.Enter)) || (controle.IsButtonDown(Buttons.A) && controleAnterior.IsButtonUp(Buttons.A))) && pontos>0)
            {
                switch (statusAtual)
                {
                    case opcao_status.VELNAVE:
                        VelNave ++;
                        pontos--;
                        break;
                    case opcao_status.VELTIRO:
                        VelTiro ++;
                        pontos--;
                        break;
                    case opcao_status.VELCURVA:
                        VelCurva ++;
                        pontos--;
                        break;
                }
            }

            if (((teclado.IsKeyDown(Keys.Enter) && tecladoanterior.IsKeyUp(Keys.Enter)) || controle.IsButtonDown(Buttons.A)) && statusAtual==opcao_status.RESETAR)
            {
                VelNave = 1;
                VelTiro = 1;
                VelCurva = 1;
                pontos = 7;
            }

            #endregion

            addVelNave.Update(time, cont, conteudo);
            addVelTiro.Update(time, cont, conteudo);
            addVelCurva.Update(time, cont, conteudo);
            resetar.Update(time, cont, conteudo);

        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(fundo, new Rectangle(0, 0, gw.ClientBounds.Width,
                gw.ClientBounds.Height), Color.White);
            addVelNave.Draw(gameTime, spriteBatch);
            addVelTiro.Draw(gameTime, spriteBatch);
            addVelCurva.Draw(gameTime, spriteBatch);
            resetar.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(Game1.fonte, "Pontos restantes: " + pontos, new Vector2(100,100), Color.White);
            spriteBatch.DrawString(Game1.fonte, "Velocidade da nave: " + VelNave, new Vector2(100, 130), Color.White);
            spriteBatch.DrawString(Game1.fonte, "Velocidade do tiro: " + VelTiro, new Vector2(100, 180), Color.White);
            spriteBatch.DrawString(Game1.fonte, "Velocidade da curva: " + VelCurva, new Vector2(100, 230), Color.White);
            spriteBatch.DrawString(Game1.fonte, "Resetar ", new Vector2(100, 355), Color.White);
        }
    }
}
