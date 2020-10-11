using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TutorialButton : MonoBehaviour
{
    Button me;
    // Start is called before the first frame update
    void Start()
    {
        me = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        me.onClick.RemoveAllListeners();
        me.onClick.AddListener(delegate{TransportingToTutorial();});
    }
    void TransportingToTutorial()
    {
        SceneManager.LoadSceneAsync(3);
    }
}
