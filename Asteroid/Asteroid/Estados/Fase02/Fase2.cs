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
    /// Carlos Moffatt
    /// </summary>
    class Fase2 {
        Boolean playing_musica;
        Song musica;
        Texture2D texturaFundo;
        Texture2D texturaNave;
        Vector2 tamanhoStage;
        Vector2 tamanhoFundo;
        Vector2 posFundo;
        Vector2 posicao_j1;
        NaveFase2 jogador1;

        public Fase2(ContentManager Content) {
            playing_musica = false;
            musica = Content.Load<Song>("Estados/Fase02/musica_fase2");
            texturaFundo = Content.Load<Texture2D>("Estados/Fase02/fundoFase2");
            tamanhoFundo.X = texturaFundo.Bounds.Width;
            tamanhoFundo.Y = texturaFundo.Bounds.Height;
            texturaNave = Content.Load<Texture2D>("Estados/Fase02/naveFase2");
            tamanhoStage.X = 800;
            tamanhoStage.Y = 480;
            posicao_j1.X = (tamanhoStage.X - texturaNave.Bounds.Width) / 2;
            posicao_j1.Y = (tamanhoStage.Y - texturaNave.Bounds.Height) / 2;
           
        }

        public void Update(GameTime gameTime, KeyboardState teclado, KeyboardState tecladoAnterior)
        {
            if (!playing_musica) {
                MediaPlayer.Play(musica);
                playing_musica = true;
            }
            posFundo.X = (tamanhoStage.X / 2) - (tamanhoFundo.X / 2);
            posFundo.Y = (tamanhoStage.Y / 2) - (tamanhoFundo.Y / 2);
            //jogador1.Update(gameTime, teclado, tecladoAnterior);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.Draw(texturaFundo, posFundo, Color.White);
            //jogador1.Draw(gameTime, spriteBatch);
        }
    
    }//fim da classe
}
