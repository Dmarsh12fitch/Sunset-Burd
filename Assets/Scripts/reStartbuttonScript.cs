using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class reStartbuttonScript : MonoBehaviour
{
    public int level;
    public bool returnToMenu;

    public void restartLevel()
    {
            StartCoroutine(restartDelay());
    }

    IEnumerator restartDelay()
    {
        yield return new WaitForSeconds(0.5f);
        if(returnToMenu)
        {
            levelSelector.Singleton.levelsUnlocked[level] = 1;
            SceneManager.LoadScene(0);
        } else
        {
            SceneManager.LoadScene(level);
        }

    }


}




