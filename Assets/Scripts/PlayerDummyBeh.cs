using DG.Tweening;
using System;
using UnityEngine;

public class PlayerDummyBeh : DummyBeh
{
      [SerializeField] private float jumpPower, jumpRnage;

      public void PlayRunAnim( ) {
            Debug.Log( Animator );
            Animator.SetBool( "Run" , true );
      }
      public override void Move( ) {
            if ( State == 1 ) {
                  if ( Target != null ) {

                        Rb.MovePosition( Vector3.MoveTowards( transform.position ,
                              Target.position ,
                              Speed * Time.deltaTime ) );

                  }
                  else {
                        transform.rotation = Quaternion.identity;
                        State = 0;
                  }
            }
      }
      public override void OnTriggerEnter( Collider other ) {
            if ( other.gameObject.tag == "Obstacle" )
                  Destroy( );
      }


}

