using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public bool paused;
    GameObject Character;
    GameObject Hearts;

	// Use this for initialization
	void Start () {
        Character = GameObject.Find("Player");
        Hearts = GameObject.Find("Lifes");
        paused = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (paused)
        {
            Time.timeScale = 0;
            Character.transform.localScale = new Vector3(0, 0, 0);
            Hearts.SetActive(false);
        }
        else {
            Time.timeScale = 1;
            Character.transform.localScale = new Vector3(300, 300, 1);
            Hearts.SetActive(true);
        }
        
	}

    public void ForcePause() {
        paused = true;
    }

    public void SwitchPause()
    {
        paused = !paused;
    }
}
