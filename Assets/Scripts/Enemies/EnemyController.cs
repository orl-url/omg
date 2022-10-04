using UnityEngine;

namespace Enemies
{
    public class EnemyController : MonoBehaviour
    {
        //private Transform _castle;
        public float speed = 1f;
        private Rigidbody2D _rb;
        private Vector2 _velocity;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _velocity = new Vector2(0, -1);
            //_castle = GameObject.FindGameObjectWithTag("Castle").GetComponent<Transform>();
        }

        private void FixedUpdate()
        {
         _rb.MovePosition(_rb.position + _velocity * Time.fixedDeltaTime);   
            //transform.position = Vector2.MoveTowards(transform.position, _castle.position, speed * Time.deltaTime);
        }
    }
}