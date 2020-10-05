using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GameDevTV.Saving;
[RequireComponent(typeof(AudioSource))]
public class Button_Upgr : MonoBehaviour,ISaveable
{
    public List<float> minimumRequirements;
    public List<float> perClickValueAdd;
    public TextMeshProUGUI myText;
    public int level = 0;
    public int maxLevel = 8;
    Button me;
    public GameObject toShow;
    public bool isShown;
    AudioSource audioSorce;
    public TextHandler textHandler;
    // Start is called before the first frame update
    void Start()
    {
        me = GetComponent<Button>();
        myText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        textHandler = GameObject.Find("Text Handler").GetComponent<TextHandler>();
        audioSorce = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isShown)
        {
            toShow.SetActive(true);
        }
        if( level < maxLevel && minimumRequirements[level] <= ClickManager.Instance.funds)
        {
            me.interactable = true;
            me.onClick.RemoveAllListeners();
            me.onClick.AddListener(delegate{level += 1;PurchasingClickValue();ManagingInstantiation();audioSorce.Play();});
        }
        else
        {
            me.interactable = false;
        }
        if(level >= maxLevel)
        {
            me.interactable = false;
            myText.text = "maxed";
        }
        UpdateText();
    }
    void ManagingInstantiation()
    {
        if(toShow != null)
        {
            if(!isShown)
            {
                toShow.SetActive(true);
                isShown = true;
            }
        }
    }
    void PurchasingClickValue()
    {
        ClickManager.Instance.PurchaseValue(minimumRequirements[level - 1]);
        ClickManager.Instance.AddClickValue(perClickValueAdd[level -1]);
    }
    void UpdateText()
    {
        if(level < maxLevel)
        {
            textHandler.TextHandlerFunc(myText,minimumRequirements[level]);
        }
    }
    public void DefaultButtonUpgr()
    {
        isShown = false;
        level = 0;
    }
    float RoundOff(float toRound)
    {
        return (float)System.Math.Round(toRound,2);
    }
    public object CaptureState()
    {
        Dictionary<string,object> data = new Dictionary<string,object>();
        data["leveldata"] = level;
        data["isShownData"] = isShown;
        return data;
    }
    public void RestoreState(object state)
    {
        Dictionary<string,object> data = (Dictionary<string,object>) state;
        level = (int)data["leveldata"];
        isShown = (bool)data["isShownData"];
    }
}
