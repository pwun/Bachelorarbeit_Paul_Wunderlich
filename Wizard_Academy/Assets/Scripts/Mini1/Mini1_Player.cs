using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mini1_Player : MonoBehaviour {

    int rowNr = 1;
    int rowGap = 100;
    int jumpHeight = 70;
    int jumpLength = 150;
    bool attacking = false;
    public bool running = false;
    Rigidbody2D Player;

    UserData data;
    Mini1 game;
    Animator anim;


	// Use this for initialization
	void Start () {
        //Animator start running animation
        data = GameObject.Find("User_Data").GetComponent<UserData>();
        GameObject.Find("Name_Display").GetComponent<Text>().text = data.getName();
        //Fetch Questions
        //Set first Question
        game = GameObject.Find("EventSystem").GetComponent<Mini1>();
        Player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        anim = GameObject.Find("Player Rig").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
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

    public void StartAnimation()
    {
        anim.SetBool("running", true);
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
        if (coll.gameObject.name.Contains("Answer")) {
            game.HitQuestion(rowNr);
        }
        else if (coll.gameObject.name.Contains("Enemy"))
        {
            Debug.Log("ENEMY!");
            if (attacking)
            {
                Debug.Log("ATTACK");
                Destroy(coll.gameObject);
            }
        }
        else
        {
            game.LoseLife();
        }
    }

    public void LoseLife()
    {
        anim.SetTrigger("LooseLife");
    }

    public void Kill()
    {
        Debug.Log("I was Killed!");
        anim.SetTrigger("Die");
    }

    public void Attack()
    {
        attacking = true;
        anim.SetTrigger("Attack");
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        attacking = false;
    }
}
