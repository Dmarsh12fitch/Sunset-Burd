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
    }

    // Update is called once per frame
    void Update()
    {
        
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
        rb.gravityScale = 1;
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + Random.Range(jumpHMin, jumpHMax)); //rng jump height
    }
}
