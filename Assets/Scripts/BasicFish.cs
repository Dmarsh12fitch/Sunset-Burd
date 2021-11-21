using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFish : MonoBehaviour
{
    public float jMin = 1;
    public float jMax = 3;
    public float jumpHMin = 7;
    public float jumpHMax = 12;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "screenExit")
        {
            Destroy(this.gameObject);
        }
        if (coll.gameObject.tag == "screenEnter")
        {
            StartCoroutine(jumptiming()); //triggers when entering the screen
        }
    }

    public IEnumerator jumptiming()
    {
        yield return new WaitForSeconds(Random.Range(jMin, jMax)); //rng jump timing
        this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.6f);
        yield return new WaitForSeconds(0.4f);
        Destroy(this.transform.GetChild(0).gameObject);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        rb.gravityScale = 1;
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + Random.Range(jumpHMin, jumpHMax)); //rng jump height
    }
}
