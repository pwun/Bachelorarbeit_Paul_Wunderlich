using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour {

	public void HELP(){
		//current.hero.scene = getSceneName();
		//save
		SceneManager.LoadScene ("HelpMenu");
	}
}
