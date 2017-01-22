using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class loot : MonoBehaviour
{

    public Sprite h1;

    Rigidbody2D me;

    public Sprite chestOpen;

    Vector3 left = new Vector3(-1, 0, 0);
    float speed = 120.0f;

    // Use this for initialization
    void Start()
    {
        me = GetComponent<Rigidbody2D>();
        me.velocity = left * speed;
        this.tag = "Loot";
    }

    public void Kill()
    {
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(gameObject);
        Destroy(this);
    }

    public void Collect()
    {
        GameObject.Find("controller").GetComponent<Pause>().SwitchPause();
        GetComponent<AudioSource>().Play();
        GetComponent<SpriteRenderer>().sprite = chestOpen;

        //int item = Random.Range(6,20);
        GameObject.Find("Inventory").GetComponent<InventoryHelper>().GetItem();

        GameObject.Find("LootInfo").transform.localScale = new Vector3(1, 1, 1);
        //show image
        //save to userdata
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