using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace player.Balance
{
    public class Balance : MonoBehaviour
    {
        public int balance;
        public TMP_Text text;

        void Start()
        {
        }

        public void Gain(int amount)
        {
            balance += amount;
        }
        public void Lose(int amount) 
        {
            balance -= amount;
        }

        void Update()
        { 
            
        }
    }
}