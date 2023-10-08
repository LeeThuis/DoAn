using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunAnimation : AnimationManager
{
    GunAnimation _gunAnim;
    [SerializeField] SpriteRenderer _gunRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _gunAnim = GetComponent<GunAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        _gunAnim.UpdateAnim(_playerState);
    }
    
}
