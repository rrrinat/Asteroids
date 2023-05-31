using System.Collections.Generic;

namespace Plugins.DI
{
    public class MultiInstaller
    {
        private readonly IEnumerable<IInstaller> installers;

        public MultiInstaller(IEnumerable<IInstaller> installers)
        {
            this.installers = installers;
        }

        public void Install(DIContainer diContainer)
        {
            foreach (var installer in installers)
            {
                installer.Install(diContainer);
            }
        }
    }
}