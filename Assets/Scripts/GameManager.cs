
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
      [SerializeField] private GameObject playerManager, playerCamera;
     
      private IGameView gameView;
     
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
            SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
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

            int nextSceneID = SceneManager.GetActiveScene().buildIndex + 1;
            if ( nextSceneID >= 3 )
                  nextSceneID = 0;
            SceneManager.LoadScene(nextSceneID);
            gameView.ShowStartPanel( );
      }
      void Update( ) {

      }

}
