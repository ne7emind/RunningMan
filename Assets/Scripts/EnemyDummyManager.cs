using UnityEngine;

public class EnemyDummyManager : DummyManager, ITriggerable
{
      public override int DummiesCount { get => _dummiesCount; set => _dummiesCount = value; }
      public override Transform DummyHolder => transform.GetChild(0);
      public override TowardsEnemyMovement twrdsMovement => GetComponent<TowardsEnemyMovement>();

      [SerializeField] private int _dummiesCount = 0;

      public void TriggerAttack( Transform target ) {
            SendAttackCommand( target.gameObject.transform );
      }
}

