using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class playermovement : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Attack")]
    public Transform atk_pt1;  //attack point
    public Transform atk_pt2;
    Vector3 atk_pt;
    public float atk_r = 1f;  //attack range
    public LayerMask enemyLayers;

    [Header("Movement")]
    public float speed = 5f;
    public float jump = 5f;
    float dir = 0f;
    [Space]
    public int health = 5;
    private int current_HP;
    [Space]
    private Rigidbody2D rigidb;
    private Animator animator;
    private SpriteRenderer spriter;
    bool grounded = true;
    bool Ckey = false; //Not pressed
    public int atk_Damage = 100;
    private AudioManager AudioManager;
    //bool facingRight = true;
    void Start()
    {
        rigidb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
        AudioManager = FindObjectOfType<AudioManager>();
        atk_pt = atk_pt1.position;
        
        current_HP = health;
    }

    // Update is called once per frame
    public void LEFT_BUTTON()
    {
        dir = -1f;
    }
    public void RIGHT_BUTTON()
    {
        dir = 1f;
    }
    public void STOP_RUNNING()
    {
        dir = 0f;
    }
    void Update()
    {
        dir = Input.GetAxis("Horizontal");
        Flip(dir);
        
        if (dir != 0)
        {
            if (!AudioManager.isPlaying("running")) 
                AudioManager.Play("running");
        }
        else
        {
            if (AudioManager.isPlaying("running"))
                AudioManager.Stop("running");
        }
        
        animator.SetFloat("Speed", Mathf.Abs(dir));

        if (!grounded) AudioManager.Stop("running");
        if (Input.GetButtonDown("Jump") && grounded)
        {
            Jump();
        }
        if (Input.GetKeyDown("c"))
        {
            if (!Ckey) { Ckey = true; animator.SetBool("crouch", Ckey); }
            else { Ckey = false; animator.SetBool("crouch", Ckey); }
        }
        if (Input.GetKeyDown("e"))
        {
            
            Attack();
        }


        /*if (grounded)
        {
            grounded = true;
            animator.SetBool("grounded", grounded);
            animator.SetBool("Jump", false);
        }*/

    }
    private void FixedUpdate()
    {
        float movex = dir * speed;
        rigidb.velocity = new Vector2(movex * Time.fixedDeltaTime, rigidb.velocity.y);

    }
    public void Jump()
    {
        if (grounded)
        {
            rigidb.velocity = new Vector2(rigidb.velocity.x, jump);

            grounded = false;
            animator.SetBool("grounded", grounded);
            animator.SetBool("Jump", true);
            AudioManager.Play("jump");
        }
        
    }
    void Flip(float move)
    {
        
        if (move > 0)
        {
            spriter.flipX = false;

            atk_pt = atk_pt1.position;
        }
        else if (move < 0)
        {
            spriter.flipX = true;
            atk_pt = atk_pt2.position;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            grounded = true;
            animator.SetBool("grounded", grounded);
            animator.SetBool("Jump", false);
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SLIME1"))
        {
            current_HP -= 1;
            GetComponent<Health1>().TakeDamage(1);
            GetComponent<collision>().SlimeDamage(current_HP, collision.transform);
            //GetComponent<collision>().knockback(collision.transform);

        }
        if (collision.CompareTag("BOSS"))
        {
            current_HP -= 2;
            GetComponent<Health1>().TakeDamage(2);
            GetComponent<collision>().SlimeDamage(current_HP, collision.transform);
        }
    }
    

    public void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] Enemies = Physics2D.OverlapCircleAll(atk_pt, atk_r, enemyLayers);
        AudioManager.Play("sword");
        foreach (Collider2D enemy in Enemies)
        {
            Debug.Log("Enemy Hurt");
            enemy.GetComponent<Enemy>().TakeDamage(atk_Damage);
        }

    }

    void OnDrawGizmosSelected()
    {
        if (atk_pt == null) return;
        Gizmos.DrawWireSphere(atk_pt, atk_r);   
    }

    
}
