using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDummiesSpawner : MonoBehaviour
{
      private DummyManager _dummiesManager;
      [Range(0, 150)]
      [SerializeField] private int minAmount, maxAmount;
      private void Start( ) {
            _dummiesManager = GetComponent<EnemyDummyManager>();
            int dummiesAmount = Random.Range( minAmount, maxAmount );
            _dummiesManager.AddDummies( dummiesAmount );
      }
}
