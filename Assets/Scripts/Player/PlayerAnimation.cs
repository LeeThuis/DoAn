using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class PlayerAnimation : AnimationManager
{
    Animator _playerAnim;
    [SerializeField] SpriteRenderer _playerRenderer;

    [SerializeField] PlayerController _playerController;
    // Start is called before the first frame update
    void Start()
    {
        _playerAnim = GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        UpdateAnim(_playerState);
    }

}
