
using TMPro;
using UnityEngine;

public class UI_DummyManager : MonoBehaviour
{
    [SerializeField] private TMP_Text counterText;
    [SerializeField] private DummyManager dummyManager;

    void Start()
    {           
          dummyManager.DummiesAmountChanged += DummyManager_DummiesAmountChanged;
         DummyManager_DummiesAmountChanged(dummyManager.DummiesCount.ToString());
    }

      private void DummyManager_DummiesAmountChanged( string obj ) {
            counterText.text = obj;
      }

 
}
