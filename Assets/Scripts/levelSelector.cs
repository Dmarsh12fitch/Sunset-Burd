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


    //                                   //L1 L2 L3 L4 L5 L6 L7 L8 L9//
    public int[] levelsUnlocked = { 1, 0, 0, 0, 0, 0, 0, 0, 0 };

    public Image[] levelDisplays;
    public Sprite[] levelDisplaySprites;

    public void selectThisLevel(int level)
    {
        if(levelsUnlocked[level - 1] == 1)
        {
            SceneManager.LoadScene(level);
        }
        /*
        if (levelDisplays[level].sprite.Equals(levelDisplaySprites[level]))
        {
            SceneManager.LoadScene(level);
        }
        */
    }

    // Start is called before the first frame update
    void Start()
    {
        int counter = 0;
        foreach(int levelBinary in levelsUnlocked)
        {
            if(levelBinary == 1)
            {
                Debug.Log(" " + levelsUnlocked[counter]);

                levelDisplays[counter].sprite = levelDisplaySprites[counter];
                levelDisplays[counter].color = Color.white;
            } else
            {
                levelDisplays[counter].sprite = levelDisplaySprites[9];
                levelDisplays[counter].color = Color.red;
            }
            counter++;
        }
    }


    private void OnLevelWasLoaded()
    {
        int counter = 0;
        if (GameObject.Find("Main_Menu_Canvas") != null)
        {
            //Debug.Log(" " + GameObject.Find("Main_Menu_Canvas").ToString());
            //levelDisplays[0] = GameObject.Find("Level_1").GetComponent<Image>();
            
            foreach (Image i in levelDisplays)
            {
                levelDisplays[counter] = GameObject.Find("Level_" + (counter + 1).ToString()).GetComponent<Image>();
                counter++;
            }
            



            counter = 0;


            foreach (int levelBinary in levelsUnlocked)
            {
                if (levelBinary == 1)
                {
                    Debug.Log(" " + levelsUnlocked[counter]);

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


}
