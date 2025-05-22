
using UnityEngine;
using UnityEngine.SceneManagement;
public class NEXT1 : MonoBehaviour
{
    // Start is called before the first frame update
    public float DELAY=5f;
    void Start()
    {
        Invoke("Next_Scene", DELAY);
    }
    void Next_Scene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1) ;    
    }
}
