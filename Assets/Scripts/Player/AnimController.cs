using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    public Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.Opc)
        {
            case 0:
                Anim.Play("Macarena Dance");
                break;
            case 1:
                Anim.Play("House Dancing");
                break;
            case 2:
                Anim.Play("Wave Hip Hop Dance");
                break;            
            case 4:
                Anim.Play("Idle");
                break;
        }
    }
}
