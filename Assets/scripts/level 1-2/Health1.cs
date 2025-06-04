using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health1 : MonoBehaviour
{
    // Start is called before the first frame update
    public int max_health = 5;
    private int current_HP;
    public Transform spawn;

    public List<GameObject> hearts = new List<GameObject>();
    void Start()
    {
        current_HP = max_health;
        Spawn_Hearts();

    }

    // Update is called once per frame
    void Spawn_Hearts()
    {
        for (int i = 0; i < max_health; i++)
        {
            GameObject newheart = hearts[i];
            newheart.transform.position = new Vector3(spawn.transform.position.x + i * 1.5f, spawn.transform.position.y, 0);


        }
    }



    public void TakeDamage(int damage)
    {
        current_HP -= damage;
        FindObjectOfType<AudioManager>().Play("hurt");
        if (current_HP < 0) current_HP = 0;
        UpdateHearts();
        if (current_HP <= 1)
        {
            FindObjectOfType<AudioManager>().Play("heartbeat");
        }
    }
    void UpdateHearts()
    {
        for (int i = max_health-1; i>=current_HP; i--)
        {
            hearts[i].SetActive(false);
        }
    }
}
