using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ConversionScript : MonoBehaviour
{
    public int gemsToTakeAway = 1;
    public float numberOfClicks = 100f;
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
        myButton.onClick.AddListener(delegate{Conversion();});
    }
    void Conversion()
    {
        ClickManager.Instance.gems -= gemsToTakeAway;
        ClickManager.Instance.funds += numberOfClicks * ClickManager.Instance.clickValue;
    }
}
