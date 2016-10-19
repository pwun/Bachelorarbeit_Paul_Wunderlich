using UnityEngine;
using System.Collections;

public class Mini1_Obstacle : MonoBehaviour {

    Rigidbody2D me;

    Vector3 left = new Vector3(-1, 0, 0);
    float speed = 120.0f;

    // Use this for initialization
    void Start()
    {
        me = GetComponent<Rigidbody2D>();
        me.velocity = left * speed;
        this.tag = "Enemy";
    }

    public void Kill()
    {
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(gameObject);
        Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (me.transform.position.x < -1800)
        {
            Kill();
        }
    }
}
