using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ABI_RC.Core.Player;
using ABI_RC.Systems.Camera.VisualMods;
using ABI_RC.Systems.Movement;
using BTKUILib;
using BTKUILib.UIObjects;
using BTKUILib.UIObjects.Components;
using ECM2;
using UnityEngine;

namespace NoMove
{
    internal class UI
    {
        public static Page Pageroot;
        public static Category PageCategory;
        public static CVRPlayerEntity SelectedPlayer;
        private static FieldInfo _uiInstance = typeof(QMUIElement).Assembly.GetType("BTKUILib.UserInterface").GetField("Instance", BindingFlags.Static | BindingFlags.NonPublic);

        private static MethodInfo _registerRootPage = typeof(QMUIElement).Assembly.GetType("BTKUILib.UserInterface").GetMethod("RegisterRootPage", BindingFlags.Instance | BindingFlags.NonPublic);

        private static GameObject LocalPlayer;
        public static GameObject GetLocalPlayer()
        {
            if (LocalPlayer == null) LocalPlayer = GameObject.Find("_PLAYERLOCAL");
            return LocalPlayer;
        }

        public static void LoadAssets()
        {
            QuickMenuAPI.PrepareIcon("NoMove", "NoMoveLogo", Assembly.GetExecutingAssembly().GetManifestResourceStream("NoMove.Resources.nomoving.png"));
        }

        public static void HRR(Page element)
        {
            _registerRootPage.Invoke(_uiInstance.GetValue(null), new object[1] { element });
        }

        public static void setUi() 
        {
            Page page = new Page("NoMove", "NoPage", isRootPage: true, "NoMoveLogo")
            {
                MenuTitle = "NoMove",
                MenuSubtitle = "For the VR sleepers that don't like drifting around"
            };
            Pageroot = page;
            Category cat = page.AddCategory("NoMove");
            ToggleButton nomove = cat.AddToggle("Toggle Moving", "Turn off local player movement", false);
            ToggleButton nomovetoggle = nomove;
            nomovetoggle.OnValueUpdated += newbool =>
            {

                if (newbool)
                {
                    ABI_RC.Systems.Movement.BetterBetterCharacterController.Instance.SetImmobilized(true);
                }
                else
                {
                    ABI_RC.Systems.Movement.BetterBetterCharacterController.Instance.SetImmobilized(false);
                }
            };
        }
        

    }
}
