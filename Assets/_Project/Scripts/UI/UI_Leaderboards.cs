using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Leaderboards : MonoBehaviour
{
    public void RestartButton() => SceneManager.LoadScene(1);
    public void MenuButton() => SceneManager.LoadScene(0);
}
