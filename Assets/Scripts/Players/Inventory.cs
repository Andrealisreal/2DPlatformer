using UnityEngine;

namespace Players
{
    public class Inventory : MonoBehaviour
    {
        private int _countMoney;

        public void AddCoin()
        {
            _countMoney++;
        }
    }
}