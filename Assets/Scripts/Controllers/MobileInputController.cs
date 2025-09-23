using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInputController : MonoBehaviour
{
    public static MobileInputController Instance;

    [SerializeField] private GameObject leftBtn;
    [SerializeField] private GameObject rightBtn;
    [SerializeField] private GameObject jumpBtn;

    private PlayerController player;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

    #if UNITY_STANDALONE || UNITY_WEBPLAYER
        leftBtn.SetActive(false);
        rightBtn.SetActive(false);
        jumpBtn.SetActive(false);
    #endif
    }

    public void SetPlayer(PlayerController ply)
    {
        player = ply;
    }

    public void MoveLeft()
    {
        if (player != null) player.movePlayer(-1f);
    }

    public void MoveRight()
    {
        if (player != null) player.movePlayer(1f);
    }

    public void Stop()
    {
        if (player != null) player.movePlayer(0f);
    }

    public void Jump()
    {
        if (player != null) player.Jump();
    }
}
