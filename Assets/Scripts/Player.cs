using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpH = 0.17f;

    public bool isDead;

    public GameObject restartButton;

    public GameObject youWonText;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0) && !isDead) //move up or down based on mouse position above or below middle
        {
            if (Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition).y > 0)
            {
                this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + jumpH);
            }
            else
            {
                this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - jumpH);
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
            //Debug.Log("coll with " + coll.gameObject.name); //death / retart function can go here
        }
    }
}
