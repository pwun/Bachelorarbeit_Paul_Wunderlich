using UnityEngine;
using System.Collections;

public class PlayerCreation : MonoBehaviour {

    Animator player;
    Animator head;
    Animator armor;
    UserData data;

    bool Idle = true;

    int Head = 0;
    int nrHeads = 6;

    int Armor = 0;
    int nrArmors = 5;

    void Start()
    {
        data = GameObject.Find("User_Data").GetComponent<UserData>();
        player = GameObject.Find("Player Rig").GetComponent<Animator>();
        head = GameObject.Find("Head").GetComponent<Animator>();
        armor = GameObject.Find("Armor").GetComponent<Animator>();
        //Head = data.head_nr;
        //Armor = data.armor_nr;
        //nr head_pos & armor_pos
        SetArmor(Armor);
        SetHead(Head);
    }

    public void refresh()
    {
        if (data.head_nr != 0 && data.armor_nr != 0)
        {
            Head = data.head_nr;
            Armor = data.armor_nr;
            SetArmor(Armor);
            SetHead(Head);
            Debug.Log("Refreshed");
        }
        Debug.Log("Refresh cancelled");
    }

    public void SetItems(int armor_nr, int head_nr)
    {
        Debug.Log("Charakter einkleiden:" + armor_nr + ", " + head_nr+".....");
        Armor = armor_nr;
        Head = head_nr;
        armor.SetInteger("Armor", Armor);
        head.SetInteger("Head", Head);
    }

    public void AllsetTrigger(string Name)
    {
        player.SetTrigger(Name);
        head.SetTrigger(Name);
        armor.SetTrigger(Name);
    }

    public void SwitchIdle()
    {
        if (Idle) Idle = false;
        else Idle = true;

        player.SetBool("Idle", Idle);
        head.SetBool("Idle", Idle);
        armor.SetBool("Idle", Idle);
    }

    public void SetHead(int i)
    {
        Debug.Log("Kopf einkleiden:" + i + ".....");
        head.SetInteger("Head", i);
    }

    public void SetArmor(int i)
    {
        Debug.Log("Rüstung einkleiden:" + i + ".....");
        armor.SetInteger("Armor", i);
    }

    public void AddHead(int Value)
    {
        Idle = false;
        SwitchIdle();
        head.SetInteger("Head", 0);
        if (Value == 1 && Head < nrHeads)
        {
            Head++;
        }
        else if (Value == 0 && Head > 0)
        {
            Head--;
        }
        head.SetInteger("Head", Head);
    }

    public void AddArmor(int Value)
    {
        Idle = false;
        SwitchIdle();
        armor.SetInteger("Armor", 0);
        if (Value == 1 && Armor < nrArmors)
        {
            Armor++;
        }
        else if (Value == 0 && Armor > 0)
        {
            Armor--;
        }
        armor.SetInteger("Armor", Armor);
    }

}
