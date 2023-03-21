using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardBeh : MonoBehaviour, IRewardable
{
      [SerializeField] private int  amount;
      public int Amount { get { return amount; } }
 
}
public interface IRewardable
{
      int Amount { get; }
}
