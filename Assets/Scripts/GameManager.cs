using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
      [SerializeField] private GameObject playerManager, playerCamera;
     
      private IGameView gameView;
      private int _levelIndex;
      private DummyController controller;
      private PlayerDummyManager dummyManager;
      private void Start( ) {
            gameView = UI_GameView.Instance;
            controller = playerManager.GetComponent<DummyController>( );
            dummyManager = playerManager.GetComponent<PlayerDummyManager>( );
            dummyManager.OnFinishReach += ( ) => {
                  Invoke( nameof( OnLevelFinish ) , 1f );
            };
            dummyManager.playerDead += ( ) => {
                  Invoke( nameof( RestartLevel ) , 1f );
            };
      }
      public void RestartLevel( ) {
            SceneManager.LoadScene( _levelIndex );
      }
      public void LevelBegin( ) {
            controller.enabled = true;
            gameView.HidePanel( );
            dummyManager.SendRunCommand( );
      }
      public void OnLevelFinish( ) {
            gameView.ShowFinalPanel( );
      }
      public void LoadNextLevel( ) {
            _levelIndex++;
            if(_levelIndex >= 3) {
                  _levelIndex = 0;
            }
            SceneManager.LoadScene( _levelIndex );
            gameView.ShowStartPanel( );
      }
      void Update( ) {

      }

}
