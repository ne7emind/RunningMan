using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDummyBeh : DummyBeh
{
      public override void OnTriggerEnter( Collider other ) {
            
            if ( other.gameObject.tag == "PlayerDummy") {               
                  other.gameObject.GetComponent<DummyBeh>().Destroy();
                  Destroy( );
            }
      }
      public override void Move( ) {
            if ( state == 1 ) {
                  if ( target != null ) {

                        Rb.MovePosition( Vector3.MoveTowards( transform.position ,
                              target.position ,
                              Speed * Time.deltaTime ) );

                  }
                  else {
                       
                        Animator.SetBool( "Attack" , false );
                        state = 0;
                  }
            }
      }
      public override void SetTargetAndState( Transform position ) {
            base.SetTargetAndState( position );
            Animator.SetBool( "Attack" , true );

      }

}
