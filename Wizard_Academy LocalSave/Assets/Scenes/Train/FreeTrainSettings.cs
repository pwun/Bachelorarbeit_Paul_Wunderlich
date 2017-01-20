using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FreeTrainSettings : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) SubmitSettings();
    }

    public void SubmitSettings()
    {
        Game.current.hero.Subject = "f";
        Game.current.hero.TrainTask = GameObject.Find("Sub_Dropdown").GetComponent<Dropdown>().value;
        //Change Scene
        SaveLoad.Save();
        SceneManager.LoadScene("Train");
    }
}
