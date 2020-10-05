using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GameDevTV.Saving;
public class LoadingScript : MonoBehaviour
{
    public Button me;
    public bool loadLastScene = false;
    void Start()
    {
        me = GetComponent<Button>();
    }
    void Update()
    {
        if(!loadLastScene && me != null)
        {
            me.onClick.RemoveAllListeners();
            me.onClick.AddListener(delegate{SceneManager.LoadScene(1);});
        }
        else if(loadLastScene)
        {
            StartCoroutine(LoadLast());
        }
    }
    IEnumerator LoadLast()
    {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(2);
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
    }
}
