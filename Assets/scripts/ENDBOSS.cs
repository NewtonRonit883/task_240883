using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENDBOSS : MonoBehaviour
{
    public GameObject slime_boss;
    
    public Transform Audio;
    // Start is called before the first frame update
    int count = 0;
    void Start()
    {
        
    }
    void Update()
    {
        if (check_slimes() && count==0 && FindObjectOfType<slime_spawnerlv2>().count!=12 && Time.timeScale==1f)
        {
            slime_boss.SetActive(true);
            Audio.GetComponent<AudioSource>().Stop();
            FindObjectOfType<AudioManager>().Play("BOSS");

            count++;
        }
    }   
    private bool check_slimes()
    {
        GameObject[] slimes = GameObject.FindGameObjectsWithTag("SLIME1");
        bool allSlimesDead = true;
        foreach (GameObject slime in slimes)
        {
            if (slime != null && slime.activeInHierarchy)
            {
                allSlimesDead = false;
                break;
            }
        }
        if (allSlimesDead == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    // Update is called once per frame
    
}
