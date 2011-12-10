using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroid
{
    /// <summary>
    /// fabio
    /// </summary>
    class Fase4 // fazer com herança
    {
        Boolean playing_musica;
        Song musica;
        Texture2D fundo;

        /// <summary>
        /// Construtor da fase
        /// </summary>
        public Fase4(ContentManager Content)
        {
            playing_musica = false;
            musica = Content.Load<Song>("Kalimba"); 
        }
    }
}
