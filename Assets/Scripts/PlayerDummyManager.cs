using UnityEngine;
using UnityEngine.Rendering;

public class PlayerDummyManager : DummyManager
{
      public override int DummiesCount { get => _dummiesCount; set => _dummiesCount = value; }
      public override Transform DummyHolder => transform.GetChild( 0 );
      public override TowardsEnemyMovement twrdsMovement => GetComponent<TowardsEnemyMovement>( );
      public static event System.Action<int> CoinsUpdated;
      private DummyController _dummyController;
      public event System.Action<int> ScoreOnFinish;
      public event System.Action OnFinishReach;
      public event System.Action PlayerDead;
      [SerializeField] private int _dummiesCount = 1;
      [SerializeField] private int startDummyAmount;
      [SerializeField] private int score;
      private IStorable _storable;
      private bool _bossFight;
      bool _firstSpawn = true;
      public override void Start( ) {
            base.Start( );
            _dummyController = GetComponent<DummyController>( );
            AddDummies( startDummyAmount );
            _storable = new DataManager( );
            score = _storable.LoadData( );
            Debug.Log( score );
            CoinsUpdated?.Invoke( score );
      }

      public override void TwrdsMovement_EnemyKilled( ) {
            base.TwrdsMovement_EnemyKilled( );
            _dummyController.enabled = true;
      }

      public override void SpawnDummies( int value ) {
            base.SpawnDummies( value );
            _dummyController.CalculateClampedX( DummiesCount );
            if ( _firstSpawn ) {
                  _firstSpawn = false;
                  return;
            }                 
            SendRunCommand( );
      }

      public override void SendAttackCommand( Transform target) {
            base.SendAttackCommand( target );
            _dummyController.enabled = false;
            if ( _bossFight )
                  return;
            twrdsMovement.enabled = true;
            twrdsMovement.Target = target;
      }
      public void SendRunCommand( ) {
            for ( int i = 0 ; i < DummyHolder.childCount ; i++ ) {
                  DummyHolder.GetChild( i ).GetComponent<PlayerDummyBeh>( ).PlayRunAnim( );
            }
      }
      private void OnLevelFinish( ) {

            _dummyController.enabled = false;
           
            OnFinishReach?.Invoke( );
            for ( int i = 0 ; i < DummyHolder.childCount ; i++ )
                  DummyHolder.GetChild( i ).GetComponent<PlayerDummyBeh>( ).OnLevelFinish( );

            FormatDummies( );

            _storable.SaveData( DummyHolder.childCount);

            score += DummyHolder.childCount;

            CoinsUpdated?.Invoke( score );
                      
      }
      public override void Destroy( ) {
            base.Destroy( );
            PlayerDead?.Invoke( );
      }

      public void OnTriggerEnter( Collider other ) {
            if ( other.gameObject.tag == "EnemyArea" ) {
                  SendAttackCommand( other.transform.GetChild( 0 ).transform);             
            }
            if ( other.gameObject.tag == "FinishZone" ) {
                  OnLevelFinish( );
            }
      }
}
