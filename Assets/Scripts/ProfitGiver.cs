using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProfitGiver : MonoBehaviour
{
    public int gemsToTakeAways = 100;
    public float numberOfprofits = 6f;
    private Button myButton;
    // Start is called before the first frame update
    void Start()
    {
        myButton = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        myButton.onClick.RemoveAllListeners();
        myButton.onClick.AddListener(delegate{ProfitFunc();});
    }
    void ProfitFunc()
    {
        if(ClickManager.Instance.gems >= gemsToTakeAways)
        {
            ClickManager.Instance.gems -= gemsToTakeAways;
            ClickManager.Instance.profitBonus += numberOfprofits - 1;
        }
    }
}
