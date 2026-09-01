using UnityEngine;

public class Week2Demo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log("Hello World");
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localPosition.x += 0.01f;
        //Vector3 localPos = transform.localPosition;
        //localPos.x += 0.01f;
        //transform.localPosition = localPos;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("enter");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("exit");
    }
}
