using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LaunchButton : MonoBehaviour
{
    public float requirement = 10f;
    private Button me;
    public Sprite Image1;
    public GameObject checking;
    void Start()
    {
        me = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if(requirement <= ClickManager.Instance.funds&&checking.activeInHierarchy)
        {
            me.interactable = true;
            me.GetComponent<Image>().sprite = Image1;
            me.onClick.RemoveAllListeners();
            me.onClick.AddListener(delegate{LaunchManager.Instance.Launching();ClickManager.Instance.PurchaseValue(requirement);});
        }
    }
    
}
