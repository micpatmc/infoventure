using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public void KnockbackMethod(int x, float y, Vector3 z)
    {
        while(x > 0)
        {
            GetComponent<Rigidbody2D>().AddForce(y * z, ForceMode2D.Impulse);
            x -= 1;
        }
    }

}
