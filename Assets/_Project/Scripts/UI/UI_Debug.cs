using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Debug : MonoBehaviour
{
    public void ResetEverythingButton() => PlayerPrefs.DeleteAll();
    public void MenuButton() => SceneManager.LoadScene(0);
}
