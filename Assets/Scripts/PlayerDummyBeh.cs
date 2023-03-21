using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class PlayerDummyBeh : DummyBeh
{
      [SerializeField] private float jumpPower, jumpRnage;

      public void PlayRunAnim( ) {
            Debug.Log( Animator );
            Animator.SetBool( "Run" , true );
      }
      public override void Move( ) {
            if ( state == 1 ) {
                  if ( target != null ) {

                        Rb.MovePosition( Vector3.MoveTowards( transform.position ,
                              target.position ,
                              Speed * Time.deltaTime ) );

                  }
                  else {
                        transform.rotation = Quaternion.identity;
                        state = 0;
                  }
            }
      }
      public override void OnTriggerEnter( Collider other ) {
            if ( other.gameObject.tag == "Obstacle" )
                  Destroy( );
      }


}

