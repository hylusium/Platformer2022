namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Utilities;

    public class LootInstancier : MonoBehaviour
    {
        [SerializeField]
        private PickupInteractor _lootPickup = null;

        // Simplified command for UnityEvent
        public void DoInstantiateLoot() => InstantiateLoot();

        public PickupInteractor InstantiateLoot()
        {
            return GameObject.Instantiate(_lootPickup, transform.position, transform.rotation);
        }
    }
}