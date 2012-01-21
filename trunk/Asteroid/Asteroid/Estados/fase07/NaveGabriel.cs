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
    class NaveGabriel
    {
        Texture2D textura;
        Vector2 posicao;
        Color cor;
        float angulo;
        string nomeJogador;
        short vidas;
        ulong pontos;
        GameWindow Stage;
        SoundEffect Som;
        Texture2D texturaTiro;
        Vector2 velocidade;

        int maxCont = 15;
        #region Tiro
        #endregion
        #region Escudo e Barra do escudo
        public bool ativar_escudo = false;
        int contEscudo = 0;

        Barra barra;
        Escudo escudo;
        Texture2D texturaEscudo;
        Texture2D texturaBarra;
        #endregion

        public NaveGabriel(Texture2D textura, Color cor, Vector2 posicao, float angulo, string nomeJogador,
                     short vidas, ulong pontos, GameWindow Stage, Texture2D texturaEscudo, SoundEffect Som,
                     Texture2D texturaTiro, Texture2D texturaBarra)
        {
            this.textura = textura;
            this.cor = cor;
            this.posicao = posicao;
            this.angulo = angulo;
            this.nomeJogador = nomeJogador;
            this.vidas = vidas;
            this.pontos = pontos;
            this.Stage = Stage;
            this.texturaEscudo = texturaEscudo;
            this.Som = Som;
            this.texturaTiro = texturaTiro;
            this.texturaBarra = texturaBarra;

            barra = new Barra(texturaBarra);
            escudo = new Escudo(texturaEscudo);

            posicao.X = Stage.ClientBounds.Width / 2 - textura.Width / 2;
            posicao.Y = Stage.ClientBounds.Height / 2 - textura.Height / 2;
        }
        public void Update (GameTime gameTime, KeyboardState teclado, KeyboardState tecladoanterior)
        {
            contEscudo++;
            if (contEscudo > maxCont) contEscudo = maxCont;

            #region Mover Nave
            if (angulo > 360) angulo -= 360;
            if (angulo < 0) angulo += 360;
            if (teclado.IsKeyDown(Keys.Left) || teclado.IsKeyDown(Keys.A))
            {
                this.angulo -= 5;
            }
            if (teclado.IsKeyDown(Keys.Right) || teclado.IsKeyDown(Keys.D))
            {
                this.angulo += 5;
            }

            if (teclado.IsKeyDown(Keys.Up) || teclado.IsKeyDown(Keys.W))
            {
                this.velocidade.X += (float)Math.Cos(Math.PI * this.angulo / 180) * 0.1f;
                this.velocidade.Y += (float)Math.Sin(Math.PI * this.angulo / 180) * 0.1f;
                if (velocidade.X > 7) velocidade.X = 7;
                if (velocidade.X < -7) velocidade.X = -7;
                if (velocidade.Y > 7) velocidade.Y = 7;
                if (velocidade.Y < -7) velocidade.Y = -7;
            }
            posicao += velocidade;
            #endregion
            #region Limites da tela
            if (posicao.X > Stage.ClientBounds.Width + textura.Width / 2)
            {
                posicao.X = -textura.Width / 2 + 10;
                Fase7.Objetivo++;
            }
            if (posicao.X < -textura.Width / 2 + 10)
            {
                if (Fase7.Objetivo > 0) Fase7.Objetivo--;
                posicao.X = Stage.ClientBounds.Width + textura.Width / 2;
            }
            if (posicao.Y > Stage.ClientBounds.Height + textura.Height / 2)
            {
                posicao.Y = 0 - textura.Height / 2;
            }
            if (posicao.Y < 0 - textura.Height / 2)
            {
                posicao.Y = Stage.ClientBounds.Height + textura.Height / 2;
            }
            #endregion
            #region Escudo e Barra
            if (teclado.IsKeyDown(Keys.E) && !ativar_escudo && contEscudo >= maxCont)
            {
                contEscudo = 0;
                ativar_escudo = true;
            }
            if (teclado.IsKeyDown(Keys.E) && ativar_escudo && contEscudo >= maxCont)
            {
                contEscudo = 0;
                ativar_escudo = false;
            }
            if (ativar_escudo)
            {
                escudo.Update(posicao);
            }
            barra.Update(ativar_escudo);
            if (!barra.permicao) ativar_escudo = false;
            #endregion
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (ativar_escudo) escudo.Draw(gameTime, spriteBatch);

            barra.Draw(gameTime, spriteBatch);

            spriteBatch.Draw(textura, posicao, new Rectangle(0, 0, textura.Width, textura.Height), cor, MathHelper.ToRadians(angulo),
                            new Vector2(textura.Width / 2, textura.Height / 2), 0.7f, SpriteEffects.None, 0);
        }
    }
}
