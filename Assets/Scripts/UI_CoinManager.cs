using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_CoinManager : MonoBehaviour
{

      [SerializeField] private TMP_Text coinsText;
      private void Awake( ) {

            PlayerDummyManager.CoinsUpdated += CoinsUpdated;
      }

      private void CoinsUpdated( int obj ) {
            coinsText.text = obj.ToString( );
      }
}
