using UnityEngine;

public class FireBow : Weapon
{
    public byte Ammo;
    public RaycastHit hit;
    //public Camera playerCamera;

    public FireBow(string name, float damage, float range)
    {
        Name = name;
        Damage = damage;
        Range = range;
    }

    public override void Use()
    {
        if (Ammo == 0)
        {
            return;
        }

        base.Use();
        ////Deal damage to enemy
        //throw new System.NotImplementedException("Deal damage to enemy.");
        Debug.Log("Fire arrow fired");
        //if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, Range))
        //{
        //    Debug.Log(hit.transform.name);
        //}
    }
}
