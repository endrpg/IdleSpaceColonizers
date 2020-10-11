using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    [TextArea(10,20)]
    public string[] sentences;
    public Sprite[] images;
    public Image Bg_Image; 
    private int index;
    public float typingSpeed = 0.02f;
    public GameObject continueButton;
    void Start()
    {
        StartCoroutine(Type());
    }
    void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }
    IEnumerator Type()
    {
        if(images[index] != null)
        {
            Bg_Image.sprite = images[index];
        }
        foreach (var letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    public void NextSentence()
    {
        continueButton.SetActive(false);
        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            SceneManager.LoadSceneAsync(0);
        }
    }
}
