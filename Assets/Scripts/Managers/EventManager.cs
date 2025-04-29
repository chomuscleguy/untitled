using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action<string> OnDungeonCompleted;

    public static void TriggerDungeonCompletion(string result)
    {
        OnDungeonCompleted?.Invoke(result);
    }
}
