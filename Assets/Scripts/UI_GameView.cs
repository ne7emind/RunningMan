
using UnityEngine;

public class UI_GameView : MonoBehaviour, IGameView
{
      [SerializeField] private GameObject gamePanel, finishPanel;
      
      public static UI_GameView Instance;
      private void Awake( ) {
            Instance = this;
          
      }
      public void HidePanel( ) {
           gamePanel.SetActive( false );
         
      }
      public void ShowStartPanel( ) {
            gamePanel.SetActive( true );
           
            finishPanel.SetActive( false );
      }
      public void ShowFinalPanel( ) {
            finishPanel.SetActive( true );
      }
      
}
