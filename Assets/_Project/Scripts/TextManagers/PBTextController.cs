using UnityEngine;
using TMPro;

public class PBTextController : MonoBehaviour
{
   private TMP_Text _Text;

    private void Start() => _Text = GetComponent<TMP_Text>();

    private void Update() => _Text.text = "PB: " + PlayerPrefs.GetInt("PersonalBest") + ".";
}
