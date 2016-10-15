using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mini1_Player : MonoBehaviour {

    int rowNr = 1;
    int rowGap = 100;
    int jumpHeight = 70;
    int jumpLength = 150;
    bool jumping = false;
    Rigidbody2D Player;

    UserData data;
    Mini1 game;


	// Use this for initialization
	void Start () {
        //Animator start running animation
        data = GameObject.Find("User_Data").GetComponent<UserData>();
        GameObject.Find("Name_Display").GetComponent<Text>().text = data.getName();
        //Fetch Questions
        //Set first Question
        game = GameObject.Find("EventSystem").GetComponent<Mini1>();
        Player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            //slash()
        }
        if (Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.UpArrow))
        {
            RowUp();
        }
        if (Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.DownArrow))
        {
            RowDown();
        }
    }

    void Jump()
    {
        if (!jumping)
        {
            /*jumping = true;
            Vector3 position = this.transform.position;
            position.y += jumpHeight;
            this.transform.position = position;
            //Wait 2 Seconds, fall back to ground
            jumping = false;*/
        }
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
        game.HitQuestion(rowNr);
    }

    public void Kill()
    {
        Debug.Log("I was Killed!");
        Destroy(gameObject);
    }
}
