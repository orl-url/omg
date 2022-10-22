using System.Collections.Generic;
using Enemies;
using UnityEngine;
using static EnemiesStats;

public class WavesManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public EnemyWave[] waves;
    public GameObject castle;
    public CardManager cardManager;

    public List<Enemy> enemyList;
    private Vector2 _target;
    private EnemyWave _currentWave;
    private EnemyWave.Step _currentStep;
    private Enemy _newEnemy;
    
    private int _waveIndex = -1;
    private int _stepIndex = -1;
    private int _enemyCount;
    private float _timer;
    private float _cooldown;
    private int _counter = 0;

    private int _stepInd;

    private void Start()
    {
        NextWave();
    }

    public void NextWave()
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
        
        if (_counter <= _waveIndex) {Next();}

        if (_currentStep is null) // Пройдены все степы волны.
            return;
        
        UpdateWaveStep(); // Проверяет количество врагов на сцене.
    }

    private void Next()
    {
        if (enemyList.Count == 0 &&  _currentStep == null && _waveIndex < 100)
        {
            {
                cardManager.CreateCards();
                _counter += 1;
            }
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
        _newEnemy = Instantiate(_currentStep.enemyPref, spawnPoint.transform);
        
        if (_currentStep.enemyPref.name == "LittleGoblin")
        {
            _newEnemy.Init(this, AnyGoblin.LittleGoblin);
            _newEnemy.GetComponent<Controller>().Init(AnyGoblin.LittleGoblin);
        }
        else if (_currentStep.enemyPref.name == "BigGoblin")
        {
            _newEnemy.Init(this, AnyGoblin.BossGoblin);
            _newEnemy.GetComponent<Controller>().Init(AnyGoblin.BossGoblin);
        }
        
        AnyGoblin.allEnemies.Add(_newEnemy);
        _enemyCount++;
    }
}