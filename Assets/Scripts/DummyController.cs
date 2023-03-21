using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class DummyController : MonoBehaviour
{
      [SerializeField] private float speed, forwardSpeed;

      private float _clampedX;
                   
      private Vector3 _clampedVector;
    
      // Update is called once per frame
      void Update( ) {
            Move( );
      }
      public void Move( ) {
    
            var x = Input.GetAxis("Mouse X");
            var moveVector = new Vector3(x * speed, 0, forwardSpeed) * Time.deltaTime;
            _clampedVector = transform.position + moveVector;
            transform.position = new Vector3( Mathf.Clamp( _clampedVector.x , -_clampedX , _clampedX ) , _clampedVector.y , _clampedVector.z );
      }
  
      public void CalculateClampedX( int value ) {
                       switch ( value ) {
                  case 1:
                        _clampedX = 7.5f;
                              break;
                  case  < 50:
                        _clampedX = 5.5f;
                        break;
                  case  < 100:
                        _clampedX = 4.5f;
                        break;
                  case < 150:
                        _clampedX = 3.8f;
                        break;
                  case < 200:
                        _clampedX = 3.4f;
                        break;
                  case < 250:
                        _clampedX = 3.1f;
                        break;
            }

      }
    


}
