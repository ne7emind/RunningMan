using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowardsEnemyMovement : MonoBehaviour
{
      [SerializeField] private float twrdsMovSpeed;

      private Transform _target;
      private Rigidbody _rb;
      public Transform Target { set => _target = value; }
      public event System.Action EnemyKilled;
      // Update is called once per frame
      private void Start( ) {
            _rb = GetComponent<Rigidbody>( );
      }
      void Update( ) {
            MoveTowards( );
      }
      public void MoveTowards( ) {


            if ( _target != null ) {
                 if (_rb != null)
                _rb.MovePosition( Vector3.MoveTowards( transform.position , _target.position , twrdsMovSpeed * Time.deltaTime ) );
            }
            else {
                  Debug.Log( _target );
                  EnemyKilled?.Invoke( );
                  this.enabled = false;
            }
      }
}
