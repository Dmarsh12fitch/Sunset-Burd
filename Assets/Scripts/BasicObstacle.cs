using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicObstacle : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "screenExit")
        {
            Destroy(this.gameObject);
        }
    }
}
