using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    public int maxHP = 100;
    int currentHP;
    private Rigidbody2D rb;

    public float kb_force = 5f;
    
    
    //public slime_movement movement;
    void Start()
    {
        currentHP = maxHP;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        //if (!isdead) return;
        currentHP -= damage;
        animator.SetTrigger("Hurt");
        GetComponent<slime_movement>().enabled = false;
        if (currentHP > 0)
        {

            Invoke("wait", 1f);
        }
        GameObject attacker = GameObject.Find("player2");
        Vector2 atk_pos = attacker.GetComponent<Transform>().position;
        knockback(atk_pos);
        if (currentHP <= 0)
        {
            rb.velocity = Vector2.zero;
            Die();
        }
    }
    void knockback(Vector2 atkpos)
    {
        //Reset any exisiting velocity
        rb.velocity = Vector2.zero;
        //if (currentHP>0) GetComponent<slime_movement>().enabled = false;
        Vector2 kb_dir = (transform.position - (Vector3)atkpos).normalized; //makes mag=1
        rb.AddForce(new Vector2(kb_dir.x * kb_force, 3f), ForceMode2D.Impulse);
        //if (currentHP>0) Invoke("wait", 0.5f);
    }
    void wait()
    {
        GetComponent<slime_movement>().enabled = true;
    }
    void Die()
    {
        //isdead = true;
        animator.SetBool("Isdead", true);
        rb.bodyType = RigidbodyType2D.Static;
        //GetComponent<slime_movement>().enabled = false;
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 2f);     
    }
}
