using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class StatusData
{
    public int index;
    public string name;
    public int gold;
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

            Managers.Instance.dataManager.statusData.Add(newData.index, newData);
        }
    }
}
