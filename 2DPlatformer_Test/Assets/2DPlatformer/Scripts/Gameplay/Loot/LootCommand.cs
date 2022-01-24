namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

	[CreateAssetMenu(menuName = "GameSup/LootCommand", fileName = "LootCommand")]
    public class LootCommand : PickupCommand
    {
        [SerializeField]
        private int _lootValue = 1;

        protected override bool ApplyPickup(ICommandSender from)
        {
            LevelReferences.Instance.LootManager.AddLoot(_lootValue);

            return true;
        }
    }
}