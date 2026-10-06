using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnButton : MonoBehaviour
{
    [SerializeField] private Button spawnButton;
    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private Slider spawnSlider;
    [SerializeField] private BallSpawner ballSpawner;

    private int ballsToSpawn;

    void Start()
    {
        if (spawnSlider != null)
        {
            spawnSlider.onValueChanged.AddListener(OnSliderMoved);
            OnSliderMoved(spawnSlider.value);
        }
        if(spawnButton != null)
        {
            spawnButton.onClick.AddListener(OnButtonClicked);
        }
    }

    void OnDestroy()
    {
        if(spawnSlider != null)
        {
            spawnSlider.onValueChanged.RemoveListener(OnSliderMoved);
        }
        if(spawnButton != null)
        {
            spawnButton.onClick.RemoveListener(OnButtonClicked);
        }
    }

    private void OnSliderMoved(float newValue)
    {
        ballsToSpawn = (int)newValue;

        if (buttonText != null)
        {
            buttonText.text = $"Spawn {ballsToSpawn} balls!";
        }
    }

    private void OnButtonClicked()
    {
        if (ballSpawner != null)
        {
            ballSpawner.SpawnBallsAtCenter(ballsToSpawn);
        }
    }
}
