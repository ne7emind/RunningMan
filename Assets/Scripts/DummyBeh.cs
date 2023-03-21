using DG.Tweening;
using UnityEngine;

abstract public class DummyBeh : MonoBehaviour
{
      public float Speed;
      [SerializeField] private float rotationSpeed;
      [SerializeField] private ParticleSystem bloodEffect;
      public Rigidbody Rb { get; set; }
      public Animator Animator { get; set; }
      public Transform target;
      public int state;
      public event System.Action DummyDestroyed;
      public void Awake( ) {

            Rb = GetComponent<Rigidbody>( );
            Animator = GetComponent<Animator>( );
      }
      public virtual void SetTargetAndState( Transform position ) {
            state = 1;
            target = position;                     
            transform.LookAt( position );
      }
      public void OnLevelFinish( ) {
            Animator.SetBool( "Run" , false );
      }
      public abstract void Move( ); 
    
            
   
      abstract public void OnTriggerEnter( Collider other );

      public void Destroy( ) {
            
            DummyDestroyed?.Invoke( );
            Instantiate( bloodEffect , transform.position , Quaternion.identity );
            transform.DOKill( );
            Destroy( this.gameObject );
      }
      public virtual void Update( ) {
            Move( );
      }
}
