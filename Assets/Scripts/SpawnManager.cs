using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public EnemyWave[] waves;

    private EnemyWave _currentWave;
    private int _waveIndex = -1;
    private int _enemyCount;
    private float _timer;
    private float _cooldown;

    private void Start()
    {
        NextWave();
    }

    private void Update()
    {
        if (_currentWave is null)
            return;
        
        UpdateWave();
    }

    private void NextWave()
    {
        _waveIndex++;

        if (_waveIndex >= waves.Length)
        {
            _currentWave = null;
            return;
        }
        
        _currentWave = waves[_waveIndex];
        _cooldown = _currentWave.Cooldown;
        _enemyCount = 0;
    }

    private void UpdateWave()
    {
        _timer += Time.deltaTime;

        if (_timer >= _cooldown)
        {
            _timer -= _cooldown;
            SpawnEnemy();
        }

        if (_enemyCount >= _currentWave.Count)
        {
            NextWave();
        }
    }

    private void SpawnEnemy()
    {
        var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_currentWave.EnemyPref, spawnPoint.transform);
        
        _enemyCount++;
    }
}