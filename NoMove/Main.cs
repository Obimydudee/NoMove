using MelonLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NoMove
{
    internal class Main
    {
        public static void fuck()
        {
            MelonCoroutines.Start(WaitForCoHTML());
        }




        public static IEnumerator WaitForCoHTML()
        {
            while (GameObject.Find("/Cohtml") == null)
            {
                yield return null;
            }
            Console.WriteLine("Got CoHTML!");
            UI.setUi();
        }
    }
}
