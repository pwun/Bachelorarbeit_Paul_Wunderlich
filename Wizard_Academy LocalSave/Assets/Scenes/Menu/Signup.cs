using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Signup : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        GameObject.Find("Username_Input").GetComponent<InputField>().Select();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) SubmitRegister();
    }

    public void SubmitRegister()
    {
        int classLevel = GameObject.Find("Dropdown").GetComponent<Dropdown>().value;
        switch (classLevel)
        {
            case 0:
                classLevel = 6;
                break;
            case 1:
                classLevel = 8;
                break;
        }
        Game game = new Game(GameObject.Find("Username_Input").GetComponent<InputField>().text, classLevel);
        Game.current = game;
        SaveLoad.Save();
        SceneManager.LoadScene("Customizer");
    }
}
