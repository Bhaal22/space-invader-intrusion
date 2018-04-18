namespace space_invader
{
    /// <summary>
    /// Boostrap all actors involded in Space Invader recognition
    /// </summary>
    internal class NaiveInvaderDetector: ISpaceInvaderDetectorSystem
    {
        public IRepository Repository { get; internal set; } = null;
        public IPalantir Palantir { get; internal set; } = null;
        public IRadar Radar { get; internal set; } = null;

        public void Boostrap<TRepository, TPalantir, TRadar>()
            where TRepository: IRepository, new()
            where TPalantir: IPalantir, new()
            where TRadar: IRadar, new()
        {
            Repository = new TRepository();
            Palantir = new TPalantir();
            Radar = new TRadar();
        }

        public bool InvasionDetected()
        {
            var currentradarImage = Radar.CurrentImage();

            Image knownInvader;
            int numberOfInvadersDetected = 0;

            while ((knownInvader = Repository.Next()) != null)
            {
                if (Palantir.Match(currentradarImage, knownInvader))
                    numberOfInvadersDetected++;
            }

            return numberOfInvadersDetected > 0;
        }
    }
}
