using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    #region Variables
    public int damage;
    public UnitTypes targetType;
    #endregion

    public void DealDamage(GameObject target)
    {
        target.GetComponent<Health>().ChangeHealth(damage);
    }

    private void OnTriggerEnter(Collider target)
    {
        switch (targetType)
        {
            case UnitTypes.Enemy:
                if (target.CompareTag("Enemy"))
                {
                    DealDamage(target.gameObject);
                }
                break;
            case UnitTypes.Player:
                if (target.CompareTag("Player"))
                {
                    DealDamage(target.gameObject);
                }
                break;
        }
    }

}


