using UnityEngine;
using System.Collections;

public class Mini1_Enemy : MonoBehaviour {

    Rigidbody2D me;
    public AudioSource Audio_Die;

    Vector3 left = new Vector3(-1,0,0);
    float speed = 120.0f;

    // Use this for initialization
    void Start () {
        me = GetComponent<Rigidbody2D>();
        me.velocity = left * speed;
        this.tag = "Enemy";
    }

    public void Kill()
    {
        Audio_Die.Play();
        gameObject.transform.localScale = new Vector3(0, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
	    if (me.transform.position.x < -1800)
        {
            KillSilent();
        }
	}

    public void KillSilent()
    {
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(gameObject);
        Destroy(this);
    }
}
