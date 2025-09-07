using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyPrefabs;

    private GameObject foxEnemy;
    [SerializeField] private GameObject pauseCanvas;

    [SerializeField] private float spawnTimer;
    private GameState State;
    private enum GameState
    {
        lvl1,
        lvl2,
        lvl3
    }
    void Start()
    {
        SpawnEnemies();
        State = GameState.lvl1;
    }
    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            SpawnEnemies();
            spawnTimer = 5f;
        }
        PauseScreen();
    }
    private void PauseScreen()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseCanvas.SetActive(!pauseCanvas.activeSelf);
            if (pauseCanvas.activeSelf)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
    }
    private void SpawnEnemies()
    {
        if (State == GameState.lvl1 && foxEnemy == null)
        {
            foxEnemy = Instantiate(enemyPrefabs[0],enemyPrefabs[0].transform.position, Quaternion.identity);
        }
    }

}
