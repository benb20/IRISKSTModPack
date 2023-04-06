using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IRISKSModpack.Content.Buffs
{
    public class CustomBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Modded Cow");
            Description.SetDefault("Our own cool cow!");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<MyPlayer>().CowPet = true;
            if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.CowPet>()] <= 0 && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.Center, Vector2.Zero, ModContent.ProjectileType<Projectiles.CowPet>(), 0, 0f, player.whoAmI);
            }
        }
    }
}