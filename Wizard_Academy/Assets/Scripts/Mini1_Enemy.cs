﻿using UnityEngine;
using System.Collections;

public class Mini1_Enemy : MonoBehaviour {

    Rigidbody2D me;
    Mini1 game;

    Vector3 left = new Vector3(-1,0,0);
    float speed = 120.0f;

    // Use this for initialization
    void Start () {
        me = GetComponent<Rigidbody2D>();
        me.velocity = left * speed;
        game = GameObject.Find("EventSystem").GetComponent<Mini1>();
    }

    public void Kill()
    {
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(gameObject);
        Destroy(this);
    }
	
	// Update is called once per frame
	void Update () {
	    if (me.transform.position.x < 0)
        {
            Kill();
        }
	}
}