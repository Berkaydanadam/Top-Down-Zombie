using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickup
{
    void Destroy();
    void OnTriggerEnter(Collider other);
    void PickUp();
}