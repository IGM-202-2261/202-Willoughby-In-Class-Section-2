using UnityEngine;
using UnityEngine.InputSystem;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer ballPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
            mousePos.z = 10;
            SpawnBallAtPosition(mousePos);
        }
    }

    void SpawnBallAtPosition(Vector3 pos)
    {
        SpriteRenderer ballRenderer = Instantiate(ballPrefab, pos, Quaternion.identity);
        ballRenderer.color =
            new Color(Random.Range(0.1f, 1), Random.Range(0.1f, 1), Random.Range(0.1f, 1));
    }
}
