using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GameDevTV.Saving;
public class ClickManager : MonoBehaviour,ISaveable
{
    private static ClickManager instance;
    public static ClickManager Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.Log("Not found");
            }
            return instance;
        }
    }
    float coinspersec = 0;
    public float funds = 0;
    public float clickValue = 1;
    Button myButton;
    public bool clickDefault = false;
    public float profitBonus = 1f;
    public TextHandler textHandler;
    TextMeshProUGUI fundingValue;
    public TextMeshProUGUI gemsText;
    public TextMeshProUGUI inactiveFundingText;
    public int gems = 25;
    void Awake() 
    {
        instance = this;
    }
    void Start()
    {
        myButton = GetComponent<Button>();
        fundingValue = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        textHandler = GameObject.Find("Text Handler").GetComponent<TextHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        funds +=profitBonus*coinspersec*Time.deltaTime;
        UpdateInactiveFundingText();
        UpdateText();
        myButton.onClick.RemoveAllListeners();
        myButton.onClick.AddListener(delegate{IncrementingFunding();CoinMaker();});
        if(clickDefault)
        {
            clickDefault = false;
            DefaultClickManager();
        }
    }
    void IncrementingFunding()
    {
        funds += profitBonus * 1 * clickValue;
    }
    public void DefaultClickManager()
    {
        coinspersec = 0;
        funds = 0;
        clickValue = 1;
    }
    void UpdateText()
    {
        textHandler.TextHandlerFunc(fundingValue,funds);
        gemsText.text = gems.ToString() + "  gems";
    }
    void CoinMaker()
    {
        CoinPlayer coinPlayer = GetComponentInParent<CoinPlayer>();
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            coinPlayer.InstantiateAndDestroy(touch.position);
        }
    }
    // for purchasing
    public void PurchaseValue(float value)
    {
        funds -= value;
    }
    public void AddClickValue(float value)
    {
        clickValue += value;
    }
    public void MultiplyClickValue(float value)
    {
        clickValue = clickValue * value;
    }
    public void AddInactiveFunding(float value)
    {
        coinspersec += value;
    }
    void UpdateInactiveFundingText()
    {
        textHandler.TextHandlerFunc(inactiveFundingText,coinspersec);
    }
    public object CaptureState()
    {
        Dictionary<string,object> data = new Dictionary<string,object>();
        data["funds"] = funds;
        data["coinspersec"] = coinspersec;
        data["clickvalue"] = clickValue;
        data["gemsvalue"] = gems;
        data["profitValue"] = profitBonus;
        return data;
    }
    public void RestoreState(object state)
    {
        Dictionary<string,object> data = (Dictionary<string,object>) state;
        funds = (float)data["funds"];
        coinspersec = (float)data["coinspersec"];
        clickValue = (float)data["clickvalue"];
        gems = (int)data["gemsvalue"];
        profitBonus = (float)data["profitValue"];
    }
}
