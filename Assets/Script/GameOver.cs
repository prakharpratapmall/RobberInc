using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject canvas2;
    public TextMeshProUGUI score;
    public void GameEnded(float time)
    {
        canvas1.SetActive(false);
        canvas2.SetActive(true);
        score.text = "You were able to survive for" + time + "seconds!";
    }
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");

    }
    public void MM()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
