using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class level_win : MonoBehaviour
{
    // Start is called before the first frame update
    public void Menu()
    {
        SceneManager.LoadScene("UI");
    }
    public void Retry1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-2);
    }
    public void Retry2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
    // Update is called once per frame
    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);       
    }
    
}
