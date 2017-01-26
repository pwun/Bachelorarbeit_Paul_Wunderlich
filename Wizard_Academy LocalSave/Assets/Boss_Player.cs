using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss_Player : MonoBehaviour
{
    public AudioSource Audio_Hurt;
    public AudioSource Audio_Die;
    public AudioSource music_swordslash;

    Boss game;

    Rigidbody2D Player;
    Player anim;
    SpriteRenderer[] renderer;

    float speed = 300.0f;
    
    void Start()
    {
        GameObject.Find("Name_Display").GetComponent<Text>().text = Game.current.hero.Name;

        game = GameObject.Find("EventSystem").GetComponent<Boss>();
        Player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        anim = GameObject.Find("Player").GetComponent<Player>();
        renderer = GameObject.Find("Player").GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("Hit: " + coll.gameObject.tag);
        switch (coll.gameObject.tag)
        {
            case "Boss":
                Attack();
                game.BossHurt();
                yield return wait();
                //Return to starting Position
                foreach (SpriteRenderer r in renderer){r.flipX = true; }
                Player.velocity = new Vector3(-1, 0, 0) * speed*2;
                break;
            case "Obstacle":
                coll.GetComponent<Mini1_Obstacle>().Kill();
                LoseLife();
                game.PlayerHurt();
                //Return to starting Position
                foreach (SpriteRenderer r in renderer) { r.flipX = true; }
                Player.velocity = new Vector3(-1, 0, 0) * speed*2;
                break;
            case "Startarea":
                anim.Do("StopWalking");
                GameObject.Find("QuestionPanel").transform.localScale = new Vector3(1, 1, 0);
                game.animRunning = false;
                Player.velocity = new Vector3(0, 0, 0);
                foreach (SpriteRenderer r in renderer) { r.flipX = false; }
                break;
        }
    }

    public void StartWalking() {
        anim.Do("Walk");
        Player.velocity = new Vector3(1, 0, 0) * speed;
    }

    public void LoseLife()
    {
        anim.Do("Hurt");
        Audio_Hurt.Play();
    }

    public void Kill()
    {
        anim.Do("Die");
        Audio_Die.Play();
    }

    public void Attack()
    {
        //attacking = true;
        music_swordslash.Play();
        anim.Do("Attack");
        //StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.4f);
        //attacking = false;
    }
}
