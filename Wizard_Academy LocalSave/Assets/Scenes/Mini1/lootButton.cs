using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lootButton : MonoBehaviour {

    private void Start()
    {
        GameObject.Find("LootButton").GetComponent<Button>().onClick.AddListener(() => { DiscardButton(); });
    }

    public void DiscardButton() {
        GameObject.Find("controller").GetComponent<Pause>().SwitchPause();
        GameObject.Find("LootInfo").transform.localScale = new Vector3(0, 0, 0);
    }
}
