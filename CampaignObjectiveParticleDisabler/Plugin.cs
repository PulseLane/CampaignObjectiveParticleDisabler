using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using HarmonyLib;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using UnityEngine;
using IPALogger = IPA.Logging.Logger;

namespace CampaignObjectiveParticleDisabler
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        public const string HarmonyId = "com.PulseLane.BeatSaber.CampaignObjectiveParticleDisabler";
        internal static Harmony harmony => new Harmony(HarmonyId);

        internal static Plugin instance { get; private set; }
        internal static string Name => "CampaignObjectiveParticleDisabler";

        [Init]
        public Plugin(IPALogger logger)
        {
            instance = this;
            Logger.log = logger;
            Logger.log.Debug("Logger initialized.");
        }

        [OnEnable]
        public void OnEnable()
        {
            ApplyHarmonyPatches();
        }
        [OnDisable]
        public void OnDisable()
        {
            RemoveHarmonyPatches();
        }

        public static void ApplyHarmonyPatches()
        {
            try
            {
                Logger.log.Debug("Applying Harmony patches.");
                harmony.PatchAll(Assembly.GetExecutingAssembly());
            }
            catch (Exception ex)
            {
                Logger.log.Critical("Error applying Harmony patches: " + ex.Message);
                Logger.log.Debug(ex);
            }
        }

        public static void RemoveHarmonyPatches()
        {
            try
            {
                // Removes all patches with this HarmonyId
                harmony.UnpatchAll(HarmonyId);
            }
            catch (Exception ex)
            {
                Logger.log.Critical("Error removing Harmony patches: " + ex.Message);
                Logger.log.Debug(ex);
            }
        }
    }
}
