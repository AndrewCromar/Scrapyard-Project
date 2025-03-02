using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Menu : MonoBehaviour
{
    public Text NameInput;

    public void PlayButton() { PlayerPrefs.SetString("Name", NameInput.text); SceneManager.LoadScene(1);}
    public void ExitButton() => Application.Quit();
}
