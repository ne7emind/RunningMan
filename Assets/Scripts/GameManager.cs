
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
      [SerializeField] private GameObject playerManager, playerCamera;
     
      private IGameView _gameView;
     
      private DummyController _controller;

      private PlayerDummyManager _dummyManager;

      private void Start( ) {
            _gameView = UI_GameView.Instance;
            _controller = playerManager.GetComponent<DummyController>( );
            _dummyManager = playerManager.GetComponent<PlayerDummyManager>( );
            _dummyManager.OnFinishReach += ( ) => {
                  Invoke( nameof( OnLevelFinish ) , 1f );
            };
            _dummyManager.PlayerDead += ( ) => {
                  Invoke( nameof( RestartLevel ) , 1f );
            };
      }
      public void RestartLevel( ) {
            SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
      }
      public void LevelBegin( ) {
            _controller.enabled = true;
            _gameView.HidePanel( );
            _dummyManager.SendRunCommand( );
      }
      public void OnLevelFinish( ) {
            _gameView.ShowFinalPanel( );
      }
      public void LoadNextLevel( ) {

            int nextSceneID = SceneManager.GetActiveScene().buildIndex + 1;
            if ( nextSceneID >= 3 )
                  nextSceneID = 0;
            SceneManager.LoadScene(nextSceneID);
            _gameView.ShowStartPanel( );
      }
      void Update( ) {

      }

}
