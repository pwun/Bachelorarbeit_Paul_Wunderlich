﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mini1_Player : MonoBehaviour {

    int rowNr = 1;
    int rowGap = 180;
    int jumpHeight = 70;
    int jumpLength = 150;
    bool attacking = false;
    public bool running = false;
    Rigidbody2D Player;

    UserData data;
    Mini1 game;
    Player anim;

    // Use this for initialization
    void Start () {
        //Animator start running animation
        data = GameObject.Find("User_Data").GetComponent<UserData>();
        GameObject.Find("Name_Display").GetComponent<Text>().text = data.name;
        //Fetch Questions
        //Set first Question
        game = GameObject.Find("EventSystem").GetComponent<Mini1>();
        Player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        anim = GetComponent<Player>();
        //Get Item Types
        //anim.SetArmor(), Head
    }
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
		if (Input.GetAxisRaw("Vertical")>0)
        {
            RowUp();
        }
		if (Input.GetAxisRaw("Vertical")<0)
        {
            RowDown();
        }
    }

    public void StartAnimation()
    {
		anim.Do("Walk");
    }

    public int GetRowNumber()
    {
        return rowNr;
    }

    void RowUp()
    {
        if (rowNr < 3)
        {
            rowNr++;
            Vector3 position = this.transform.position;
            position.y+=rowGap;
            this.transform.position = position;
        }
    }

    void RowDown()
    {
        if(rowNr > 1)
        {
            rowNr--;
            Vector3 position = this.transform.position;
            position.y -= rowGap;
            this.transform.position = position;
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("Hit: " + coll.gameObject.tag);
        switch (coll.gameObject.tag)
        {
            case "Answer":
                game.Answer(rowNr);
                break;
            case "Enemy":
                if (attacking) Destroy(coll.gameObject);
                else game.Hurt();
                break;
            case "Obstacle":
                game.Hurt();
                break;
        }
    }

    public void LoseLife()
    {
		anim.Do("Hurt");
    }

    public void Kill()
    {
		anim.Do("Die");
    }

    public void Attack()
    {
        attacking = true;
		anim.Do("Attack");
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.6f);
        attacking = false;
    }
}
