using System.Collections.Generic;
using Enemies;
using UnityEngine;
using static EnemiesStats;

public class WavesManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public EnemyWave[] waves;
    public CardManager cardManager;

    public List<Enemy> enemyList = AnyGoblin.allEnemies;
    private Vector2 _target;
    private EnemyWave _currentWave;
    private EnemyWave.Step _currentStep;
    private AnyGoblin _typeOfCreatedEnemy;
    
    private int _waveIndex = -1, _stepIndex = -1, _enemyCount, _counterCurrentWave = 0;
    private int _stepInd;
    private float _timer, _cooldown;

    private void Start()
    {
        NextWave();
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
        NextWaveStep();
    }

    private void NextWaveStep() // Если закончились враги на сцене.
    {
        _stepIndex++;
        
        var steps = _currentWave.steps;
        
        if (_stepIndex >= steps.Count)
           
        {
            _currentStep = null;
            _stepIndex = -1;
            return;
        }
            
        _currentStep = steps[_stepIndex];
        _cooldown = _currentStep.cooldown;
        _enemyCount = 0;
    }

    private void Update()
    {
        if (_currentWave is null)
            return;
        
        if (_counterCurrentWave <= _waveIndex) {TryCreateCards();}

        if (_currentStep is null) // Пройдены все степы волны.
            return;
        
        UpdateWaveStep(); // Проверяет количество врагов на сцене.
    }

    private void TryCreateCards()
    {
        if (AnyGoblin.allEnemies.Count == 0 && _currentStep == null && _waveIndex < 100)
        {
            Time.timeScale = 0;
            if (_waveIndex % 5 == 1 && _waveIndex != 0)
            {
                cardManager.CreateSpecialCards();
            }
            else
            {
                cardManager.CreateCommonCards();
            }
            _counterCurrentWave += 1;
        }
    }
    
    // ReSharper disable Unity.PerformanceAnalysis

    private void UpdateWaveStep()  // Вызывается каждый кадр
    {
        _timer += Time.deltaTime;
    
        if (_timer >= _cooldown)
        {
            _timer -= _cooldown;
            SpawnEnemy();
        }
    
        if (_enemyCount >= _currentStep.count)
        {
            NextWaveStep();
        }
    }
    
    private void SpawnEnemy()
    {
        var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
         Instantiate(_currentStep.enemyPref, spawnPoint.transform);

        _enemyCount++;
    }
    
    public void PlayGame()
    {
        Time.timeScale = 1;
        NextWave();
    }
}