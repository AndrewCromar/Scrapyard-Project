using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BirdController : MonoBehaviour
{
    public int Score = 0;
    public float AboluteMaxAngle = 45;
    public float smoothing = 10f;

    private Vector2 LastPosition;

    private void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, ColorTracker.Instance.worldPosition.y, transform.position.z);
    
        Vector2 velocity = ((Vector2)transform.position - LastPosition) / Time.deltaTime;
        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        angle = Mathf.Clamp(angle, -AboluteMaxAngle, AboluteMaxAngle);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle), Time.deltaTime * smoothing); 

        LastPosition = transform.position;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "point") { Score ++; PlayerPrefs.SetInt("Score", Score); }
        if(collision.gameObject.tag == "pipe") SceneManager.LoadScene(2);
    }
}