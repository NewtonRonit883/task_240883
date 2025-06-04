using UnityEngine;
using UnityEngine.SceneManagement;
public class next2 : MonoBehaviour
{
    public float delay = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Next_Scene1", delay);
    }

    // Update is called once per frame
    void Next_Scene1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }
}

