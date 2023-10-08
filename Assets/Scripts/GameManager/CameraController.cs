using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] Vector2 minPosition, maxPosition;
    [SerializeField] float smoothing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //this.transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, this.transform.position.z);
        if(this.transform.position != _player.position)
        {
            Vector3 targetPosition = new Vector3(_player.position.x,_player.position.y,this.transform.position.z);

            targetPosition.x = Mathf.Clamp(targetPosition.x,minPosition.x,maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y,minPosition.y,maxPosition.y);

            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, smoothing);
        }
    }
}
