using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchManager : MonoBehaviour
{
    private static LaunchManager instance;
    public static LaunchManager Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.Log("Not found");
            }
            return instance;
        }
    }

    public GameObject unshow1;
    public GameObject unshow2;
    public GameObject unshow3;
    public GameObject unshow4;
    public GameObject show1;

    // Things for default
    public GameObject show2;
    public GameObject unshow5;
    public GameObject unshow6;
    public GameObject unshow7;
    public GameObject unshow8;
    public GameObject unshow9;
    public GameObject unshow10;
    public GameObject unshow11;
    public GameObject unshow12;
    public GameObject unshow13;
    public GameObject unshow14;
    public GameObject unshow15;
    public GameObject unshow16;
    public GameObject unshow17;
    public GameObject unshow18;
    public GameObject unshow19;


// Buttons
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    public GameObject button6;
    public GameObject button7;
    public GameObject button8;
    public GameObject button9;
    public GameObject button10;
    public GameObject button11;
    public GameObject button12;
    public GameObject button13;
    public GameObject button14;
    public GameObject button15;
    public GameObject button16;
    public GameObject button17;
    public GameObject button18;
    public GameObject button19;
    public GameObject button20;
    public GameObject button21;
    public GameObject button22;
    public GameObject button23;
    public GameObject button24;
    public GameObject button25;
    public Animator anim;
    public AudioClip countdown;
    AudioSource audioSource;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Launching()
    {
        audioSource.PlayOneShot(countdown,0.7f);
        StartCoroutine(LaunchSound());
    }
    IEnumerator LaunchSound()
    {
        yield return new WaitForSeconds(10f);
        anim.SetTrigger("Launch");
        unshow1.SetActive(false);
        unshow2.SetActive(false);
        unshow3.SetActive(false);
        unshow4.SetActive(false);
        show1.SetActive(true);
        audioSource.Play();
        StartCoroutine(SettingDefault());
    }
    void ButtonUpgr(GameObject with)
    {
        with.GetComponent<Button_Upgr>().DefaultButtonUpgr();
    }
    void ManagerButtonUpgr(GameObject with)
    {
        with.GetComponent<ManagerButton_Upgr>().DefaultManagerButtonUpgr();
    }
    IEnumerator SettingDefault()
    {
        Debug.Log("Running");
        yield return new WaitForSeconds(14.5f);
        Debug.Log("Ok");
        ClickManager.Instance.clickDefault = true;
        ClickManager.Instance.profitBonus += 1;
        audioSource.Stop();
        show2.SetActive(true);
        ButtonUpgr(button1);
        ButtonUpgr(button2);
        ButtonUpgr(button3);
        ButtonUpgr(button4);
        ButtonUpgr(button5);
        ButtonUpgr(button6);
        ButtonUpgr(button7);
        ButtonUpgr(button8);

        ManagerButtonUpgr(button9);
        ManagerButtonUpgr(button10);
        ManagerButtonUpgr(button11);
        ManagerButtonUpgr(button12);
        ManagerButtonUpgr(button13);
        ManagerButtonUpgr(button14);
        ManagerButtonUpgr(button15);
        ManagerButtonUpgr(button16);
        ManagerButtonUpgr(button17);
        ManagerButtonUpgr(button18);
        ManagerButtonUpgr(button19);
        ManagerButtonUpgr(button20);
        ManagerButtonUpgr(button21);
        ManagerButtonUpgr(button22);
        ManagerButtonUpgr(button23);
        ManagerButtonUpgr(button24);
        ManagerButtonUpgr(button25);
        unshow5.SetActive(false);
        unshow6.SetActive(false);
        unshow7.SetActive(false);
        unshow8.SetActive(false);
        unshow9.SetActive(false);
        unshow10.SetActive(false);
        unshow11.SetActive(false);
        unshow12.SetActive(false);
        unshow13.SetActive(false);
        unshow14.SetActive(false);
        unshow15.SetActive(false);
        unshow16.SetActive(false);
        unshow17.SetActive(false);
        unshow18.SetActive(false);
        unshow19.SetActive(false);
        Debug.Log("all Intit");
    }
}
