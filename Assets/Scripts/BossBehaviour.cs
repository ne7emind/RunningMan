using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour, IDamagable, ITriggerable
{
      [SerializeField] private int health;
      [SerializeField] private BoxCollider weapon;           
      private Animator _animator;
      private TowardsEnemyMovement _towardsEnemyMovement;

      private void Start( ) {
            _towardsEnemyMovement= GetComponent<TowardsEnemyMovement>();
            _towardsEnemyMovement.EnemyKilled += EnemyKilled;
            _animator = GetComponent<Animator>();
      }

      private void EnemyKilled( ) {
            _animator.SetBool( "Attack" , false );
            _towardsEnemyMovement.enabled = false;
               
      }

      private void SlashStart( ) {
            weapon.enabled = true;
      }
      private void SlashEnd( ) {
            weapon.enabled = false;  
      }
      private void OnDrawGizmosSelected( ) {
           // Gizmos.DrawWireCube( weapon.position , weaponAreaSize );
      }
      public void OnDamageReceived( int value) {
            health -= value;
            if ( health <= 0 ) { 
                  _animator.SetTrigger( "Death" ); 
                  this.enabled = false;
            }
      }

      public void TriggerAttack( Transform target) {
            _animator.SetBool( "Charge" , true );
            _towardsEnemyMovement.Target = target.transform;
            _towardsEnemyMovement.enabled = true;
      }
      private void OnTriggerEnter( Collider other ) {
            if ( other.gameObject.tag == "PlayerManager" ) {
                  _animator.SetBool( "Charge" , false );
                  _animator.SetBool( "Attack" , true );
                  _towardsEnemyMovement.enabled = false;
            }

      }
}
public interface IDamagable
{
      void OnDamageReceived(int value );
}
