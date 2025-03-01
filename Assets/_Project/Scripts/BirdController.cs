using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BirdController : MonoBehaviour
{
    public int Score = 0;
    public float FlapVelocity = 5f;
    public Vector2 Velocity = Vector2.zero;
    public float gravityForce = 9.8f;

    public float topY = 5;
    public float bottomY = -5;

    private void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
    }

    private void Update()
    {
        Velocity.y -= gravityForce * Time.deltaTime;
        transform.position += (Vector3)Velocity * Time.deltaTime;

        if (transform.position.y > topY)
        {
            transform.position = new Vector3(transform.position.x, topY, transform.position.z);
            Velocity.y = 0;
        }
        if (transform.position.y < bottomY)
        {
            transform.position = new Vector3(transform.position.x, bottomY, transform.position.z);
            Velocity.y = 0;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "point") { Score ++; PlayerPrefs.SetInt("Score", Score); }
        if(collision.gameObject.tag == "pipe") SceneManager.LoadScene(2);
    }

    public void Flap(InputAction.CallbackContext ctx) { if(ctx.performed) Velocity.y = FlapVelocity; }
}
