
using UnityEngine;
using UnityEngine.SceneManagement;


public class story : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] scenes;
    int i = 0;
    void Start()
    {
        InvokeRepeating("Next_Scene", 2.5f, 6.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Next_Scene();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Last_Scene();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }    
    }
    void Next_Scene()
    {
        if (i == 7)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        scenes[i].gameObject.SetActive(false);
        i++;
    }
    void Last_Scene()
    {
        if (i!=0)
        {
            scenes[i-1].gameObject.SetActive(true);
            i--;
        }
    }
    
}
