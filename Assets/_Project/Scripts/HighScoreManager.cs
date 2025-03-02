using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    private void Start()
    {
        if (PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("PersonalBest"))
        {
            PlayerPrefs.SetInt("PersonalBest", PlayerPrefs.GetInt("Score"));
        }
    }
}
