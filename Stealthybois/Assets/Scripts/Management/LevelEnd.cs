using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelEnd : MonoBehaviour {
    public string NextLevel;
    private GameManager gm;
    public Text TimeText, DeathText, GradeText;
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        TimeText.text = "Time: " + gm.GetTime().ToString() + "s";
        DeathText.text = "Deaths: " + GameInfo.PlayerDeaths.ToString();
        GradeText.text = "Final Grade: " + LetterGrade(gm.GetScore());
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(NextLevel);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public string LetterGrade(float score)
    {
        if (score >= 95)
            return "A+";
        else if (score >= 90 && score < 95)
            return "A-";
        else if (score >= 85 && score < 90)
            return "B+";
        else if (score >= 80 && score < 85)
            return "B-";
        else if (score >= 75 && score < 80)
            return "C+";
        else if (score >= 70 && score < 75)
            return "C-";
        else
            return "F";
    }
}
