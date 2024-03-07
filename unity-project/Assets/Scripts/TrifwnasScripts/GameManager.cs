using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int winTime = 30;
    public SpawnHandler spawnHandler;
    public TargetHandler targetHandler;
    [SerializeField] Canvas winCanvas;
    [SerializeField] Canvas loseCanvas;
    public bool isLostGame = false;
    public bool isWinGame = false;
    //public PlayerHandler playerHandler;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        StartCoroutine(WaitForWin());
        Time.timeScale = 1;
    }

    IEnumerator WaitForWin()
    {
        yield return new WaitForSeconds(winTime);
        GameWon();
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
    }

    private void GameOver()
    {
        if (!targetHandler.isActive())
        {
            isLostGame = true;
            Debug.Log("Game Over");
            Cursor.visible = true;
            loseCanvas.GetComponent<Canvas>().gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
        }

    }

    private void GameWon()
    {
        winCanvas.GetComponent<Canvas>().gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}

//private bool getPlayerAliveStatus()
//{
//    return playerHandler.isActive();
//}
