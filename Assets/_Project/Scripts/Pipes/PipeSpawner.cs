using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject PipePrefab;
    public float SpawnInterval = 1;
    public float SpawnInterval2P = 2;
    public float counter;

    void Update()
    {
        counter -= Time.deltaTime;
        if(counter <= 0)
        {
            counter = PlayerPrefs.GetInt("TwoPlayer") == 0 ? SpawnInterval : SpawnInterval2P;

            GameObject pipe = Instantiate(PipePrefab);
            float yRange = PlayerPrefs.GetInt("TwoPlayer") == 0 ? 5 : 5;
            pipe.transform.position = new Vector3(20, Random.Range(-yRange, yRange), 0);
        }
    }
}
