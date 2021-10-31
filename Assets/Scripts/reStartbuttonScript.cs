using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reStartbuttonScript : MonoBehaviour
{


    public void restartLevel()
    {
        StartCoroutine(restartDelay());
    }

    IEnumerator restartDelay()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(0);    //this must change in the future
    }


}
