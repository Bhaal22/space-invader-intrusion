using System.Collections.Generic;

namespace space_invader
{
    /// <summary>
    /// Internal Database of known Space Invaders
    /// Simple naive data storage class
    /// </summary>
    internal class KnownInvadersRepository: IRepository
    {
        public List<Image> KnownInvaders { get; internal set; }

        private int _currentIndex;

        public KnownInvadersRepository()
        {
            _currentIndex = 0;
            KnownInvaders = new List<Image>
            {
                new Image(new List<string>
                {
                    "--o-----o--",
                    "---o---o---",
                    "--ooooooo--",
                    "-oo-ooo-oo-",
                    "ooooooooooo",
                    "o-ooooooo-o",
                    "o-o-----o-o",
                    "---oo-oo---"
                }),

                new Image(new List<string>
                {
                    "---oo---",
                    "--oooo--",
                    "-oooooo-",
                    "oo-oo-oo",
                    "oooooooo",
                    "--o--o--",
                    "-o-oo-o-",
                    "o-o--o-o"
                })
            };
        }

        public Image Next()
        {
            if (_currentIndex >= KnownInvaders.Count)
                return null;

            return KnownInvaders[_currentIndex++];
        }
    }
}
