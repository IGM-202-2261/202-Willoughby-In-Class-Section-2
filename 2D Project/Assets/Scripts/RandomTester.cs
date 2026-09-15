using UnityEngine;

public class RandomTester : MonoBehaviour
{
    [SerializeField]
    private GameObject squarePrefab;

    [SerializeField]
    private Vector2 screenBounds;

    [SerializeField]
    private int numSquares = 10;

    void Start()
    {
        for (int i = 0; i < numSquares; i++)
        {
            //Uniform random position
            //Vector2 randPos = new Vector2(
            //        Random.Range(-screenBounds.x, screenBounds.x),
            //        Random.Range(-screenBounds.y, screenBounds.y)
            //    );

            Vector2 randPos = new Vector2(
                    Gaussian(0.0f, 1.0f), // -4 -> 4
                    Gaussian(0.0f, 1.0f) // -4 -> 4
                );

            Instantiate(squarePrefab, randPos, Quaternion.identity);
        }
    }

    float Gaussian(float mean, float stdDev)
    {
        float val1 = Random.Range(0f, 1f);
        float val2 = Random.Range(0f, 1f);
        float gaussValue =
                 Mathf.Sqrt(-2.0f * Mathf.Log(val1)) *
                 Mathf.Sin(2.0f * Mathf.PI * val2);
        return mean + stdDev * gaussValue;
    }

}
