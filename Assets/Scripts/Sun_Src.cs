using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun_Src : MonoBehaviour
{

    //set Sunlight "Alpha Blend on Overlap" to TRUE for right before dusk.
    private float sunDownAmountFromOrigin = 1;
    public float speed;

    private Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        sunDownAmountFromOrigin -= Time.deltaTime / speed;      //sets increment for sun to go down by
        if (transform.localPosition.y >= -4)
        {
            transform.localPosition = new Vector3(0, sunDownAmountFromOrigin, 0);       //makes sun go down
        } else
        {
            playerScript.isDead = true;         //stops player from moving
            playerScript.youWonText.gameObject.SetActive(true);
            playerScript.restartButton.gameObject.SetActive(true);
        }
        

        

    }
}
