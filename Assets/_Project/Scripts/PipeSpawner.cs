using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject PipePrefab;
    public float SpawnInterval = 1;
    public float counter;

    void Update()
    {
        counter -= Time.deltaTime;
        if(counter <= 0)
        {
            counter = SpawnInterval;
            GameObject pipe = Instantiate(PipePrefab);
            pipe.transform.position = new Vector3(10, Random.Range(-3, 3), 0);
        }
    }
}
