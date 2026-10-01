using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Week5Demo : MonoBehaviour
{
    [SerializeField] private Vector2 direction;
    [SerializeField] private float speed; //As a function of time

    [SerializeField] private bool useNormalized;

    void Update()
    {
        Vector3 velocity = (Vector3)direction.normalized * speed;

        //if(useNormalized)
        //{
            transform.position += velocity * Time.deltaTime;

        if (transform.position.x > 5 && transform.position.x < 5.1)
        {
            ScoreManager.Instance.AddPoints(1);
        }

        if(transform.position.x > 7)
        {
            SceneManager.LoadScene("Week2");
        }
        //}
        //else
        //{
        //    transform.position += (Vector3)direction * speed * Time.deltaTime;
        //}
    }

    void OnDrawGizmos()
    {
        Vector2 myVector = new Vector2(1f, 3f);
        Vector2 otherVector = new Vector2(1.5f, 0.5f);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(Vector2.zero, myVector);

        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(Vector2.zero, otherVector);

        Gizmos.color = Color.white;

        Gizmos.DrawLine(Vector2.zero, myVector - otherVector);
        Gizmos.DrawLine(Vector2.zero, myVector - otherVector); //order matters here
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(Vector2.zero, otherVector - myVector);

        //Gizmos.DrawLine(Vector2.zero, myVector / 2.0f);

        //Debug.Log(otherVector.magnitude);

        Vector2 summedVectors = myVector - otherVector;
        //Debug.Log(summedVectors.magnitude);
        //
        //Debug.Log(summedVectors.normalized); // Returns a copy that has been normalized
        //Debug.Log(summedVectors);
        //
        //summedVectors.Normalize(); //Alters the original and normalizes it
        //Debug.Log(summedVectors);
    }
}
