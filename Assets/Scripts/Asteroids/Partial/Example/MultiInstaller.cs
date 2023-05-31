using System.Collections.Generic;
using Plugins.DI;

namespace Asteroids.Partial.Example
{
    public class MultiInstaller
    {
        private readonly IEnumerable<IInstaller> installers;

        public MultiInstaller(IEnumerable<IInstaller> installers)
        {
            this.installers = installers;
        }

        public void Install(Container container)
        {
            foreach (var installer in installers)
            {
                installer.Install(container);
            }
        }
    }
}