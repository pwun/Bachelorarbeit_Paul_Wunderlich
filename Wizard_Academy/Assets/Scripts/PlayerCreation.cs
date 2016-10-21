using UnityEngine;
using System.Collections;

public class PlayerCreation : MonoBehaviour {

    /*Animator player;
    Animator head;
    Animator armor;
    UserData data;

    bool Idle = true;

    public int Head = 0;
    int HeadNr = 0;
    int nrHeads = 5;

    public int Armor = 0;
    int ArmorNr = 0;
    int nrArmors = 4;

    void Start()
    {
        data = GameObject.Find("User_Data").GetComponent<UserData>();
        player = GameObject.Find("Player Rig").GetComponent<Animator>();
        head = GameObject.Find("Head").GetComponent<Animator>();
        armor = GameObject.Find("Armor").GetComponent<Animator>();
        if (data.head_nr < 0) Head = 0;
        else Head = data.head_nr;
        if (data.armor_nr < 0) Armor = 0;
        else Armor = data.armor_nr;
        //nr head_pos & armor_pos
        SetArmor(Armor);
        SetHead(Head);
        nrArmors = data.armor_pos.Length;
        nrHeads = data.head_pos.Length;
    }

    public void Save()
    {
        data.armor_nr = Armor;
        data.head_nr = Head;
        data.Save("Main");
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
        Head = i;
        head.SetInteger("Head", Head);
    }

    public void SetArmor(int i)
    {
        Debug.Log("Rüstung einkleiden:" + i + ".....");
        Armor = i;
        armor.SetInteger("Armor", Armor);
    }

    public void SetDead(bool val)
    {
        player.SetBool("Dead", val);
        head.SetBool("Dead", val);
        armor.SetBool("Dead", val);
    }

    public void AddHead(int Value)
    {
        Idle = true;
        if (Value == 1 && HeadNr < nrHeads)
        {
            HeadNr++;
            Head = System.Int32.Parse(""+data.head_pos[HeadNr-1]);
        }
        else if (Value == 0 && HeadNr > 1)
        {
            HeadNr--;
            Head = System.Int32.Parse(""+data.head_pos[HeadNr-1]);

        }
        head.SetInteger("Head", Head);
    }

    public void AddArmor(int Value)
    {
        Idle = true;
        if (Value == 1 && ArmorNr < nrArmors)
        {
            ArmorNr++;
            Armor = System.Int32.Parse("" + data.armor_pos[ArmorNr - 1]);
        }
        else if (Value == 0 && ArmorNr > 1)
        {
            ArmorNr--;
            Armor = System.Int32.Parse("" + data.armor_pos[ArmorNr - 1]);
        }
        armor.SetInteger("Armor", Armor);
    }*/

}
