using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : IStorable
{
      private int _coinsEarned;
      readonly string coinsKey = "Coins";
     
      public void SaveData(int value ) {
            _coinsEarned += value;
            Debug.Log( _coinsEarned );
            PlayerPrefs.DeleteKey( coinsKey );
            PlayerPrefs.SetInt( coinsKey , _coinsEarned );
      }
      public int LoadData( ) {
            if ( PlayerPrefs.HasKey( coinsKey ) ) {
                  
                  _coinsEarned = PlayerPrefs.GetInt( coinsKey );
                  Debug.Log( _coinsEarned );
            }
            return _coinsEarned;
      }
}
public interface IStorable
{
      void SaveData(int value );
      int LoadData( );
}
