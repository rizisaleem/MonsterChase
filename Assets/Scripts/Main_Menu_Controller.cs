using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu_Controller : MonoBehaviour
{
    public void GamePlay()
    {
        int selectedChar = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

        Game_Manager.instance.CharIndex = selectedChar;
        SceneManager.LoadScene("Gameplay");
    }

}
