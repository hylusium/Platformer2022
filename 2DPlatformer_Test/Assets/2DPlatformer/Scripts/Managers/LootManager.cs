namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;

    public class LootManager : MonoBehaviour
    {
        private int _currentLoot = 0;

        public int CurrentLoot => _currentLoot;

        public delegate void LootManagerEvent(LootManager sender, int currentLoot);
        public event LootManagerEvent LootAdded = null;

        public void AddLoot(int value)
        {
            _currentLoot += value;

            LootAdded?.Invoke(this, _currentLoot);
        }
    }
}