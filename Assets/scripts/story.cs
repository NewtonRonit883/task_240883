
using UnityEngine;
using UnityEngine.SceneManagement;


public class story : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] scenes;
    int i = 0;
    void Start()
    {
        InvokeRepeating("Next_Scene", 8f, 8f);
    }

    // Update is called once per frame
    void Update()
    {
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
}
