using TMPro;
using UnityEngine;

public class View : MonoBehaviour
{
    public TextMeshProUGUI index;
    public TextMeshProUGUI name;
    public TextMeshProUGUI gold;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        index.text = Managers.Instance.dataManager.statusData[1].index.ToString();
        name.text = Managers.Instance.dataManager.statusData[1].name;
        gold.text = Managers.Instance.dataManager.statusData[1].gold.ToString();
    }
}
