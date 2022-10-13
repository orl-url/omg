using System.Collections.Generic;
using Enemies;
using UnityEngine;

public class WavesManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public EnemyWave[] waves;
    public GameObject castle;
    public List<Enemy> enemyList;
    public CardManager cardManager;

    private Vector2 _target;
    private EnemyWave _currentWave;
    private EnemyWave.Step _currentStep;
    private Enemy _newEnemy;
    
    private int _waveIndex = -1;
    private int _stepIndex = -1;
    private int _enemyCount;
    private float _timer;
    private float _cooldown;

    private int _stepInd;

    private void Start()
    {
        NextWave();
    }

    private void Update()
    {
        Next();
    
        if (_currentWave is null)
            return;
        if (_currentStep is null)
            return;
        
        UpdateStep();
    }
    private void Next()
    {
        if (enemyList.Count == 0 && _currentStep == null && _waveIndex < 100)
        {
            Time.timeScale = 0;
            cardManager.CreateCards();
            // NextWave(); Надо вызвать из кардменеджера
        }
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
                _currentStep = null;
                // print(_currentStep);
                _stepIndex = -1;
                // print(_stepIndex);
                
                // Time.timeScale = 0;
                // cardManager.cardCanvas.SetActive(true);

                // NextWave();     Этот метод надо вызвать из кард менеджера
                return;
            }
            
        _currentStep = steps[_stepIndex];
        _cooldown = _currentStep.cooldown;
        _enemyCount = 0;
    }

    private void UpdateStep()  // Вызывается каждый кадр
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
        _newEnemy =  Instantiate(_currentStep.enemyPref, spawnPoint.transform);
        _newEnemy.Init(this);
        _enemyCount++;
    }
}