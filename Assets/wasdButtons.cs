using UnityEngine;
using UnityEngine.EventSystems;
public class wasdButtons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float timePressed = 0f;
    public bool buttonPressed = false;

    public MovePlayer player;

    [SerializeField]
    public enum ButtonDirection{LEFT, RIGHT, FORWARD, BACK };
    
    public ButtonDirection buttonType;


    public void OnPointerDown(PointerEventData eventData)
    {// apelat prima data cand butonul este pus degetul pe el 
        buttonPressed = true;
        switch (buttonType)
        {
            case ButtonDirection.LEFT:
                player.xCtrl = -1;
                break;
            case ButtonDirection.RIGHT:
                player.xCtrl = 1;
                break;
            case ButtonDirection.FORWARD:
                player.zCtrl = 1;
                break;
            case ButtonDirection.BACK:
                player.zCtrl = -1;
                break;
        }
    }
    void Update()
    {
        if (buttonPressed)
        {
            timePressed += Time.deltaTime;
        }
    }
    void ResetTimePressed()
    {
        timePressed = 0f;
    }
    void ResetButton()
    {
        ResetTimePressed();
        buttonPressed = false;
    }
    public void OnPointerUp(PointerEventData eventData)
    {// apelat cand ridici degetulbutonul este pus degetul pe el 
        ResetButton();
        switch (buttonType)
        {
            case ButtonDirection.LEFT:
                player.xCtrl = 0;
                break;
            case ButtonDirection.RIGHT:
                player.xCtrl = 0;
                break;
            case ButtonDirection.FORWARD:
                player.zCtrl = 0;
                break;
            case ButtonDirection.BACK:
                player.zCtrl = 0;
                break;
        }
    }
}

