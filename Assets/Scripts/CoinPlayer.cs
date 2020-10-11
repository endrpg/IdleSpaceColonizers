using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPlayer : MonoBehaviour
{
    public Object coin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InstantiateAndDestroy(Vector2 positionCoin)
    {
        var Coin = (GameObject)Instantiate(coin,positionCoin,Quaternion.identity);
        Coin.transform.SetParent(gameObject.transform,false);
        Destroy(Coin,2f);
    }
}
