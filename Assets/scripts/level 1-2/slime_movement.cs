
using UnityEngine;

public class slime_movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2f;

    public float atk_speed = 4f;
    public float att_range = 7f;
    
    private Rigidbody2D rigidb;
    private Animator anim;
    public Transform right_end;
    public Transform left_end;
    private bool moving = false; //true for right and false for left
    private SpriteRenderer spriter;
    public Vector3 offset;
    private Transform Player;
    float current_speed;

    void Start()
    {
        rigidb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();

        Player = GameObject.FindGameObjectWithTag("Player").transform;
        current_speed = speed;
        right_end = GameObject.FindGameObjectWithTag("right_end").GetComponent<Transform>();
        left_end = GameObject.FindGameObjectWithTag("left_end").GetComponent<Transform>();
        transform.position = new Vector3(right_end.position.x, transform.position.y, 0) - offset;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = Mathf.Abs(transform.position.x - Player.position.x);

        if (dist <= att_range)
        {
            anim.SetBool("Attack", true);
            current_speed = atk_speed;
        }
        else
        {
            anim.SetBool("Attack", false);
            current_speed = speed;
        }



        if (!moving)
        {
            rigidb.velocity = new Vector2(-current_speed * Time.fixedDeltaTime, rigidb.velocity.y);
            spriter.flipX = false;
            if (transform.position.x <= left_end.position.x + offset.x)
                moving = true;
        }
        else
        {
            rigidb.velocity = new Vector2(current_speed * Time.fixedDeltaTime, rigidb.velocity.y);
            spriter.flipX = true;
            if (transform.position.x >= right_end.position.x - offset.x)
                moving = false;
        }
    }
    
}
