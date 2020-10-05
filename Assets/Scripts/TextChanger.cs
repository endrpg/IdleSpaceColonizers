using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class TextChanger : MonoBehaviour
{
    TextMeshProUGUI myText;
    float change = 0;
    void Start()
    {
        myText = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        change += 1*Time.deltaTime;
        if(change >= 0 &&change < 1)
        {
            myText.text = "Registering company Info...";
        }
        else if(change >= 1 &&change < 2)
        {
            myText.text = "Getting Company Database...";
        }
        else if(change >= 2 &&change < 3)
        {
            myText.text = "Logging Into database...";
        }
        else if(change >= 3 && change < 4)
        {
            myText.text = "Database extraction...";
        }
        else
        {
            change = 0;
        }
    }
}
