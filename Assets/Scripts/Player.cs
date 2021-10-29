using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpH = 0.04f;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition).y);
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0)) //jump
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
        if (coll.gameObject.tag == "Ow")
        {
            Debug.Log("coll with" + coll);
        }
    }
}
