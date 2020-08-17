using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignObjectiveParticleDisabler
{
    [HarmonyPatch(typeof(MissionObjectiveGameUIView), "RefreshIcon")]
    class RefreshIconPatch
    {
        static void Prefix(ref int ____numberOfParticles)
        {
            ____numberOfParticles = 0;
        }
    }
}
