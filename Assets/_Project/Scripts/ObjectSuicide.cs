using UnityEngine;

public class ObjectSuicide : MonoBehaviour
{
    public float LifeTime = 1;

    void Update()
    {
        LifeTime -= Time.deltaTime;
        if(LifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
