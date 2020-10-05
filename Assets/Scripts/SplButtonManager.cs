using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SplButtonManager : MonoBehaviour
{
    private Button myButton;
    public GameObject gameObject;
    bool show= false;
    void Start()
    {
        myButton = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        myButton.onClick.RemoveAllListeners();
        myButton.onClick.AddListener(delegate{ShowUnshow();});
    }
    void ShowUnshow()
    {
        if(!show)
        {
            gameObject.SetActive(true);
            show = true;
        }
        else if(show)
        {
            gameObject.SetActive(false);
            show = false;
        }
    }
}
