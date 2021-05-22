using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using UnityEngine;
using Dungeonator;
using Gungeon;
using MonoMod.RuntimeDetour;
using System.IO;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;
//using UnityEngine.SceneManagement;

namespace RemoveLordOfTheJammed
{
    public class JammerMain : ETGModule
    {
        public override void Init()
        {

        }
        public override void Start()
        {

            try
			{
                Hook mainhook = new Hook(typeof(SuperReaperController).GetMethod("Start", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance),
                    typeof(JammerHook).GetMethod("StartHook", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance), typeof(SuperReaperController));
            }
			catch (Exception exception)
            {
				Console.WriteLine("[RemoveLordOfTheJammed] Error occured while installing hooks");
				Debug.LogException(exception);
			}
			


	    }
        public override void Exit() 
        {   
        }
    }


    public class JammerHook : MonoBehaviour
    {
		public void StartHook(SuperReaperController self)
        {
			Debug.Log("[RemoveLordOfTheJammed] StartHook");
            SuperReaperController superreaper = UnityEngine.Object.FindObjectOfType<SuperReaperController>();  
            
            if (superreaper != null)
            {
                Debug.Log("[RemoveLordOfTheJammed] Destroyed reaper");
                UnityEngine.Object.Destroy(superreaper.gameObject);
                
            }

            
        }

    }





}
