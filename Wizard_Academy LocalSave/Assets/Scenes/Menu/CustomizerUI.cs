using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CustomizerUI : MonoBehaviour {

	Player player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player").GetComponent<Player>();

		GameObject.Find ("Walk").GetComponent<Button> ().onClick.AddListener (() => player.Do ("Walk"));
		GameObject.Find ("Attack").GetComponent<Button> ().onClick.AddListener (() => player.Do ("Attack"));
		GameObject.Find ("Hurt").GetComponent<Button> ().onClick.AddListener (() => player.Do ("Hurt"));
		GameObject.Find ("Die").GetComponent<Button> ().onClick.AddListener (() => player.Do ("Die"));

		GameObject.Find ("Refresh").GetComponent<Button> ().onClick.AddListener (() => refresh());

        //set all button methods

        //enable all selectable items
	}

    public void Save(string scene)
    {
        SaveLoad.Save();
        SceneManager.LoadScene(scene);
    }
	
	void refresh(){
		player.Refresh ();
	}

    public void setTorso(int val)
    {
        Game.current.hero.Torso = val;
        player.SetAppearance("Torso", val);
    }
    public void setBody(int val)
    {
        Game.current.hero.Body = val;
        player.SetAppearance("Body", val);
    }
    public void setHair(int val)
    {
        Game.current.hero.Hair = val;
        player.SetAppearance("Hair", val);
    }
    public void setFeet(int val)
    {
        Game.current.hero.Feet = val;
        player.SetAppearance("Feet", val);
    }
    public void setLegs(int val)
    {
        Game.current.hero.Legs = val;
        player.SetAppearance("Legs", val);
    }
    public void setArms(int val)
    {
        Game.current.hero.Arms = val;
        player.SetAppearance("Arms", val);
    }
    public void setHands(int val)
    {
        Game.current.hero.Hands = val;
        player.SetAppearance("Hands", val);
    }
    public void setHelmet(int val)
    {
        Game.current.hero.Helmet = val;
        player.SetAppearance("Helmet", val);
    }
    public void setBelt(int val)
    {
        Game.current.hero.Belt = val;
        player.SetAppearance("Belt", val);
    }

    public void unlock(string button)
    {
        GameObject.Find(button).GetComponent<Button>().interactable = true;
    }
}
