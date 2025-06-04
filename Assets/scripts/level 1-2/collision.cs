
using UnityEngine;
using UnityEngine.SceneManagement;
public class collision : MonoBehaviour
{
    public float knockback_force = 5f;
    private Animator animator;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void SlimeDamage(int HP,Transform slime)
    {

        animator.SetTrigger("Collide");
        FindObjectOfType<AudioManager>().Play("hurt");
        knockback(slime.position);
        if (HP <= 0)
        {
            animator.SetBool("isDead", true);
            FindObjectOfType<AudioManager>().Play("gameover");
            Invoke("GAMEOVER", 1.5f);
        }

    }
    public void knockback(Vector2 slime)
    {
        rb.velocity = Vector2.zero;
        Vector2 dir = (transform.position - (Vector3)slime).normalized;
        rb.AddForce(new Vector2(dir.x * knockback_force, 5f), ForceMode2D.Impulse);
    }
    private void GAMEOVER()
    {
        levelmanager.lastlvname = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("GAMEOVER");
    }
}
