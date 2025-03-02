using UnityEngine;
using UnityEngine.UI;

public class PBTextController : MonoBehaviour
{
   private Text _Text;

    private void Start() => _Text = GetComponent<Text>();

    private void Update() => _Text.text = "PB: " + PlayerPrefs.GetInt("PersonalBest") + ".";
}
