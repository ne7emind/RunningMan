
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
            if ( State == 1 ) {
                  if ( Target != null ) {
                        Rb.MovePosition( Vector3.MoveTowards( transform.position ,
                              Target.position ,
                              Speed * Time.deltaTime ) );
                  }
                  else {
                       
                        Animator.SetBool( "Attack" , false );
                        State = 0;
                  }
            }
      }
      public override void SetTargetAndState( Transform position ) {
            base.SetTargetAndState( position );
            Animator.SetBool( "Attack" , true );

      }

}
