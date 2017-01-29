using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossSettings : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {
        /*string text;
        string bossName;
        switch (Game.current.hero.Level) {
            case 3:
                bossName = "Forstos der Sprößling";
                text = "";
                break;
            case 6:
                bossName = "Swampus der Hinterlistige";
                text = "Beschreibung des 2. Gegners";
                break;
            case 9:
                bossName = "Frostos - Eismagier";
                text = "Beschreibung des 3. Gegners";
                break;
            case 12:
                bossName = "Magmarus - Lavadrache";
                text = "Beschreibung des 4. Gegners";
                break;
            default:
                bossName = "Forstos - Waldmagier";
                text = "Beschreibung des Gegners";
                break;
        }
        GameObject.Find("Text2").GetComponent<Text>().text = text;
        GameObject.Find("Title").GetComponent<Text>().text = bossName;*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) SubmitSettings();
    }

    public void SubmitSettings()
    {
        /*if (GameObject.Find("Sub_Dropdown").GetComponent<Dropdown>().value == 0)
        {
            Game.current.hero.Subject = "e";
        }
        else
        {
            Game.current.hero.Subject = "m";
        }*/
        //Change Scene
        SaveLoad.Save();
        SceneManager.LoadScene("Boss");
    }
}
