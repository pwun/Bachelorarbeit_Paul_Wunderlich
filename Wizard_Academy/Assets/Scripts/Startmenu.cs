using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Startmenu : MonoBehaviour
{

    public void Login()
    {
        SceneManager.LoadScene("Login");
    }
    public void Signup()
    {
        SceneManager.LoadScene("Signup");
    }
}