
using UnityEngine;

public class RewardBeh : MonoBehaviour, IRewardable
{
      [SerializeField] private int amount;
      public int Amount { get { return amount; } }
 
}
