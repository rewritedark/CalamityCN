using CalamityCN.Translations.InfernumMode;
using CalamityCN.Translations.Patch;
using CalamityCN.Translations.TransInHjson;
using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.UI;

namespace CalamityCN.Utils
{
    public class TranslationManager : ModSystem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModsCall.IsCN && ModsCall.Calamity != null;
        }
        public override void Load()
        {
            MonoModHooks.RequestNativeAccess();
            ModePatch.Load();
            UIPatch.Load();
            TextPatch.Load();
            if(ModsCall.Infernum != null)
            {
                InfernumPatch.Load();
            }
        }
        public override void Unload()
        {
            UIPatch.Unload();
            ModePatch.Unload();
            TextPatch.Unload();
            if (ModsCall.Infernum != null)
            {
                InfernumPatch.Unload();
            }
        }
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            if (!ModsCall.IsCN)
            {
                return;
            }
            if (ModsCall.Calamity == null)
            {
                return;
            }
            CombatTextTrans.LoadTranslation();
            if (ModsCall.Infernum !=null)
            {
                InfenumCombatTextTrans.LoadTranslation();
            }
        }
    }
}
