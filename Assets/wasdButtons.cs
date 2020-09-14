using UnityEngine;
using UnityEngine.EventSystems;
public class wasdButtons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float timePressed = 0f;
    public bool buttonPressed = false;
    public MovePlayer player;

    [SerializeField]
    public enum ButtonDirType {LEFT, RIGHT, FORWARD, BACK };
    public ButtonDirType buttonType;


    public void OnPointerDown(PointerEventData eventData)
    {// apelat prima data cand butonul este pus degetul pe el 
        buttonPressed = true;
        switch (buttonType)
        {
            case ButtonDirType.LEFT:
                player.xCtrl = -1;
                break;
            case ButtonDirType.RIGHT:
                player.xCtrl = 1;
                break;
            case ButtonDirType.FORWARD:
                player.zCtrl = 1;
                break;
            case ButtonDirType.BACK:
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
            case ButtonDirType.LEFT:
                player.xCtrl = 0;
                break;
            case ButtonDirType.RIGHT:
                player.xCtrl = 0;
                break;
            case ButtonDirType.FORWARD:
                player.zCtrl = 0;
                break;
            case ButtonDirType.BACK:
                player.zCtrl = 0;
                break;
        }
    }
}

