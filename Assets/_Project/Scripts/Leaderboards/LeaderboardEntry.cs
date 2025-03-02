using UnityEngine;
using UnityEngine.UI;

public class LeaderboardEntry : MonoBehaviour
{
    public Text _Text;

    public void SetEntry(string name, int score)
    {
        _Text.text = name + " - " + score.ToString();
    }
}