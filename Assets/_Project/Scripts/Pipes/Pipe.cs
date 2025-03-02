using UnityEngine;

public class Pipe : MonoBehaviour
{
    public GameObject SinglePlayerObject;
    public GameObject TwoPlayerObject;
    public float Speed = 1;

    void Start()
    {
        SinglePlayerObject.SetActive(false);
        TwoPlayerObject.SetActive(false);

        if (PlayerPrefs.GetInt("TwoPlayer") == 0)
            SinglePlayerObject.SetActive(true);
        else
            TwoPlayerObject.SetActive(true);
    }

    void Update()
    {
        transform.position += Vector3.left * Speed * Time.deltaTime;

        if(transform.position.x < -20)
        {
            Destroy(gameObject);
        }
    }
}
