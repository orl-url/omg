using System;
using UnityEngine;

namespace Buildings.Castle
{
    public class ArrowAttack : MonoBehaviour
    {
        //private Transform _enemy;
        public DamageFromCastle damageFromCastle;
        public GameObject aboutCastle;
        public float speed = 100f;
        public float lifetime = 2f;
        public float distance;
        public float arrowDamage = 0.3f;
        public LayerMask whatIsSolid;
        private Vector2 some;
        private Vector2 _castlePosition;
        private Vector2 arrowPos;

        private Rigidbody2D _rb;

        void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        
        private void Start()
        {
            // _castlePosition = aboutCastle.transform.position;
            arrowPos = gameObject.transform.position;
            print("arrowPos:" + arrowPos);
            Vector2 heading = damageFromCastle.enemyPosition - arrowPos;
            print("realenemypos " + damageFromCastle.enemyPosition);
            print("mezhdu: " + heading);    
            // some = new Vector2(-300, 300);
            
            _rb.AddForce(heading, ForceMode2D.Force);
            //_enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
            //_castle = GameObject.FindGameObjectWithTag("Building").GetComponent<Transform>();
        }

        

        public void OnCollisionStay2D(Collision2D coll)
        {
            if (coll.gameObject.TryGetComponent(out Enemies.Interaction enemy))
            {
                enemy.TakeDamage(arrowDamage);
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            // RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
            // if (hitInfo.collider)
            // {
            //     if (hitInfo.collider.CompareTag($"Enemy"))
            //     {
            //         hitInfo.collider.GetComponent<Enemies.Interaction>().TakeDamage(arrowDamage);
            //     }
            //     
            //     Destroy(gameObject);
            // }
            // else
            // {
            //     Destroy(gameObject, lifetime);
            // }
            
            

            
            
            //transform.position = Vector2.MoveTowards(transform.position, _enemy.position, speed * Time.deltaTime);

        }
    }
}

