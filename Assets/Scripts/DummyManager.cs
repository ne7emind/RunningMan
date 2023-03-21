using DG.Tweening;
using UnityEngine;
abstract public class DummyManager : MonoBehaviour
{
      abstract public int DummiesCount { get; set; }
      [Range(0, 1)] [SerializeField] private float DistanceBtwDummies, FormationRadius;
      public float VerticalOffset;
      public event System.Action<string> DummiesAmountChanged;
      abstract public Transform DummyHolder { get; }
      public GameObject DummyPrefab;    
      abstract public TowardsEnemyMovement twrdsMovement { get; }
        
      public virtual void Start( ) {                                      
            twrdsMovement.EnemyKilled += TwrdsMovement_EnemyKilled;
      }

      public virtual void TwrdsMovement_EnemyKilled( ) {
            
            FormatDummies( );                     
      }
      public void DestroyDummies( ) {

            for ( int i = DummyHolder.childCount - 1 ; i >= DummiesCount ; i-- )
                  Destroy(DummyHolder.GetChild( i ).gameObject);                       
      }

      public void FormatDummies( ) {
            float x;
            float z;
            DestroyDummies( );
            for ( int i = 0 ; i < DummyHolder.childCount ; i++ ) {
                  x = DistanceBtwDummies * Mathf.Sqrt( i ) * Mathf.Cos( i * FormationRadius );
                  z = DistanceBtwDummies * Mathf.Sqrt( i ) * Mathf.Sin( i * FormationRadius );
                  var dummyNewPos = new Vector3(x, VerticalOffset, z);
     
                  DummyHolder.GetChild( i ).DOLocalMove( dummyNewPos , 1f ).SetEase( Ease.OutBack );
            }
      }

      public virtual void SpawnDummies( int value ) {
       
            for ( int i = 0 ; i < value ; i++ ) {
                  GameObject gObject = Instantiate( DummyPrefab , transform.position , transform.rotation , DummyHolder );
                  gObject.GetComponent<DummyBeh>( ).DummyDestroyed += DummyManager_DummyDestroyed;
            }
            FormatDummies( );           
            DummiesAmountChanged?.Invoke( DummiesCount.ToString( ) );
      }

      public void DummyManager_DummyDestroyed( ) {
            DummiesCount--;
            DummiesAmountChanged?.Invoke( DummiesCount.ToString( ) );
            if ( DummiesCount <= 0 ) {
                  Destroy( );
            }
      }
      public virtual void Destroy( ) {
            Destroy( gameObject );
      }

      public void AddDummies( int value ) {
            DummiesCount += value;
            SpawnDummies( value );
      }

      public void MultiplyDummies( float value ) {

            var _dummiesTemp = (float) DummiesCount;
            _dummiesTemp *= value;
            int oldDummiesAmount = DummiesCount;
            DummiesCount = ( int ) _dummiesTemp;
            SpawnDummies( DummiesCount - oldDummiesAmount );
      }
      public virtual void SendAttackCommand( Transform target ) {
                 
            for ( int i = 0 ; i < DummiesCount ; i++ ) {
                  DummyHolder.GetChild( i ).GetComponent<DummyBeh>( ).SetTargetAndState( target );
            }                   
      }
    
           

      
}
