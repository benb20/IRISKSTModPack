using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace IRISKSModpack.Content.Projectiles
{
    public class CowPet : ModProjectile
    {
        public bool yFlip; //used to suppress y velocity (pet fastfalls with an extra update per tick otherwise)
        public float notlocalai1 = 0f;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cow Pet");
            Main.projFrames[Projectile.type] = 12;
            Main.projPet[Projectile.type] = true;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 6;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.ignoreWater = true;
            Projectile.aiStyle = 26;
            AIType = ProjectileID.BlackCat; // Walks around, etc.
            Projectile.netImportant = true;
            Projectile.friendly = true;

            Projectile.extraUpdates = 1;
        }

        public override bool PreAI()
        {
            Main.player[Projectile.owner].blackCat = false;
            return true;
        }
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
            if (player.dead)
            {
                modPlayer.CowPet = false;
            }

            if (modPlayer.CowPet)
            {
                Projectile.timeLeft = 2;
            }
            if (Projectile.tileCollide && Projectile.velocity.Y > 0) //pet updates twice per tick, this is called every tick; effectively gives it normal gravity when tangible
            {
                yFlip = !yFlip;
                if (yFlip)
                    Projectile.position.Y -= Projectile.velocity.Y;
            }
            /*
            if (player.velocity == Vector2.Zero) //run code when not moving
                BeCompanionCube(); */
        }


    }
}