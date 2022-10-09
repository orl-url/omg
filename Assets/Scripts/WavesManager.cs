using UnityEngine;

public class WavesManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public EnemyWave[] waves;
    public GameObject castle;

    private Vector2 _target;
    private EnemyWave _currentWave;
    private EnemyWave.Step _currentStep;
    
    private int _waveIndex = -1;
    private int _stepIndex = -1;
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
        if (_currentStep is null)
            return;
        
        UpdateStep();
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
        NextStep();
        }

    // ReSharper disable Unity.PerformanceAnalysis
    private void NextStep()
    {
        _stepIndex++;
        
        var steps = _currentWave.steps;
        if (_stepIndex >= steps.Count)
        {
            // while (GameObject.FindWithTag("Enemy") != null)
           
            _currentStep = null;
            _stepIndex = -1;
            NextWave();
            return;
        }
        print(_stepIndex);        
        _currentStep = steps[_stepIndex];
        _cooldown = _currentStep.cooldown;
        _enemyCount = 0;
    }

    private void UpdateStep()
    {
        _timer += Time.deltaTime;
    
        if (_timer >= _cooldown)
        {
            _timer -= _cooldown;
            SpawnEnemy();
        }
    
        if (_enemyCount >= _currentStep.count)
        {
            NextStep();
        }
    }
    
    private void SpawnEnemy()
    {
        var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_currentStep.enemyPref, spawnPoint.transform);
        
        _enemyCount++;
    }
}