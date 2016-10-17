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
    Animator anim_player;
    Animator anim_head;

    // Use this for initialization
    void Start () {
        //Animator start running animation
        data = GameObject.Find("User_Data").GetComponent<UserData>();
        GameObject.Find("Name_Display").GetComponent<Text>().text = data.getName();
        //Fetch Questions
        //Set first Question
        game = GameObject.Find("EventSystem").GetComponent<Mini1>();
        Player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        anim_player = GameObject.Find("Player Rig").GetComponent<Animator>();
        anim_head = GameObject.Find("Head").GetComponent<Animator>();
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
        anim_player.SetBool("Idle", false);
        anim_head.SetBool("Idle", false);
        Debug.Log("Idle OFF");
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
            anim_head.SetInteger("Head", 1);
            Debug.Log("Head ON");
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
            anim_head.SetInteger("Head", 0);
            Debug.Log("Head OFF");
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name.Contains("Answer")) {
            game.HitQuestion(rowNr);
        }
        else if (coll.gameObject.name.Contains("Enemy"))
        {
            if (attacking)
            {
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
        //anim_player.SetTrigger("LooseLife");
    }

    public void Kill()
    {
        Debug.Log("I was Killed!");
        //anim.SetTrigger("Die");
        anim_player.SetBool("Idle", true);
        anim_head.SetBool("Idle", true);
        Debug.Log("Head ON");
    }

    public void Attack()
    {
        attacking = true;
        anim_player.SetTrigger("Attack");
        anim_head.SetTrigger("Attack");
        Debug.Log("ATTACK");
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        attacking = false;
    }
}
