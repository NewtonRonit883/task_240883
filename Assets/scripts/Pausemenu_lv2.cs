
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu_lv2 : MonoBehaviour
{
    // Start is called before the first frame update
    private bool paused = false;
    public GameObject pause_menu;

    void Start()
    {
        pause_menu.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused) Resume();
            else Pause();
        }
    }
    public void Resume()
    {
        pause_menu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }
    public void Pause()
    {

        pause_menu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        paused = false;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void Quit()
    {
        Time.timeScale = 1f;
        paused = false;
        SceneManager.LoadScene("UI");
    }
    public void click()
    {
        FindObjectOfType<AudioManager>().Play("click");
    }
}
