using System.Collections.Generic;
using System;
using UnityEngine;
using static UnityEditor.Progress;

[Serializable]
public class StatusData
{
    public int index;
    public string name;
    public int gold;
    public int level;
    public int health;
    public int attack;
    public int defense;
    public List<EquipmentData> equipmentList;
}

[CreateAssetMenu(fileName = "DB_Status", menuName = "DB/Status", order = -1)]
public class DB_Status : ScriptableObjectData
{
    public override void SetDictionaryData()
    {
        string[] textLine = CSV.text.Split('\n');

        string[] Keys = textLine[0].Split(',');

        for (int i = 1; i < textLine.Length; i++)
        {
            string[] values = textLine[i].Split(',');

            Dictionary<string, string> keyValues = new Dictionary<string, string>();
            for (int j = 0; j < values.Length; j++)
            {
                keyValues.Add(Keys[j], values[j]);
            }

            if (!keyValues.ContainsKey("index"))
                continue;

            StatusData newData = new StatusData();

            newData.index = int.Parse(keyValues[nameof(newData.index)]);
            newData.name = keyValues[nameof(newData.name)];
            newData.gold = int.Parse(keyValues[nameof(newData.gold)]);
            newData.level = int.Parse(keyValues[nameof(newData.level)]);
            newData.health = int.Parse(keyValues[nameof(newData.health)]);
            newData.attack = int.Parse(keyValues[nameof(newData.attack)]);
            newData.defense = int.Parse(keyValues[nameof(newData.defense)]);

            newData.equipmentList = new List<EquipmentData>();

            if (keyValues.ContainsKey("equipment"))
            {
                string equipmentData = keyValues["equipment"];
                string[] equipmentItems = equipmentData.Split(';');

                foreach (string item in equipmentItems)
                {
                    if (int.TryParse(item.Trim(), out int equipmentIndex))
                    {
                        if (Managers.Instance.dataManager.equipmentData.TryGetValue(equipmentIndex, out EquipmentData equipment))
                        {
                            newData.equipmentList.Add(equipment);
                        }
                    }
                }
                Managers.Instance.dataManager.statusData.Add(newData.index, newData);
            }
        }
    }
}
