using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;
    private bool gameOver = false;
    private bool playerActive = false;
    [SerializeField] private GameObject mainMenu;

    private bool gameStart = false;

    public bool PlayerActive{
        get { return playerActive; }
}
    public bool GameOver
    {
        get { return gameOver; }
    }
    public bool GameStart{
          get {return gameStart; }
   } 
    //awake

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   public void playerCollided()
    {
        gameOver = true;
    }
   public void gameStarted()
    {
        mainMenu.SetActive(false);
        playerActive = true;
    }
   
}
