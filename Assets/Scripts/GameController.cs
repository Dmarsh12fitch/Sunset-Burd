using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject levelSlider;
    public float scrollSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        levelSlider = GameObject.FindGameObjectWithTag("levelSlider");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        levelSlider.transform.position = new Vector2(levelSlider.transform.position.x - scrollSpeed, levelSlider.transform.position.y); //level scroller
    }
}
