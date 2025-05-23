using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_GameOver : MonoBehaviour
{
    public void RestartButton() => SceneManager.LoadScene(1);
    public void LeaderboardsButton() => SceneManager.LoadScene(3);
    public void MenuButton() => SceneManager.LoadScene(0);
}
