using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Startmenu : MonoBehaviour
{
    public void Start()
    {
        GameObject.Find("Login_Button").GetComponent<Button>().onClick.AddListener(() => Login());
    }

    void Login()
    {
        SaveLoad.Load();
        if (SaveLoad.savedGames.Count < 1)
        {
            SceneManager.LoadScene("Signup");
        }
        else
        {
            Game.current = SaveLoad.savedGames[SaveLoad.savedGames.Count - 1];
            int answer = -1;
            answer = Log.LogEntry("Login");
            while (answer < 0)
            { //Wait
            }
            SceneManager.LoadScene("Main");
        }
        //SceneManager.LoadScene("Signup");
    }

    public void Quit()
    {
        Application.Quit();
    }
}