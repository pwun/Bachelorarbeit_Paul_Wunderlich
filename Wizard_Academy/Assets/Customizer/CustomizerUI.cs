using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
        player.Save("Main");
    }
	
	void refresh(){
		player.Refresh ();
	}

    public void setTorso(int val)
    {
        player.torso = val;
        player.SetAppearance("Torso", val);
    }
    public void setBody(int val)
    {
        player.body = val;
        player.SetAppearance("Body", val);
    }
    public void setHair(int val)
    {
        player.hair = val;
        player.SetAppearance("Hair", val);
    }
    public void setFeet(int val)
    {
        player.feet = val;
        player.SetAppearance("Feet", val);
    }
    public void setLegs(int val)
    {
        player.legs = val;
        player.SetAppearance("Legs", val);
    }
    public void setArms(int val)
    {
        player.arms = val;
        player.SetAppearance("Arms", val);
    }
    public void setHands(int val)
    {
        player.hands = val;
        player.SetAppearance("Hands", val);
    }
    public void setHelmet(int val)
    {
        player.helmet = val;
        player.SetAppearance("Helmet", val);
    }
    public void setBelt(int val)
    {
        player.belt = val;
        player.SetAppearance("Belt", val);
    }

    public void unlock(string button)
    {
        GameObject.Find(button).GetComponent<Button>().interactable = true;
    }
}
