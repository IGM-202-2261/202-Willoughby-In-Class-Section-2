using UnityEngine;

public class RandomWalker : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer squarePrefab;

    [SerializeField]
    private float stepValue = 0.05f;

    void Update()
    {
        //float randValue = Random.Range(0.0f, 1.0f);
        Vector2 pos = transform.position;
        Instantiate(squarePrefab, pos, Quaternion.identity).color = Color.black;

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
        pos.y = Mathf.PerlinNoise1D(pos.x);

        transform.position = pos;
    }
}
