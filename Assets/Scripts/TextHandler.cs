using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextHandler : MonoBehaviour
{
    public void TextHandlerFunc(TextMeshProUGUI myText, float minimumRequirements)
    {
        if(minimumRequirements/1000 >= 1 && minimumRequirements/1000 < 1000)
        {
            myText.text = RoundOff(minimumRequirements/1000) + "K" ;
        }
        else if(minimumRequirements/1000000 >= 1 && minimumRequirements/1000000 < 1000)
        {
            myText.text = RoundOff(minimumRequirements/1000000) + "M";
        }
        else if( minimumRequirements/1000000000 >= 1 && minimumRequirements/1000000000 < 1000)
        {
            myText.text = RoundOff(minimumRequirements/10000000000) + "B";
        }
        else if(minimumRequirements/(float)Mathf.Pow(10,12) >= 1 && minimumRequirements/(float)Mathf.Pow(10,12) < 1000)
        {
            myText.text = RoundOff(minimumRequirements/(float)Mathf.Pow(10,13)) + "T";
        }
        else
        {
            myText.text = RoundOff(minimumRequirements) + "$";
        }
    }
    float RoundOff(float toRound)
    {
        return (float)System.Math.Round(toRound,2);
    }
}
