using UnityEngine;

public class FramerateControl : MonoBehaviour
{

    [SerializeField, Range(15, 100)]
    private int targetFrameRate = 60;

    // Update is called once per frame
    void Update()
    {

        Application.targetFrameRate = targetFrameRate;
    }
}
