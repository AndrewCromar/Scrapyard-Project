using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController_Base : MonoBehaviour
{
    [Header ("Settings")]
    public GameObject CollectSFXPrefab;
    public float AboluteMaxAngle = 45;
    public float Smoothing = 10f;
    public float AbsMaxY = 5;

    [Header ("Debug")]
    public int Score = 0;
    private Vector2 LastPosition;

    public virtual void Update()
    {
        PlayerPrefs.SetInt("Score", Score);

        if(transform.position.y > AbsMaxY || transform.position.y < -AbsMaxY) EndRound();

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
            Instantiate(CollectSFXPrefab, Vector2.zero, Quaternion.identity);
        }

        if (collision.gameObject.CompareTag("pipe"))
        {
            EndRound();
        }
    }

    private void EndRound(){
        ColorTracker.Instance.TerminateWebcam();
        SceneManager.LoadScene(3);
    }
}
