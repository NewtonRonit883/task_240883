
using UnityEngine;
using UnityEngine.SceneManagement;
public class END_lv2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Transform cave;


    void Start()
    {
        FindObjectOfType<AudioManager>().Stop("win");
        Invoke("Black", 1f);
    }
    void Black()
    {
        GameObject.FindGameObjectWithTag("end").SetActive(false);
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
        //GameObject.FindGameObjectWithTag("end").SetActive(true);
        //GameObject.FindGameObjectWithTag("end").GetComponent<Animator>().SetBool("End", true);


        Invoke("THE_END", 2f);
    }
    public void THE_END()
    {
        player.gameObject.SetActive(false);
        SceneManager.LoadScene("LEVEL2_WIN");

    }
}
