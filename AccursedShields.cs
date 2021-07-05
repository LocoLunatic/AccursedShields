using Terraria;
using Terraria.ModLoader;

namespace AccursedShields
{
    public class AccursedShields : Mod
	{
		internal static AccursedShields Instance { get; private set; }

		public AccursedShields() => Instance = this;

        public override void Unload()
        {
            if (!Main.dedServ)
            {
                Instance = null;
            }
        }
    }
}