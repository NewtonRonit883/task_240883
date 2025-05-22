using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class speech : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform speech1;
    public Transform speech2;
    public Transform warning;
    void Start()
    {
        Invoke("speech11", 1f);
    }

    void speech11()
    {
        speech1.gameObject.SetActive(true);
        Invoke("speech22", 3f);
    }
    void speech22()
    {
        speech1.gameObject.SetActive(false);
        speech2.gameObject.SetActive(true);
        Invoke("close", 3f);
    }
    void close()
    {
        speech1.gameObject.SetActive(false);
        speech2.gameObject.SetActive(false);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "right_end")
        {
            warning.gameObject.SetActive(true);
            this.enabled = false;
        }   
    }
    // Update is called once per frame

}
