using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public Dialog dialog;
    // Start is called before the first frame update
    public static NPCController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
}
