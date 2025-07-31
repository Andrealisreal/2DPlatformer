using UnityEngine;

namespace Player
{
    public class Inventory : MonoBehaviour
    {
        private int _countMoney;

        public void AddCoin()
        {
            _countMoney++;
            Debug.Log(_countMoney);
        }
    }
}