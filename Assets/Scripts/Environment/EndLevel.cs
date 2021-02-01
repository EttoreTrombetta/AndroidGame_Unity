using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndLevel : Interactable
{
    public bool endGame;
    public Text endGameText;
    [TextArea(3,10)]
    public string endGameCredits;
    public GameObject endGamePanel;
    public GameObject[] panels;
    public string nextLevelName;

    private bool gameover = false;

    public bool Gameover { get => gameover; set => gameover = value; }

    public override void Action()
    {
        if(!endGame)
        {
            SceneManager.LoadScene(nextLevelName);
        }
        else
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        Gameover = true;
        endGameText.text = endGameCredits;
        endGamePanel.SetActive(true);
        foreach(GameObject g in panels)
        {
            g.SetActive(false);
        }
    }
}
