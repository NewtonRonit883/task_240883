using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAIN_MENU : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    void Start()
    {
        animator = GameObject.FindGameObjectWithTag("logo").GetComponent<Animator>();
        Invoke("Logo_Anim", 4f);

    }

    // Update is called once per frame
    void Logo_Anim()
    {
        animator.SetTrigger("Start");
        Invoke("UI", 0.5f);

    }
    void UI()
    {
        transform.Find("Buttons").gameObject.SetActive(true);
        FindObjectOfType<AudioManager>().Play("music");

    }

    
    
}
