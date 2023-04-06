using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using IRISKSModpack.Content.Buffs;
using IRISKSModpack.Content.Projectiles;

namespace IRISKSModpack.Content.Items
{
    class CowBell : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cow Bell");
            Tooltip.SetDefault("Summon a cow to your side");
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.DukeFishronPetItem);
            Item.shoot = ModContent.ProjectileType<CowPet>();
            Item.buffType = ModContent.BuffType<CustomBuff>();
        }
        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            //base.UseStyle(player, heldItemFrame);
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600);
            }
        }
    }
}