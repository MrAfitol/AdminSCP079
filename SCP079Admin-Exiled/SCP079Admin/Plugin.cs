using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCP079Admin
{
    public class Plugin : Plugin<Config>
    {
        public override string Author { get; } = "MrAfitol";
        public override string Name { get; } = "SCP079Admin";
        public override string Prefix { get; } = "scp079admin";
        public override System.Version RequiredExiledVersion { get; } = new System.Version(2, 10, 0);
        public override System.Version Version { get; } = new System.Version(1, 0, 0);

        public override void OnEnabled()
        {
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
        }
    }
}
