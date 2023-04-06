using Terraria.ModLoader;

namespace IRISKSModpack.Content
{
    public class MyPlayer : ModPlayer
    {
        /*private const int saveVersion = 0;
        public bool minionName = false;
        public static bool hasProjectile;*/
        public bool Pet = false;
        public bool CowPet;

        public override void ResetEffects()
        {
            CowPet = false;
        }
    }
}