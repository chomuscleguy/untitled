using UnityEngine;
using static UnityEditor.LightingExplorerTableColumn;

public class ScriptableObjectData : ScriptableObject
{
    public TextAsset CSV;

    public virtual void SetDictionaryData() { }
}