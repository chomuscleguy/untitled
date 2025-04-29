using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class EquipmentData
{
    public int index;
    public string name;
    public int attackBonus;
    public int defenseBonus;
}
[CreateAssetMenu(fileName = "DB_Equipment", menuName = "DB/Equipment", order = -1)]
public class DB_Equipment : ScriptableObjectData
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

            EquipmentData newData = new EquipmentData();

            newData.index = int.Parse(keyValues[nameof(newData.index)]);
            newData.name = keyValues[nameof(newData.name)];
            newData.attackBonus = int.Parse(keyValues[nameof(newData.attackBonus)]);
            newData.defenseBonus = int.Parse(keyValues[nameof(newData.defenseBonus)]);

            Managers.Instance.dataManager.equipmentData.Add(newData.index, newData);
        }
    }
}
