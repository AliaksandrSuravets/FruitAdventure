using Unity.Collections;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private const string Walk = "Walk";
    
    public void SetWalk(float amount)
    {
        _animator.SetFloat(Walk, amount);
    }
}