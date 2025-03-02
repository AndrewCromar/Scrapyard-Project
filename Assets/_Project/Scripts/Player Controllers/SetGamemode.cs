using UnityEngine;

public class SetGamemode : MonoBehaviour
{
    public PlayerController_Chuck playerController_Chuck;
    public PlayerController_TrackXY playerController_TrackXY;
    public PlayerController_TrackY playerController_TrackY;

    private void Start()
    {
        playerController_Chuck.enabled = false;
        playerController_TrackXY.enabled = false;
        playerController_TrackY.enabled = false;

        if (PlayerPrefs.GetInt("Hard") == 1)
            playerController_Chuck.enabled = true;
        else
            playerController_TrackY.enabled = true;
    }
}
