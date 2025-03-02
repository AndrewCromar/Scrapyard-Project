using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Menu : MonoBehaviour
{
    public InputField NameInput;

    public void Start() => NameInput.text = PlayerPrefs.GetString("Name") == "" || PlayerPrefs.GetString("Name") == null ? "Guest" : PlayerPrefs.GetString("Name");

    public void PlayEasyButton() { PlayerPrefs.SetString("Name", NameInput.text); PlayerPrefs.SetInt("TwoPlayer", 0);  PlayerPrefs.SetInt("Hard", 0); SceneManager.LoadScene(1);}
    public void PlayHardButton() { PlayerPrefs.SetString("Name", NameInput.text); PlayerPrefs.SetInt("TwoPlayer", 0);  PlayerPrefs.SetInt("Hard", 1); SceneManager.LoadScene(1);}
    public void PlayEasy2PButton() { PlayerPrefs.SetString("Name", NameInput.text); PlayerPrefs.SetInt("TwoPlayer", 1);  PlayerPrefs.SetInt("Hard", 0); SceneManager.LoadScene(1);}
    public void LeaderboardsButton() => SceneManager.LoadScene(3);
    public void ExitButton() => Application.Quit();
    public void DebugButton() => SceneManager.LoadScene(4);
}
