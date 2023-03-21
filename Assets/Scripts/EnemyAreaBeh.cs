using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAreaBeh : MonoBehaviour
{
      [SerializeField] private GameObject keeper;
      private void OnTriggerEnter( Collider other ) {
            if ( other.gameObject.tag == "PlayerManager" )
                  keeper.GetComponent<ITriggerable>( ).TriggerAttack(other.transform );
      }
}
public interface ITriggerable
{
      void TriggerAttack(Transform target );
}
