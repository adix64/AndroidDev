using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectableEntry : MonoBehaviour, IPointerUpHandler
{
    public SelectableTextList selectableTextList; // referinta la obiectul lista
    public int entryIndex; // numarul de ordine din lista
    public void OnPointerUp(PointerEventData eventData)
    {// cand ridici degetul de deasupra butonului
        //obiectului lista i se actualizeaza indexul selectat:
        selectableTextList.selectionIndex = entryIndex;
    }
}
