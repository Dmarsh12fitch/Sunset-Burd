using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class levelSelector : MonoBehaviour
{
    //make a singleton
    public static levelSelector Singleton = null;
    private void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
                DontDestroyOnLoad(this.gameObject);
        }
        else if(Singleton != this)
        {
            Destroy(this.gameObject);
        }
    }
    //finish making a singleton

        


    //                           //L1 L2 L3 L4 L5 L6 L7 L8 L9//
    public int[] levelsUnlocked = { 1, 0, 0, 0, 0, 0, 0, 0, 0 };

    public Image[] levelDisplays;
    public Sprite[] levelDisplaySprites;

    public bool firstTimeDone;



    // Start is called before the first frame update
    void Start()
    {
        RefreshScene();
    }


    public void selectThisLevel(int level)
    {
            SceneManager.LoadScene(level);
    }

    private void OnLevelWasLoaded()
    {
        if (GameObject.Find("Main_Menu_Canvas") != null)
        {
            int counter = 0;
            foreach (Image i in levelDisplays)
            {
                levelDisplays[counter] = GameObject.Find("Level_" + (counter + 1).ToString()).GetComponent<Image>();
                counter++;
            }
            RefreshScene();
        }
    }



    public void RefreshScene()
    {
        Debug.Log("yea");

        if (firstTimeDone)
        {
            int c = 0;
            /*
            foreach (Image i in levelDisplays)
            {
                Debug.Log("Level_" + (c + 1).ToString());
                i.gameObject.SetActive(true);
                //GameObject.Find("Level_" + (c + 1).ToString()).gameObject.SetActive(true);
                c++;
            }*/
        }

        int counter = 0;
        foreach (int levelBinary in levelsUnlocked)
        {
            if (levelBinary == 1)
            {

                levelDisplays[counter].sprite = levelDisplaySprites[counter];
                levelDisplays[counter].color = Color.white;
            }
            else
            {
                levelDisplays[counter].sprite = levelDisplaySprites[9];
                levelDisplays[counter].color = Color.red;
            }
            counter++;
        }
    }



}
