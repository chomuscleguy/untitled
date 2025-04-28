using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.LightingExplorerTableColumn;

public enum DataType
{
    StatusData,

}

public class DataManager : MonoBehaviour
{
    public  List<ScriptableObjectData> DataSO = new List<ScriptableObjectData>();
    public SerializedDictionary<int, StatusData> statusData = new SerializedDictionary<int, StatusData>();


    private void OnEnable()
    {
        foreach (var data in DataSO)
            data.SetDictionaryData();
    }
}
