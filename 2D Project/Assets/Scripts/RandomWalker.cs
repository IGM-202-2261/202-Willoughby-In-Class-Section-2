using UnityEngine;

public class RandomWalker : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer squarePrefab;

    [SerializeField]
    private float stepValue = 0.05f;

    [SerializeField]
    private float noiseScale = 1.0f;
    [SerializeField]
    private float yOffset = 1.0f;

    private float timer = 0.0f;

    [SerializeField]
    private float stepTimer = 2.0f;

    [SerializeField]
    private Transform pointA;


    [SerializeField]
    private Transform pointB;

    [SerializeField]
    private bool useDeltaTime = true;

    [SerializeField]
    private float speedPerSecond = 3.0f;

    void Update()
    {
        timer += Time.deltaTime;

        Vector2 pos = transform.position;
        if (useDeltaTime)
        {
            pos.x += speedPerSecond * Time.deltaTime;
        }
        else
        {
            pos.x += 0.05f; // 3 units per second (at 60 fps)
        }

        //Debug.Log(timer + " seconds have passed . Moved " + pos.x + " units.");

        transform.position = pos;

        //transform.position = Vector2.Lerp(pointA.position, pointB.position, timer);

        //if(timer >= stepTimer)
        //{
        //Vector2 pos = transform.position;
        //pos.x += Time.deltaTime;

        //transform.position = pos;

        //timer -= stepTimer;
        //}
    }


    /*        
        //float randValue = Random.Range(0.0f, 1.0f);
     *        Instantiate(squarePrefab, pos, Quaternion.identity).color = Color.black;

        //if (randValue < 0.26f)
        //{
        //    pos.y += stepValue;
        //}
        //else if (randValue < 0.503f)
        //{
        //    pos.x += stepValue;
        //}
        //else if (randValue < 0.753f)
        //{
        //    pos.y -= stepValue;
        //}
        //else
        //{
        //    pos.x -= stepValue;
        //}

        pos.x += stepValue;
        pos.y = Mathf.PerlinNoise1D((pos.x * noiseScale) + 10) + yOffset;
    */
}
