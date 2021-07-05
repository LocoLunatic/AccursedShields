using AccursedShields.Common.Players;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace AccursedShields.Content.Items.Weapons.Shielder
{
    public abstract class ShielderItem : ModItem
    {
        public enum ShieldType
        {
            Bash,
            Reflect,
            Projectile
        }

        public virtual ShieldType Type => ShieldType.Bash;

        public override bool CloneNewInstances => true;

        public sealed override void SetDefaults()
        {
            SafeSetDefaults();

            item.melee = false;
            item.ranged = false;
            item.magic = false;
            item.summon = false;
            item.thrown = false;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine tooltipLine = tooltips.FirstOrDefault(tooltip => tooltip.Name == "Damage" && tooltip.mod == "Terraria");

            if (tooltipLine != null)
            {
                string[] text = tooltipLine.text.Split(' ');

                string value = text.First();
                string word = text.Last();

                tooltipLine.text = $"{value} shield {word}";
            }
        }

        public override void GetWeaponCrit(Player player, ref int crit) => crit = player.GetModPlayer<ShielderPlayer>().ShieldCrit;

        public override void GetWeaponKnockback(Player player, ref float knockback) => knockback = player.GetModPlayer<ShielderPlayer>().ShieldKnockback;

        public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat)
        {
            add += player.GetModPlayer<ShielderPlayer>().ShieldDamageAdd;
            mult *= player.GetModPlayer<ShielderPlayer>().ShieldDamageMult;
        }

        public virtual void SafeSetDefaults() { }
    }
}
