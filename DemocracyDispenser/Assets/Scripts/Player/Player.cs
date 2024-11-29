using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace DemocracyDispenser
{
    public class Player : MonoSingleton<Player>
    {
        public Stats stats = new Stats();
        void Start()
        {
            string filePath = Application.persistentDataPath + "/StatData.json";

            if (System.IO.File.Exists(filePath))
            {
                string json = System.IO.File.ReadAllText(filePath);
                Stats stats = JsonUtility.FromJson<Stats>(json);

                if (stats != null)
                {
                    LoadData();
                }
                else
                {
                    SaveData();
                }
            }
            else
            {
                SaveData();
            }
        }

    
        public void SaveData()
        {
            string jsonObject = JsonUtility.ToJson(stats);
            string filePath = Application.persistentDataPath + "/StatData.json";
            Debug.Log(filePath);
            System.IO.File.WriteAllText(filePath, jsonObject);
            Debug.Log("Saved!");
        }
        public void LoadData()
        {
            string filePath = Application.persistentDataPath + "/StatData.json";
            string StatData = System.IO.File.ReadAllText(filePath);

            stats = JsonUtility.FromJson<Stats>(StatData);
            Debug.Log("SuccessfullyLoad!");
        }


}
    [System.Serializable]
public class Stats
{
    public float HP;
    public float Damage;
    public float Shield;
    public float AttackSpeed;
    public float GadgetCoolDown;
    public float MovementSpeed;
    public float Durability;
    public int XP;
    public float Resource;
    public float Gathering;
    public float Map;
    public float CritChance;
    public float CritDamage;
    public float Dodge;
    public float Luck;
    public float LifeSteal;
    public int Level = 0;
    public float XPamount=0;
    public List<Items> items = new List<Items>();
}

    [System.Serializable]
public class Items
{
    public string ItemCode;
}
}

