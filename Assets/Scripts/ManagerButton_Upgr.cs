using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GameDevTV.Saving;
[RequireComponent(typeof(AudioSource))]
public class ManagerButton_Upgr : MonoBehaviour,ISaveable
{
    Button me;
    public TextMeshProUGUI myText;
    public bool isDone = false;
    public float requirement = 10f;
    // This is the variable used to modify the inactive funding
    public float addingInactiveFunding = 2f;
    public GameObject toShow;
    public bool isShown;
    public TextHandler textHandler;
    AudioSource audioSorce;
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
        UpdateText();
        if(!isDone && requirement <= ClickManager.Instance.funds)
        {
            me.interactable = true;
            me.onClick.RemoveAllListeners();
            me.onClick.AddListener(delegate{PurchasingInactiveFunding();isDone = true;ManagingInstantiation();audioSorce.Play();});
        }
        else
        {
            me.interactable = false;
        }
    }
    void ManagingInstantiation()
    {
        /*if(!isInstantiated && toInstantiate != null)
        {
            GameObject instantiatedObjectq = (GameObject)Instantiate(toInstantiate,whereInstantiate,Quaternion.identity);
            isInstantiated = true;
            if(parentOfInstantiate != null)
            {
                instantiatedObjectq.transform.SetParent(parentOfInstantiate.transform,false);
            }
        }*/
        if(toShow != null)
        {
            if(!isShown)
            {
                toShow.SetActive(true);
                isShown = true;
            }
        }
    }
    void PurchasingInactiveFunding()
    {
        ClickManager.Instance.PurchaseValue(requirement);
        PurchasingInactiveFundings();
    }
    void UpdateText()
    {
        textHandler.TextHandlerFunc(myText,requirement);
    }
    public void DefaultManagerButtonUpgr()
    {
        isShown = false;
        isDone = false;
    }
    public object CaptureState()
    {
        Dictionary<string,object> data = new Dictionary<string,object>();
        data["isDoneData"] = isDone;
        data["isShownData"] = isShown;
        return data;
    }
    void PurchasingInactiveFundings()
    {
        ClickManager.Instance.AddInactiveFunding(addingInactiveFunding);
    }
    public void RestoreState(object state)
    {
        Dictionary<string,object> data = (Dictionary<string,object>) state;
        isDone = (bool)data["isDoneData"];
        isShown = (bool)data["isShownData"];
    }
}
