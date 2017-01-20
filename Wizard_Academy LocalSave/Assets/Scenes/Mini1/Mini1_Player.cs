using UnityEngine;
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

    Mini1 game;
    Player anim;

    public AudioSource music_swordslash;

    // Use this for initialization
    void Start () {
        //Animator start running animation
        GameObject.Find("Name_Display").GetComponent<Text>().text = Game.current.hero.Name;
        //Fetch Questions
        //Set first Question
        game = GameObject.Find("EventSystem").GetComponent<Mini1>();
        Player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        anim = GameObject.Find("Player").GetComponent<Player>();
        //Get Item Types
        //anim.SetArmor(), Head
    }
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.W))
        {
            RowUp();
        }
        //if (Input.GetAxisRaw("Vertical")<0)
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
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
        music_swordslash.Play();
        anim.Do("Attack");
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.6f);
        attacking = false;
    }
}
