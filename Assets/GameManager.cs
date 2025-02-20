using UnityEngine;
 using TMPro;


public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;

    private FallTrigger[] pins;

    private void Start()
    {
        // Find all objects of type FallTrigger, including inactive ones
        pins = FindObjectsOfType<FallTrigger>(true);

        // Loop over our array of pins and add the IncrementScore function as their listener
        foreach (FallTrigger pin in pins)
        {
            pin.OnPinFall.AddListener(IncrementScore);
        }
    }

    private void IncrementScore()
    {
          scoreText.text = $"Score: {score}";

        score++;
    }
}
