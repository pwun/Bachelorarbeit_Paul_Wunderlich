using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Startmenu : MonoBehaviour
{
    public void Start()
    {
        GameObject.Find("Login_Button").GetComponent<Button>().onClick.AddListener(() => Login());

        /*printToFile("61.txt", "6#1", 6, 1);
        printToFile("62.txt", "6#2", 6, 1);
        printToFile("63.txt", "6#3", 6, 4);
        printToFile("64.txt", "6#4", 6, 4);
        printToFile("65.txt", "6#5", 6, 7);
        printToFile("66.txt", "6#6", 6, 7);
        printToFile("67.txt", "6#7", 6, 10);
        printToFile("68.txt", "6#8", 6, 10);

        printToFile("81.txt", "8#1", 6, 1);
        printToFile("82.txt", "8#2", 6, 1);
        printToFile("83.txt", "8#3", 6, 4);
        printToFile("84.txt", "8#4", 6, 4);
        printToFile("85.txt", "8#5", 6, 7);
        printToFile("86.txt", "8#6", 6, 7);
        printToFile("87.txt", "8#7", 6, 10);
        printToFile("88.txt", "8#8", 6, 10);*/
    }

    void printToFile(string path, string title, int _class, int _lvl) {
        System.IO.File.AppendAllText(@"C:\Users\Paul\Desktop\ausgabe\" + path, title+":\n\n");
        MathGenerator mg = new MathGenerator();
        Entry[] em = mg.GenerateList(_class, _lvl, 1);
        for (int i = 0; i < em.Length; i++)
        {
            em[i].printToFile(path);
        }
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