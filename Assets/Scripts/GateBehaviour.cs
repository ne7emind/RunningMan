using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GateBehaviour : MonoBehaviour
{
      [SerializeField] private TMP_Text gateText;
      [Range(0, 100)]
      [SerializeField] private int minAddAmount, maxAddAmount;
      [Range(0, 5)]
      [SerializeField] private float minMultiplyBonus, maxMultiPlyBonus;
      private enum GateType
      {
            Add,
            Multiply
      }
      [SerializeField] private GateType gateType;
      private int _gatePlus;
      private float _gateX;
      // Start is called before the first frame update
      void Start( ) {
            GateInit( );
      }
      private void GateInit( ) {

            switch ( gateType ) {
                  case GateType.Add:
                        _gatePlus = Random.Range( minAddAmount , maxAddAmount );
                        gateText.text = "+" + _gatePlus.ToString( ); //Usually i use StringBuilder for adding strings etc. But here only 2 operations
                        break;
                  case GateType.Multiply:
                        _gateX = Random.Range( minMultiplyBonus , maxMultiPlyBonus );   
                        string temp = _gateX.ToString( );
                        gateText.text = "x" + temp.Remove( 3 );
                        break;
            }

      }

      private void OnTriggerEnter( Collider other ) {

            other.gameObject.TryGetComponent( out DummyManager manager );
            if ( manager == null ) { return; }

            switch ( gateType ) {
                  case GateType.Add:
                        manager.AddDummies( _gatePlus );
                        break;
                  case GateType.Multiply:
                        manager.MultiplyDummies( _gateX );
                        break;
            }

      }

}
