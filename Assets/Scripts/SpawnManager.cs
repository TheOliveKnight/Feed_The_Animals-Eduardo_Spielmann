using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Singleton Instance[cite: 2]
    public static SpawnManager Instance { get; private set; }
    [SerializeField] private GameObject[] animalPrefab;
    [SerializeField] private int animalsToFeed = 10;
    [SerializeField] private float spawnStart = 2f;
    [SerializeField] private float startFrequency = 1.5f;
    [SerializeField] private float spawnZPosition = 20f;
    [SerializeField] private float centerToEdge = 20f;
    [SerializeField] public int animalsSpawned =0;
    private float spawnTimer;
    private bool isGameOver = false;


    private void Awake()
    {
        // INITIALIZING State: Set Instance singleton[cite: 2]
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        // INITIALIZING State: Set initial values for spawnZPosition and centerToEdge[cite: 2]
        spawnTimer = spawnStart;
    }

    private void Update()
    {
        if (isGameOver) return;

        // SPAWNING State: Run timer based on startFrequency[cite: 2]
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            SpawnAnimal();
            spawnTimer = startFrequency; // Reset timer[cite: 2]
        }
    }

    private void SpawnAnimal()
    {
       if (animalsSpawned < 20)
        {
            Debug.Log($"AnimalsSpawned = {animalsSpawned}");
        // Instantiate an animal prefab at a random x-value within centerToEdge, zero y, and spawnZPosition z[cite: 2]
        animalsSpawned += 1;
        int randomIndex = Random.Range(0, animalPrefab.Length);
        float randomX = Random.Range(-centerToEdge, centerToEdge);
        Vector3 spawnPos = new Vector3(randomX, 0.1f, spawnZPosition);
        
        Instantiate(animalPrefab[randomIndex], spawnPos, animalPrefab[randomIndex].transform.rotation);
        }
    }

    public void GameOver()
    {
        // GAMEOVER State: Stop calling SpawnAnimal[cite: 2]
        isGameOver = true;
    }

    public int GetNumberOfAnimalsToFeed()
    {
        // Public getter to read initial animalsToFeed[cite: 2]
        return animalsToFeed;
    }
}