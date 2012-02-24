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
    /// Paulo
    /// </summary>
    class Fase12
    {
        String autor;
        Boolean playing_musica;
        Song musica;
        Texture2D texturaFundo;
        Texture2D texturaNave;
        Texture2D texturaInimigo;
        Vector2 posicao_j1;
        Vector2 posicao_i1;
        Nave_jogador jogador1;
        Nave_inimigo inimigo1;
        GameWindow gw;
        int inimigosRestantes;
        Random randomizador = new Random();
        Asteroide asteroide_gerenciador;
        ContentManager _Content;


        string file_path = "Estados/Fase03/";
        

        List<Nave_inimigo> listaInimigos = new List<Nave_inimigo>();
        
        
        int qtdInimigos = 10;

        public Fase12(ContentManager Content, GameWindow gw)
        {
            this.gw = gw;
            autor = "FASE 12 - Paulo Roberto";

            _Content = Content;
            
            inimigosRestantes = 5;

            #region music
            playing_musica = false;
            musica =  Content.Load<Song>("Estados/Fase03/fase3");
            #endregion

            texturaFundo = Content.Load<Texture2D>("Estados/Fase12/FundoFase12");
            texturaNave = Content.Load<Texture2D>("Estados/Fase02/naveFase2");
            posicao_j1.X = (gw.ClientBounds.Width - texturaNave.Bounds.Width) / 2;
            posicao_j1.Y = (gw.ClientBounds.Height - texturaNave.Bounds.Height) / 2;
            jogador1 = new Nave_jogador(1, texturaNave, posicao_j1, 0, gw, Content);

            texturaInimigo = Content.Load<Texture2D>("Estados/Fase02/nave_inimiga1");
            posicao_i1.X = randomizador.Next(gw.ClientBounds.Width);
            posicao_i1.Y = randomizador.Next(gw.ClientBounds.Height);
            

            for (int i = 0; i < 5; i++)
            {
                posicao_i1.X = randomizador.Next(gw.ClientBounds.Width);
                posicao_i1.Y = randomizador.Next(gw.ClientBounds.Height);
                inimigo1 = new Nave_inimigo(0, texturaInimigo, posicao_i1, 0f, gw, 15, Content, randomizador.Next(60));
                listaInimigos.Add(inimigo1);
           
            }

            asteroide_gerenciador = new Asteroide(
                Content.Load<Texture2D>("Asteroides"),
                Vector2.Zero,
                0.0f,
                gw,
                Content
                );

            
        }

        public void Update(GameTime gameTime, KeyboardState teclado, KeyboardState tecladoAnterior, GamePadState _controle, GamePadState _controleanterior)
        {
            #region controle audio
            if (!playing_musica)
            {
                playing_musica = true;
                MediaPlayer.Play(musica);
                MediaPlayer.Volume = 0.5f;

            }
            #endregion
            jogador1.Update(gameTime, teclado, tecladoAnterior, _controle, _controleanterior);
            for (int i = 0; i < listaInimigos.Count; i++)
            {
                listaInimigos[i].Update(gameTime);

                // checa a colisao da nava com os inimigos
                if (jogador1.Colisao(listaInimigos[i].hitBox))
                {
                    listaInimigos.RemoveAt(i);
                    Nave_jogador.vidas--;
                }
            }


            #region teste hit tiro/inimigo
            for (int i = 0; i < Shot.listaTiros.Count; i++)
            {
                if (Shot.listaTiros[i].remover)
                {
                    Shot.listaTiros.RemoveAt(i);
                    if (inimigosRestantes == 0)
                    {
                        Shot.listaTiros.Clear();
                        Game1.estadoAtual = Game1.estados.FASE4;
                    }
                    continue;
                }
                for (int j = 0; j < listaInimigos.Count; j++)
                {
                    if (Shot.listaTiros[i].Colisao(listaInimigos[j].hitBox))
                    {
                        listaInimigos.RemoveAt(j);
                        inimigosRestantes--;
                        Shot.listaTiros[i].remover = true;
                    }
                }
            }
            #endregion

            if (listaInimigos.Count < 5)
            {
                posicao_i1.X = randomizador.Next(gw.ClientBounds.Width);
                posicao_i1.Y = randomizador.Next(gw.ClientBounds.Height);

                listaInimigos.Add(new Nave_inimigo(0, texturaInimigo, posicao_i1, 0f, gw, 15, _Content));
            }


            asteroide_gerenciador.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texturaFundo, new Rectangle(0, 0, gw.ClientBounds.Width,
               gw.ClientBounds.Height), Color.White);

            spriteBatch.DrawString(Game1.fonte, "Inimigos restantes: ", new Vector2(5, 5), Color.White);
            spriteBatch.DrawString(
                Game1.fonte
                , "Naves: " + Nave_jogador.vidas
                , new Vector2(Game1.fonte.MeasureString("Inimigos restantes: 999").X, 5)
                , Color.White
            );
            spriteBatch.DrawString(
                Game1.fonte
                , autor
                , new Vector2(gw.ClientBounds.Width - Game1.fonte.MeasureString(autor).X - 5, 5)
                , Color.White
            );

            jogador1.Draw(gameTime, spriteBatch);
            
            for (int i = 0; i < listaInimigos.Count; i++)
            {
                listaInimigos[i].Draw(gameTime, spriteBatch);
            }
            
            asteroide_gerenciador.Draw(gameTime, spriteBatch);

        }

    }//fim da classe
}
