using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour {

    public GameObject bossAttack;
    Rigidbody2D Player;
    Boss Game;
    GameObject AnswerArea;
    int lastENR=-1;
    public AudioSource Audio_Attack;
    public AudioSource Audio_Hurt;
    public AudioSource Audio_Die;


    // Use this for initialization
    void Start () {
        Player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        Game = GameObject.Find("EventSystem").GetComponent<Boss>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Player.position.x > -50 && !Game.rightAnswer&&Game.eNr!=lastENR) {
            GameObject.FindGameObjectWithTag("Boss").GetComponent<Animator>().SetTrigger("Attack");
            Audio_Attack.Play();
            Instantiate(bossAttack, new Vector3(450, -450, 0), Quaternion.Euler(0, 0, 0));
            lastENR = Game.eNr;
        }
	}

    public void SpawnAttack(Vector3 pos) {
        Instantiate(bossAttack, pos, Quaternion.Euler(0, 0, 0));
    }
}
