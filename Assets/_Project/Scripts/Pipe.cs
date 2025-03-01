using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float Speed = 1;

    void Update()
    {
        transform.position += Vector3.left * Speed * Time.deltaTime;

        if(transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
