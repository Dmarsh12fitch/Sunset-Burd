using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpH = 0.1f;

    public float timer = 0;

    public float fallSpeed = 0.01f;

    public bool isDead;

    public bool windBurst = false;

    public GameObject restartButton;

    public GameObject youWonText;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0) && !isDead) //move up or down based on mouse position above or below middle
        {
            if (Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition).y > 0)
            {
                this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + (jumpH / 3));
            }
            else
            {
                if (!windBurst) { this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - jumpH); }
                if (timer > 20) { windBurst = false; } //if you collide with gust when holding down you can break out of it after a short delay
            }
        }
        if (!Input.GetKey(KeyCode.Mouse0))
        {
            this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - fallSpeed);
        }

        if (windBurst)                                // windburst logic
        {
            this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + jumpH);
            timer += 1;
            if (timer > 100)
            {
                windBurst = false;
                timer = 0;
                Debug.Log("windburst expired");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D coll) 
    {
        if (coll.gameObject.tag == "Ow") //colliding with walls
        {
            Debug.Log("coll with " + coll.gameObject.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Ow") //colliding with enemies
        {
            isDead = true;
            restartButton.gameObject.SetActive(true);
                                                          //death / retart function can go here
        }

        if (coll.gameObject.tag == "Gust") //colliding with wind gust
        {
            windBurst = true;
        }
    }
}
