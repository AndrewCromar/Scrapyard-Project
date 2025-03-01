using UnityEngine;
using UnityEngine.UI;

public class ScoreTextController : MonoBehaviour
{
   private Text _Text;

    private void Start() => _Text = GetComponent<Text>();

    private void Update() => _Text.text = "Score: " + PlayerPrefs.GetInt("Score") + ".";
}
