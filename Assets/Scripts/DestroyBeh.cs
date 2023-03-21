using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBeh : MonoBehaviour
{
      [SerializeField] private float time;
      private enum DeathCondition
      {
            Time,
      }
      [SerializeField] private DeathCondition condition;
      // Start is called before the first frame update
      void Start( ) {
            switch ( condition ) {
                  case DeathCondition.Time:
                        Invoke( nameof( Destroy ) , time );
                        break;
            }
      }
      private void Destroy( ) {
            Destroy( gameObject );
      }
}
