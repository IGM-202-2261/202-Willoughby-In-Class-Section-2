using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score;

    public int Score { get; }
    public static ScoreManager Instance { get; private set; }

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Debug.Log("Destroying instance!");
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnDestroy()
    {
        if(Instance == this)
        {
            Instance = null;
        }
    }

    public void AddPoints(int pointChange)
    {
        score += pointChange;
        Debug.Log("Score: " + score);
    }
}
