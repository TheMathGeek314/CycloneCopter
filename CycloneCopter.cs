using Modding;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using Satchel;

namespace CycloneCopter {
    public class CycloneCopter: Mod {
        new public string GetName() => "CycloneCopter";
        public override string GetVersion() => "1.0.0.0";

        public override void Initialize(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects) {
            On.PlayMakerFSM.OnEnable += editFSM;
        }

        private void editFSM(On.PlayMakerFSM.orig_OnEnable orig, PlayMakerFSM self) {
            orig(self);
            if(self.gameObject.name == "Knight" && self.FsmName == "Nail Arts") {
                FsmState extend = self.GetState("Cyclone Extend");
                ((FloatAdd)extend.Actions[6]).add = 0.3f;
                ((FloatAdd)extend.Actions[7]).add = 0.3f;
                FloatAdd lift = new FloatAdd() {
                    floatVariable = self.FsmVariables.GetFsmFloat("Y Velocity"),
                    add = 20,
                    everyFrame = false,
                    perSecond = false
                };
                extend.InsertAction(lift, 2);
            }
        }
    }
}