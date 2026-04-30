using UnityEngine;

public class FruitGame : MonoBehaviour
{
    void Start()
    {
        mainCamera = Camera.main;
        SpawnnewFruit();
    }

    void Update()
    {
        if (isGameOver)
        {
            return;
        }
        if (FruitTimer >= 0)
        {
            FruitTimer -= Time.deltaTime;
        }
        if (FruitTimer < 0 && FruitTimer > -2)
        {
            SpawnnewFruit();
            FruitTimer = -3.0f;
        }

        if (currentFruit != null)
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

            Vector3 newPosition = currentFruit.transform.position;

            newPosition.x = worldPosition.x;

            float halfFruitSize = fruitsize[currentFruitType] / 2f;

            if (newPosition.x < -gameWidth / 2 - halfFruitSize)
            {
                newPosition.x = -gameWidth / 2 - halfFruitSize;
            }
            else if (newPosition.x > gameWidth / 2 + halfFruitSize)
            {
                newPosition.x = gameWidth / 2 + halfFruitSize;
            }
            currentFruit.transform.position = newPosition;
        }

        if (Input.GetMouseButtonDown(0) && FruitTimer == 3.0f)
        {
            DropFruit();
        }
    }

    public GameObject[] fruitPrefabs;
    public float[] fruitsize = { 0.5f, 0.7f, 0.9f, 1.1f, 1.3f, 1.5f, 1.7f, 1.9f };

    public GameObject currentFruit;
    public int currentFruitType;

    public float fruitStartHeight = 6.0f;
    public float gameWidth = 6.0f;
    public bool isGameOver = false;
    public Camera mainCamera;

    public float FruitTimer;

    void SpawnnewFruit()
    {
        if (!isGameOver)
        {
            currentFruitType = Random.Range(0, 3);

            Vector3 mouseposition = Input.mousePosition;
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mouseposition);

            Vector3 spawnPosition = new Vector3(worldPosition.x, fruitStartHeight, 0);

            float halfFruitSize = fruitsize[currentFruitType] / 2f;

            spawnPosition.x = Mathf.Clamp(spawnPosition.x, -gameWidth / 2 + halfFruitSize, gameWidth / 2 - halfFruitSize);

            currentFruit = Instantiate(fruitPrefabs[currentFruitType], spawnPosition, Quaternion.identity);
            currentFruit.transform.localScale = new Vector3(fruitsize[currentFruitType], fruitsize[currentFruitType], 1);

            Rigidbody2D rb = currentFruit.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.gravityScale = 0.0f;
            }
        }

    }

    void DropFruit()
    {
        Rigidbody2D rb = currentFruit.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 1.0f;
            currentFruit = null;
            FruitTimer = 1.0f;
        }
    }

    public void MergeFruits(int fruitType, Vector3 position)
    {
        if(fruitType < fruitPrefabs.Length - 1)
        {
            GameObject newFruit = Instantiate(fruitPrefabs[fruitType + 1], position, Quaternion.identity);
            newFruit.transform.localScale = new Vector3(fruitsize[fruitType + 1], fruitsize[fruitType + 1], 1);
        }
    }
}
