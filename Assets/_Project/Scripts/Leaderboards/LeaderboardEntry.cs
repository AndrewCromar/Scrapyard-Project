using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeaderboardEntry : MonoBehaviour
{
    public Image FirstPlacePrize;
    public Image SecondPlacePrize;
    public Image ThirdPlacePrize;
    public TMP_Text _Text;

    public void SetEntry(string name, int score)
    {
        _Text.text = name + ": " + score.ToString();

        FirstPlacePrize.gameObject.SetActive(false);
        SecondPlacePrize.gameObject.SetActive(false);
        ThirdPlacePrize.gameObject.SetActive(false);
        if (transform.GetSiblingIndex() == 0) FirstPlacePrize.gameObject.SetActive(true);
        if (transform.GetSiblingIndex() == 1) SecondPlacePrize.gameObject.SetActive(true);
        if (transform.GetSiblingIndex() == 2) ThirdPlacePrize.gameObject.SetActive(true);
    }
}