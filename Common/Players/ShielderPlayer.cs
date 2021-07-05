using Terraria.ModLoader;

namespace AccursedShields.Common.Players
{
    public class ShielderPlayer : ModPlayer
    {
        public int ShieldCrit { get; set; }

        public float ShieldKnockback { get; set; }

        public float ShieldDamageAdd { get; set; }

        public float ShieldDamageMult { get; set; } = 1f;

        public override void ResetEffects() => ResetFields();

        public override void UpdateDead() => ResetFields();

        private void ResetFields()
        {
            ShieldCrit = 0;
            ShieldKnockback = 0;
            ShieldDamageAdd = 0;
            ShieldDamageMult = 0;
        }
    }
}
