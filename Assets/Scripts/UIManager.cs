using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    // Singleton Instance[cite: 3]
    public static UIManager Instance { get; private set; }

    [SerializeField] private UIDocument uiDocument;
    
    private Label animalsRemainingUI;
    private Label scoreUI;
    private int animalsRemaining;
    private int score = 0;

    private void Awake()
    {
        // Singleton setup[cite: 3]
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        // INITIALIZING State: Query UI Builder elements[cite: 2, 3]
        var root = uiDocument.rootVisualElement;

        // Map UI elements using exact UI Builder names[cite: 2]
        scoreUI = root.Q<Label>("ScoreLabel");
        animalsRemainingUI = root.Q<Label>("AnimalsRemainingLabel");

        // Set initial score to 0[cite: 2]
        score = 0;
        if (scoreUI != null)
        {
            scoreUI.text = "Score: " + score;
        }

        // Set initial Animals Remaining to animalsToFeed from SpawnManager[cite: 2]
        if (SpawnManager.Instance != null)
        {
            animalsRemaining = SpawnManager.Instance.GetNumberOfAnimalsToFeed();
        }

        if (animalsRemainingUI != null)
        {
            animalsRemainingUI.text = "Animals Remaining: " + animalsRemaining;
        }
    }

    // ACTIVE_HUD State Methods[cite: 3]

    public void ScoreUpdate(int scoreUpdate)
    {
        // Adds incoming integer to local score and updates scoreUI text[cite: 3]
        score += scoreUpdate;
        if (scoreUI != null)
        {
            scoreUI.text = "Score: " + score;
        }
    }

    public void AnimalsRemainingUpdate()
    {
        // Decreases animalsRemaining by 1 while greater than 0 and updates animalsRemainingUI text[cite: 3]
        if (animalsRemaining > 0)
        {
            animalsRemaining--;
            if (animalsRemainingUI != null)
            {
                animalsRemainingUI.text = "Animals Remaining: " + animalsRemaining;
            }

            // Transition out condition when animals remaining hits zero[cite: 2]
            if (animalsRemaining <= 0 && SpawnManager.Instance != null)
            {
                SpawnManager.Instance.GameOver();
            }
        }
    }
}