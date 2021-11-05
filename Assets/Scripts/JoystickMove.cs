using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMove : MonoBehaviour
{
    [SerializeField]
    private GameObject touchMarker;
    [SerializeField]
    private PlayerMove playerPos;

    private Vector3 target;

    private void Start()
    {
        touchMarker.transform.position = transform.position;
    }

    private void Update()
    {
# if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            Vector3 touchPos = Input.mousePosition;
#else
        if ( Input.touchCount > 0)
        {
            Vector3 touchPos = Input.GetTouch(0).position;
#endif
            target = touchPos - transform.position;

            if(target.magnitude < 260)
            {
                touchMarker.transform.position = touchPos;
                playerPos.ChangePos(Vector3.Normalize(target));
            } 
        }
        else
        {
            touchMarker.transform.position = transform.position;
            playerPos.ChangePos(Vector3.zero);
        }
    }
}
