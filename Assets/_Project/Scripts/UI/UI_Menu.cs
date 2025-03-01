using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Menu : MonoBehaviour
{
    public void PlayButton() => SceneManager.LoadScene(1);
    public void ExitButton() => Application.Quit();
}
