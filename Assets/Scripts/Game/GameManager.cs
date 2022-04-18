using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static float Opc;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        switch (ButtonManager.AnimSelect)
        {
            case 0:
                Opc = 0;
                break;
            case 1:
                Opc = 1;
                break;
            case 2:
                Opc = 2;
                break;
            case 4:
                Opc = 4;
                break;
        }
    }

}
