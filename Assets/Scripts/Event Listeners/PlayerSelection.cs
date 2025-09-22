using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelectionController : MonoBehaviour
{
    public void PlayerSelection(int index)
    {
        GameManager.Instance.CharIndex = index;
        SceneManager.LoadScene("Gameplay");
    }
}
