using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_DummyManager : MonoBehaviour
{
    [SerializeField] private TMP_Text counterText;
    [SerializeField] private DummyManager dummyManager;
    // Start is called before the first frame update
    void Start()
    {           
          dummyManager.DummiesAmountChanged += DummyManager_DummiesAmountChanged;
         DummyManager_DummiesAmountChanged(dummyManager.DummiesCount.ToString());
    }

      private void DummyManager_DummiesAmountChanged( string obj ) {
            counterText.text = obj;
      }

 
}