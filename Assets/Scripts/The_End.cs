using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class The_End : MonoBehaviour
{
    public void Home()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Gameplay");
    }

}
