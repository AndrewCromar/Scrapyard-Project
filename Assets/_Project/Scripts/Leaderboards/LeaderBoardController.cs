using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class LeaderBoardController : MonoBehaviour
{
    public GameObject LeaderboardEntryPrefab;
    public Transform LeaderboardParent;

    public TextAsset APIDataTextAsset;
    public APIData _APIData;

    [System.Serializable]
    public class APIData
    {
        public string APIKey;
        public string EndpointURL;
        public string GetExtension;
    }

    void Start()
    {
        _APIData = JsonUtility.FromJson<APIData>(APIDataTextAsset.text);

        StartCoroutine(CheckAndSubmitScore());
    }

    IEnumerator CheckAndSubmitScore()
    {
        // Get the latest score from PlayerPrefs
        if (PlayerPrefs.HasKey("Score"))
        {
            int latestScore = PlayerPrefs.GetInt("Score");
            if(latestScore == PlayerPrefs.GetInt("LastScoreSet")) yield return 0;

            PlayerPrefs.SetInt("LastScoreSet", latestScore);

            // Add the latest score to the leaderboard
            string playerName = PlayerPrefs.GetString("Name", "Anonymous");
            yield return StartCoroutine(PostScore(playerName, latestScore));
        }

        // Get the top scores from the leaderboard
        yield return StartCoroutine(GetTopScores());
    }

    void AddScoreToLeaderboard(string name, int score)
    {
        StartCoroutine(PostScore(name, score));
    }

    IEnumerator PostScore(string name, int score)
    {
        // Create the JSON data
        string jsonData = JsonUtility.ToJson(new ScoreData { user_id = name, score = score });

        // Create a UnityWebRequest for the POST request
        UnityWebRequest request = new UnityWebRequest(_APIData.EndpointURL + "/rest/v1/leaderboard", "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("apikey", _APIData.APIKey);
        request.SetRequestHeader("Authorization", "Bearer " + _APIData.APIKey);

        // Send the request and wait for a response
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Score added successfully!");
        }
        else
        {
            Debug.LogError("Error adding score: " + request.error);
        }
    }

    IEnumerator GetTopScores()
    {
        string url = _APIData.EndpointURL + _APIData.GetExtension;

        UnityWebRequest request = UnityWebRequest.Get(url);
        request.SetRequestHeader("apikey", _APIData.APIKey);
        request.SetRequestHeader("Authorization", "Bearer " + _APIData.APIKey);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Top scores retrieved successfully!");
            ProcessLeaderboardData(request.downloadHandler.text);
        }
        else
        {
            Debug.LogError("Error retrieving top scores: " + request.error);
        }
    }

    void ProcessLeaderboardData(string json)
    {
        List<ScoreData> scores = JsonUtility.FromJson<ScoreList>("{\"scores\":" + json + "}").scores;

        // Save the leaderboard data to PlayerPrefs
        PlayerPrefs.SetString("LeaderboardData", json);

        // Clear existing leaderboard entries
        foreach (Transform child in LeaderboardParent)
        {
            Destroy(child.gameObject);
        }

        foreach (ScoreData score in scores)
        {
            GameObject entry = Instantiate(LeaderboardEntryPrefab, LeaderboardParent);
            // Assuming the prefab has a script to set the name and score
            entry.GetComponent<LeaderboardEntry>().SetEntry(score.user_id, score.score);
        }
    }

    [System.Serializable]
    public class ScoreData
    {
        public string user_id;
        public int score;
    }

    [System.Serializable]
    public class ScoreList
    {
        public List<ScoreData> scores;
    }
}
