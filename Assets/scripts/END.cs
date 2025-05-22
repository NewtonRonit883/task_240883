
using UnityEngine;
using UnityEngine.SceneManagement;
public class END : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Transform cave;
    public GameObject end;

    void Start()
    {
        Invoke("Black", 1f);
    }
    void Black()
    {
        end.SetActive(false);
    }    
    void Update()
    {
        if (cave.position.x - player.position.x <= 5f && slimes_dead())
        {

            END1();
        }

    }
    private bool slimes_dead()
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
    public void END1()
    {
        player.GetComponent<playermovement>().enabled = false;
        player.GetComponent<Animator>().SetFloat("Speed", 1f);
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(1.5f, player.GetComponent<Rigidbody2D>().velocity.y);

        if (!FindObjectOfType<AudioManager>().isPlaying("win"))
            FindObjectOfType<AudioManager>().Play("win");
        end.SetActive(true);
        end.GetComponent<Animator>().SetBool("End", true);


        Invoke("THE_END", 1.75f);
    }
    public void THE_END()
    {
        player.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

    }
}
