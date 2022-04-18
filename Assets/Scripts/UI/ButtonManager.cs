using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public  static class ButtonExtension
{
    public static void AddEventListener<T>(this Button button, T param, Action<T> OnClick)
    {
        button.onClick.AddListener(delegate ()
        {
            OnClick(param);
        });
    }
}


public class ButtonManager : MonoBehaviour
{
    public int MyScene;

    public Animator Player;
    public static int AnimSelect = 4;

    [Serializable]
    public struct Buttons
    {
        public string NameButton;
        
    }
    [SerializeField] Buttons[] allButtons;

    void Start()
    {
        Player = GetComponent<Animator>();
        
        GameObject buttonTemplate = transform.GetChild(0).gameObject;
        GameObject g;

        int N = allButtons.Length;

        for (int i = 0; i < N; i++)
        {
            g = Instantiate(buttonTemplate, transform);
            g.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = allButtons[i].NameButton;

            g.GetComponent<Button>().AddEventListener(i, ItemClicked);

        }
        Destroy(buttonTemplate);
    }

    void ItemClicked(int itenIndex)
    {

        Debug.Log("Item "+itenIndex);

        AnimSelect = itenIndex;

    }

    public void Scene()
    {

        if (AnimSelect == 3)
        {
            SceneManager.LoadScene(MyScene);
        }

    }

    void Update()
    {
        Scene();
    }

}
