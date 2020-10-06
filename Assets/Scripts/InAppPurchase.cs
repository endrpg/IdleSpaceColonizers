using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
public class InAppPurchase : MonoBehaviour
{
    ClickManager clickManager;
    public int gemstoGive = 100;
    void Start()
    {
        clickManager = GameObject.Find("Play Area").GetComponent<ClickManager>();
    }
    public void OnPurchaseComplete(Product product)
    {
        clickManager.gems += gemstoGive;
    }
    public void OnPurchaseFailure(Product product,PurchaseFailureReason reason)
    {
        Debug.Log("Failure");
    }
}
