using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string CommandJump = "Jump";
    private const KeyCode CommandShoot = KeyCode.F;
    
    private bool _isJump;
    
    public event Action Shot;

    private void Update()
    {
        if (Input.GetButtonDown(CommandJump))
            _isJump = true;
        
        if (Input.GetKeyDown(CommandShoot))
            Shoot();
    }

    public bool GetIsJump() => GetBoolAsTrigger(ref _isJump);
    
    private void Shoot()
    {
        Shot?.Invoke();
    }
    
    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}