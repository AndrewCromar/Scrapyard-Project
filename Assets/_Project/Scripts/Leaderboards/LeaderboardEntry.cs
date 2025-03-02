using UnityEngine;
using TMPro;

public class LeaderboardEntry : MonoBehaviour
{
    public TMP_Text _Text;

    public void SetEntry(string name, int score)
    {
        _Text.text = name + " - " + score.ToString();
    }
}