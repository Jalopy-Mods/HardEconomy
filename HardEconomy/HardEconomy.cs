using JaLoader;
using System.Collections.Generic;
using UnityEngine;

namespace HardEconomy
{
    public class HardEconomy : Mod
    {
        public override string ModID => "HardEconomy";
        public override string ModName => "Hard Economy";
        public override string ModAuthor => "Leaxx";
        public override string ModDescription => "Requires you to be wise with your expenses!";
        public override string ModVersion => "1.0";
        public override string GitHubLink => "https://github.com/Jalopy-Mods/HardEconomy";
        public override WhenToInit WhenToInit => WhenToInit.InGame;
        public override List<(string, string, string)> Dependencies => new List<(string, string, string)>()
        {
        };

        public override bool UseAssets => false;

        public override void EventsDeclaration()
        {
            base.EventsDeclaration();
        }

        public override void SettingsDeclaration()
        {
            base.SettingsDeclaration();
        }

        public override void CustomObjectsRegistration()
        {
            base.CustomObjectsRegistration();
        }

        public override void OnEnable()
        {
            base.OnEnable();
        }

        public override void Awake()
        {
            base.Awake();
        }

        public override void Start()
        {
            base.Start();
        }

        public override void Update()
        {
            base.Update();
        }

        public override void OnDisable()
        {
            base.OnDisable();
        }
    }
}
