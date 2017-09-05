using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class JoyStickController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{

    [SerializeField]
    RectTransform background;
    [SerializeField]
    RectTransform joystick;

    private bool isClick = false;

    Vector2 origin, buttonDis;

    private float degree;

    private void Awake()
    {
        origin = joystick.position;
    }

    public float GetDegree()
    {
        return degree;
    }

    public bool GetClick()
    {
        return isClick;
    }

    public void OnPointerDown(PointerEventData evenData)
    {
        buttonDis = evenData.position - origin;
        isClick = true;
        joystick.position = evenData.position;
    }

    public void OnDrag(PointerEventData evenData)
    {
        joystick.position = evenData.position;

        Vector2 dir = (Vector2)joystick.position - origin;
        degree = (Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg + 360f) % 360f;

        float distance = Vector3.Distance(joystick.position, background.position);

        if (distance > background.rect.width * 0.5f)
            joystick.position = background.position + (joystick.position - background.position).normalized * background.rect.width * 0.5f;
    }

    public void OnPointerUp(PointerEventData evenData)
    {
        joystick.position = origin;
        isClick = false;
    }
}
