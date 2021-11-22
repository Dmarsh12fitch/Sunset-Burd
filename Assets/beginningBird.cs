using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class beginningBird : MonoBehaviour
{
    bool alreadyDone;

    private void Start()
    {
        if (!levelSelector.Singleton.firstTimeDone)
        {
            int counter = 0;
            foreach (Image i in levelSelector.Singleton.levelDisplays)
            {
                i.enabled = false;
                counter++;
            }
            GameObject.Find("Sun_Bird_Logo").GetComponent<SpriteRenderer>().enabled = true;
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x > 3.5 && !levelSelector.Singleton.firstTimeDone)
        {
            transform.Translate(-0.03f, 0, 0);
        } else
        {
            Destroy(gameObject.GetComponent<Animator>());
            StartCoroutine(endStarter());
        }
    }




    IEnumerator endStarter()
    {
        if (!alreadyDone && GameObject.Find("Main_Menu_Canvas") != null)
        {
            alreadyDone = true;
            yield return new WaitForSeconds(2.0f);
            int counter = 0;
            foreach(Image i in levelSelector.Singleton.levelDisplays)
            {
                i.enabled = true;
                counter++;
            }
            GameObject.Find("Sun_Bird_Logo").GetComponent<SpriteRenderer>().enabled = false;
            levelSelector.Singleton.firstTimeDone = true;
            levelSelector.Singleton.RefreshScene();
            Destroy(gameObject, 0.01f);
        }
    }
}