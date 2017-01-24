using UnityEngine;
using System.Collections;
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

    float speed = 120.0f;
    
    void Start()
    {
        GameObject.Find("Name_Display").GetComponent<Text>().text = Game.current.hero.Name;

        game = GameObject.Find("EventSystem").GetComponent<Boss>();
        Player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        anim = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("Hit: " + coll.gameObject.tag);
        switch (coll.gameObject.tag)
        {
            /*case "Enemy":
                if (attacking) Destroy(coll.gameObject);
                else game.Hurt();
                break;*/
            case "Obstacle":
                game.Hurt();
                break;
        }
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
        yield return new WaitForSeconds(0.6f);
        //attacking = false;
    }
}
