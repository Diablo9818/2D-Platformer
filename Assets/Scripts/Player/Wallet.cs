using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    private int _money = 0;

    public void AddMoney(int amount)
    {
        if (amount <= 0)
            return;

        _money += amount;
        Debug.Log(_money);
    }
}
