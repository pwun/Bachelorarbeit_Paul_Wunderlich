using UnityEngine;
using System.Collections;

public class PlayerCreation : MonoBehaviour {

    Animator player;
    Animator head;
    Animator torso;

    bool Idle = true;

    int Head = 0;

    void Start()
    {
        player = GameObject.Find("Player Rig").GetComponent<Animator>();
        head = GameObject.Find("Head").GetComponent<Animator>();
        torso = GameObject.Find("Torso").GetComponent<Animator>();
    }

    public void AllsetTrigger(string Name)
    {
        player.SetTrigger(Name);
        head.SetTrigger(Name);
        torso.SetTrigger(Name);
    }

    public void SwitchIdle()
    {
        if (Idle) Idle = false;
        else Idle = true;

        player.SetBool("Idle", Idle);
        head.SetBool("Idle", Idle);
        torso.SetBool("Idle", Idle);
    }

    public void SetHead(int Value)
    {
        head.SetInteger("Head", Value);
    }

}
