using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeControls : MonoBehaviour
{
    public PlayerControls playerControls;
    public CharacterController character;

    private void Awake()
    {
        playerControls = new PlayerControls();
        character = this.GetComponent<CharacterController>();
    }
}
