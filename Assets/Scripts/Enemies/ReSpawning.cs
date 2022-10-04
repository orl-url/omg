using UnityEngine;
// using Random = System.Random;

namespace Enemies
{
    public class ReSpawning : MonoBehaviour
    {
        public GameObject[] enemy;
        public Transform[] spawnPoint;

        private int _rand;
        private int _randPosition;
        public float startTimeBtwSpawns;
        private float _timeBtwSpawns;

        private void Start()
        {
            _timeBtwSpawns = startTimeBtwSpawns;
        }

        private void Update()
        {
            if (_timeBtwSpawns <= 0)
            {
                _rand = UnityEngine.Random.Range(0, enemy.Length);
                _randPosition = UnityEngine.Random.Range(0, spawnPoint.Length);
                Instantiate(enemy[_rand], spawnPoint[_randPosition].transform.position, Quaternion.identity);
                _timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                _timeBtwSpawns -= Time.deltaTime;
            }
        }
        
    }
}
