
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_s : MonoBehaviour
{
    // Start is called before the first frame update

    public void Start1()
    {
        FindObjectOfType<AudioManager>().Play("Click");

        Invoke("Game", 0.5f);

    }
    void Game()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QUIT()
    {
        FindObjectOfType<AudioManager>().Play("Click");

        Application.Quit();

    }
    public void credits()
    {
        transform.Find("mainmenu").transform.Find("creds").gameObject.SetActive(true);
        transform.Find("Buttons").gameObject.SetActive(false);
    }
    public void cross()
    {
        transform.Find("mainmenu").transform.Find("creds").gameObject.SetActive(false);
        transform.Find("Buttons").gameObject.SetActive(true);
    }

    // Update is called once per frame

}
