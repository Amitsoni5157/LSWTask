using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vendor : MonoBehaviour
{
    public delegate void OnCollide();

    public static event OnCollide collide;

    public delegate void OnCollideExit();

    public static event OnCollideExit PlayerNotCollide;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            collide();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerNotCollide();
        }
    }




}
