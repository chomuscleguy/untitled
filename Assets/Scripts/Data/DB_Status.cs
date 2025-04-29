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
    public List<ItemData> equipmentList;
    public List<InventoryItem> inventoryList;
}
[Serializable]
public class InventoryItem
{
    public int index;
    public string name;
    public int amount;
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

            newData.equipmentList = new List<ItemData>();
            newData.inventoryList = new List<InventoryItem>();

            if (keyValues.ContainsKey("equip"))
            {
                string equipmentData = keyValues["equip"];
                string[] equipmentItems = equipmentData.Split(';');

                foreach (string equip in equipmentItems)
                {
                    if (int.TryParse(equip.Trim(), out int itemIndex))
                    {
                        if (Managers.Instance.dataManager.itemData.TryGetValue(itemIndex, out ItemData item))
                        {
                            newData.equipmentList.Add(item);
                        }
                    }
                }
            }
            if (keyValues.ContainsKey("inventory"))
            {
                string inventoryData = keyValues["inventory"];
                string[] inventoryItems = inventoryData.Split(';');

                foreach (string inventoryItem in inventoryItems)
                {
                    string[] itemData = inventoryItem.Split('.');

                    if (itemData.Length == 2)
                    {
                        int itemIndex;
                        int itemAmount;

                        if (int.TryParse(itemData[0].Trim(), out itemIndex) && int.TryParse(itemData[1].Trim(), out itemAmount))
                        {
                            if (Managers.Instance.dataManager.itemData.TryGetValue(itemIndex, out ItemData item))
                            {
                                InventoryItem newItem = new InventoryItem()
                                {
                                    index = item.index,  
                                    name = item.name,    
                                    amount = itemAmount         
                                };

                                newData.inventoryList.Add(newItem);
                            }
                        }
                    }
                }
            }
            Managers.Instance.dataManager.statusData.Add(newData.index, newData);
        }
    }
}
