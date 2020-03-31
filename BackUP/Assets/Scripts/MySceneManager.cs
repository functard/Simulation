using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MySceneManager : MonoBehaviour
{
    [HideInInspector]
    public static bool gameWon;

    [HideInInspector]
    public static bool gameLost;

    [SerializeField]
    private Button playButton;

    [SerializeField]
    private Button quitButton;

    [SerializeField]
    private Text winText;

    [SerializeField]
    private Text loseText;

    // Start is called before the first frame update
    void Start()
    {
        playButton.gameObject.SetActive(false);

        gameLost = false;
        gameWon = false;
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(gameLost);

        //if won
        if(gameWon)
        {
            //show buttons
            playButton.gameObject.SetActive(true);
            quitButton.gameObject.SetActive(true);
            winText.gameObject.SetActive(true);

        }

        //if lost
        if (gameLost)
        {
            //show buttons
            playButton.gameObject.SetActive(true);
            quitButton.gameObject.SetActive(true);
            loseText.gameObject.SetActive(true);

        }

        //if 3 days passed
        if(DayNightCycle.dayCount >=2 && !gameWon)
        {
            //lose
            gameLost = true;
        }
    }

    public void Play()
    {
        //load game scene
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
