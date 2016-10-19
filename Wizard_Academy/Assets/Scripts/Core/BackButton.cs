using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour {

	public void ChangeScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
    }
}
