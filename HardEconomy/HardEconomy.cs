using HarmonyLib;
using JaLoader;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Console = JaLoader.Console;
using Random = UnityEngine.Random;

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
            ("JaLoader", "Leaxx", "3.4.1")
        };

        public override bool UseAssets => false;

        public Dictionary<RefuelLogicC, int> zecimalNumber = new Dictionary<RefuelLogicC, int>();

        private static Harmony harmony = new Harmony("Leaxx.HardEconomy");

        private readonly List<MonoBehaviour> alreadyChanged = new List<MonoBehaviour>();

        public override void EventsDeclaration()
        {
            base.EventsDeclaration();

            EventsManager.Instance.OnRouteGenerated += OnRouteGenerated;
        }

        private void OnRouteGenerated(string a, string b, int c)
        {
            Invoke("MakeEverythingHarder", 10);
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

            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        public override void Awake()
        {
            base.Awake();
        }

        public override void Start()
        {
            base.Start();

            Invoke("Prepare", 7);
            Invoke("MakeEverythingHarder", 7);
        }

        public override void Update()
        {
            base.Update();
        }

        public override void OnDisable()
        {
            base.OnDisable();

            harmony.UnpatchSelf();
        }

        private void Prepare()
        {
            foreach (ModsPageItem script in FindObjectsOfTypeAll(typeof(ModsPageItem)))
                if(script.itemName != null && script.itemName != "")
                    script.LoadData();
        }

        private void MakeEverythingHarder()
        {
            float changeBuyValue = Random.Range(1f, 2.5f);
            float changeSellValue = Random.Range(0.5f, 1f);

            foreach (ObjectPickupC obj in FindObjectsOfType<ObjectPickupC>())
            {
                if (!alreadyChanged.Contains(obj))
                {
                    if (obj.objectID == 158) // 158 is fuel can - since it has 10l, we need to update it to the new price of 3$/l, so 30$
                        obj.buyValue = 30;

                    if (obj.objectID == 157) // 157 is the 2-stroke oil
                        obj.buyValue += 5; 

                    obj.buyValue *= changeBuyValue;

                    if (obj.sellValue != 0)
                        obj.sellValue /= changeSellValue;

                    obj.buyValue = (float)decimal.Round((decimal)obj.buyValue, 1);
                    obj.sellValue = (float)decimal.Round((decimal)obj.sellValue, 1);

                    alreadyChanged.Add(obj);
                }
            }

            foreach(ModsPageItem script in FindObjectsOfTypeAll(typeof(ModsPageItem)))
            {
                if (script.itemName == null || script.itemName == "")
                    continue;

                if (!alreadyChanged.Contains(script))
                {
                    ObjectPickupC obj = script.sellingItem.GetComponent<ObjectPickupC>();
                    script.priceText.GetComponent<Text>().text = obj.buyValue.ToString();
                    alreadyChanged.Add(script);
                }
            }

            foreach(MagazineLogicC _script in FindObjectsOfType<MagazineLogicC>())
            {
                if (_script.name != "LaikaCatalogue")
                    continue;

                if (!alreadyChanged.Contains(_script))
                {
                    EngineComponentsCataloguePageC script = _script.transform.Find("Page2_EngineParts").GetComponent<EngineComponentsCataloguePageC>();

                    foreach (GameObject obj in script.prefabs)
                    {
                        ObjectPickupC _obj = obj.GetComponent<ObjectPickupC>();
                        _obj.buyValue *= changeBuyValue;

                        if (_obj.sellValue != 0)
                            _obj.sellValue /= changeSellValue;

                        _obj.buyValue = (float)decimal.Round((decimal)_obj.buyValue);
                        _obj.sellValue = (float)decimal.Round((decimal)_obj.sellValue);
                    }

                    foreach (GameObject obj in script.prefabPaintDecalsSelected)
                    {
                        ObjectPickupC _obj = obj.GetComponent<ObjectPickupC>();
                        _obj.buyValue *= changeBuyValue;

                        if (_obj.sellValue != 0)
                            _obj.sellValue /= changeSellValue;

                        _obj.buyValue = (float)decimal.Round((decimal)_obj.buyValue);
                        _obj.sellValue = (float)decimal.Round((decimal)_obj.sellValue);
                    }

                    foreach (GameObject obj in script.prefabPaintDecals)
                    {
                        ObjectPickupC _obj = obj.GetComponent<ObjectPickupC>();
                        _obj.buyValue *= changeBuyValue;

                        if (_obj.sellValue != 0)
                            _obj.sellValue /= changeSellValue;

                        _obj.buyValue = (float)decimal.Round((decimal)_obj.buyValue);
                        _obj.sellValue = (float)decimal.Round((decimal)_obj.sellValue);
                    }

                    foreach (GameObject obj in script.prefabExtras)
                    {
                        ObjectPickupC _obj = obj.GetComponent<ObjectPickupC>();
                        _obj.buyValue *= changeBuyValue;

                        if (_obj.sellValue != 0)
                            _obj.sellValue /= changeSellValue;

                        _obj.buyValue = (float)decimal.Round((decimal)_obj.buyValue);
                        _obj.sellValue = (float)decimal.Round((decimal)_obj.sellValue);
                    }

                    foreach (GameObject obj in script.prefabExtrasUpgradeLvls)
                    {
                        ObjectPickupC _obj = obj.GetComponent<ObjectPickupC>();
                        _obj.buyValue *= changeBuyValue;

                        if (_obj.sellValue != 0)
                            _obj.sellValue /= changeSellValue;

                        _obj.buyValue = (float)decimal.Round((decimal)_obj.buyValue);
                        _obj.sellValue = (float)decimal.Round((decimal)_obj.sellValue);
                    }

                    foreach (GameObject obj in script.prefabExtrasSelected)
                    {
                        ObjectPickupC _obj = obj.GetComponent<ObjectPickupC>();
                        _obj.buyValue *= changeBuyValue;

                        if (_obj.sellValue != 0)
                            _obj.sellValue /= changeSellValue;

                        _obj.buyValue = (float)decimal.Round((decimal)_obj.buyValue);
                        _obj.sellValue = (float)decimal.Round((decimal)_obj.sellValue);
                    }

                    alreadyChanged.Add(_script);
                }
            }

            foreach(MotelLogicC motel in FindObjectsOfType<MotelLogicC>())
            {
                if (!alreadyChanged.Contains(motel))
                {
                    float price = motel.roomPrice;
                    float changeValue = Random.Range(1f, 2f);
                    price *= changeValue;
                    motel.roomPrice = (int)price;
                    motel.motelPrice.GetComponent<TextMeshPro>().text = motel.roomPrice.ToString();

                    alreadyChanged.Add(motel);
                }   
            }

            foreach (StoreC store in FindObjectsOfType<StoreC>())
            {
                if (!alreadyChanged.Contains(store))
                {
                    var signage = store.transform.Find("PetrolStationSignage_01");

                    for (int i = 0; i < signage.childCount; i++)
                    {
                        if(signage.GetChild(i).GetComponent<TextMeshPro>()?.text == "01,00")
                            signage.GetChild(i).GetComponent<TextMeshPro>().text = "03,00";
                    }

                    alreadyChanged.Add(store);
                }
            }
        }
    }

    [HarmonyPatch(typeof(RefuelLogicC), "FuelPriceUpdate")]
    public static class RefuelLogicC_FuelPriceUpdate_Patch
    {
        [HarmonyPrefix]
        public static bool Prefix(RefuelLogicC __instance)
        {
            HardEconomy hardEconomy = GameObject.FindObjectOfType<HardEconomy>();
            if(!hardEconomy.zecimalNumber.ContainsKey(__instance))
                hardEconomy.zecimalNumber.Add(__instance, 0);

            ShopC shop = __instance.shop.GetComponent<ShopC>();

            shop.totalPrice += 2f;
            shop.visualPrice.GetComponent<TextMesh>().text = shop.totalPrice + ".00";

            iTween.RotateBy(__instance.priceObjs[1], iTween.Hash("z", 0.3, "islocal", true, "time", 0.4, "easetype", "easeoutquad"));

            if (shop.totalPrice >= 10 && hardEconomy.zecimalNumber[__instance] == 0)
            {
                hardEconomy.zecimalNumber[__instance]++;
                iTween.RotateBy(__instance.priceObjs[0], iTween.Hash("z", 0.1, "islocal", true, "time", 0.5, "easetype", "easeoutquad"));
            }

            if (shop.totalPrice >= 20 && hardEconomy.zecimalNumber[__instance] == 1)
            {
                hardEconomy.zecimalNumber[__instance]++;
                iTween.RotateBy(__instance.priceObjs[0], iTween.Hash("z", 0.1, "islocal", true, "time", 0.5, "easetype", "easeoutquad"));
            }

            if (shop.totalPrice >= 30 && hardEconomy.zecimalNumber[__instance] == 2)
            {
                hardEconomy.zecimalNumber[__instance]++;
                iTween.RotateBy(__instance.priceObjs[0], iTween.Hash("z", 0.1, "islocal", true, "time", 0.5, "easetype", "easeoutquad"));
            }

            if (shop.totalPrice >= 40 && hardEconomy.zecimalNumber[__instance] == 3)
            {
                hardEconomy.zecimalNumber[__instance]++;
                iTween.RotateBy(__instance.priceObjs[0], iTween.Hash("z", 0.1, "islocal", true, "time", 0.5, "easetype", "easeoutquad"));
            }

            if (shop.totalPrice >= 50 && hardEconomy.zecimalNumber[__instance] == 4)
            {
                hardEconomy.zecimalNumber[__instance]++;
                iTween.RotateBy(__instance.priceObjs[0], iTween.Hash("z", 0.1, "islocal", true, "time", 0.5, "easetype", "easeoutquad"));
            }

            if (shop.totalPrice >= 60 && hardEconomy.zecimalNumber[__instance] == 5)
            {
                hardEconomy.zecimalNumber[__instance]++;
                iTween.RotateBy(__instance.priceObjs[0], iTween.Hash("z", 0.1, "islocal", true, "time", 0.5, "easetype", "easeoutquad"));
            }

            if (shop.totalPrice >= 70 && hardEconomy.zecimalNumber[__instance] == 6)
            {
                hardEconomy.zecimalNumber[__instance]++;
                iTween.RotateBy(__instance.priceObjs[0], iTween.Hash("z", 0.1, "islocal", true, "time", 0.5, "easetype", "easeoutquad"));
            }

            if (shop.totalPrice >= 80 && hardEconomy.zecimalNumber[__instance] == 7)
            {
                hardEconomy.zecimalNumber[__instance]++;
                iTween.RotateBy(__instance.priceObjs[0], iTween.Hash("z", 0.1, "islocal", true, "time", 0.5, "easetype", "easeoutquad"));
            }

            if (shop.totalPrice >= 90 && hardEconomy.zecimalNumber[__instance] == 8)
            {
                hardEconomy.zecimalNumber[__instance]++;
                iTween.RotateBy(__instance.priceObjs[0], iTween.Hash("z", 0.1, "islocal", true, "time", 0.5, "easetype", "easeoutquad"));
            }

            return false;
        }
    } 
}
