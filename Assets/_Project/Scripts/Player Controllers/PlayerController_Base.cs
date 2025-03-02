using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController_Base : MonoBehaviour
{
    [Header ("Settings")]
    public float AboluteMaxAngle = 45;
    public float Smoothing = 10f;

    [Header ("Debug")]
    public int Score = 0;
    private Vector2 LastPosition;

    public void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
    }

    public virtual void Update()
    {
        CalculateAngle();
    }

    private void CalculateAngle()
    {
        Vector2 velocity = ((Vector2)transform.position - LastPosition) / Time.deltaTime;
        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        angle = Mathf.Clamp(angle, -AboluteMaxAngle, AboluteMaxAngle);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle), Time.deltaTime * Smoothing);

        LastPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("point"))
        {
            Score++;
            PlayerPrefs.SetInt("Score", Score);
        }

        if (collision.gameObject.CompareTag("pipe"))
        {
            ColorTracker.Instance.TerminateWebcam();
            SceneManager.LoadScene(2);
        }
    }
}
