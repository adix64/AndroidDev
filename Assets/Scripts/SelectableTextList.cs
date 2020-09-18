using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableTextList : MonoBehaviour
{
    public RectTransform listEntryTemplate; // referinta catre prefabul cu o intrare de lista
    List<RectTransform> listEntries; // lista cu intrari (componentele Transform ale intrarilor)

    public TMPro.TMP_InputField inputFieldulNostru; // campul de text de unde adaugi la entries
    int numEntries = 0; // numarul de intrari din lista
    public int selectionIndex = 0; // numarul de ordine al elementului selectat

    public RectTransform scrollViewContent; // containerul de intrari, care contine toate intrarile

    private void Start()
    {
        listEntries = new List<RectTransform>(); // initializam lista, care initial este o referinta null
    }

    public void AddEntry()
    {
        RectTransform newEntry = GameObject.Instantiate(listEntryTemplate, scrollViewContent); // clonare entry prefab

        var textObj = newEntry.GetComponent<TMPro.TMP_Text>(); // obtinem componenta de text de pe intrare
        textObj.text = inputFieldulNostru.text; // si scriem in ea

        // referentiem scriptul SelectableEntry atasat noii intrari
        var selectableListEntry = newEntry.GetComponent<SelectableEntry>();
        selectableListEntry.entryIndex = numEntries; // adaugam noua intrare pe ultima pozitie, jos de tot in lista
        // pentru scriptul SelectableEntry referentiem scriptul curent(SelectableTextList):
        selectableListEntry.selectableTextList = this; 

        //setam pozitia noii intrari cu 50 de unitati mai jos decat ultima intrare, ca sa nu se suprapuna cu celelalte
        var oldPosition = newEntry.localPosition;
        newEntry.localPosition = new Vector3(oldPosition.x, -50 * numEntries, oldPosition.z);

        listEntries.Add(newEntry); //retinem noua intrare in obiectul List<RectTransform> listEntries

        numEntries++; //incrementam numarul de intrari cu 1
    }

    public void DeleteSelectedEntry()
    {
        if (numEntries == 0) // daca lista e goala
            return; // nu mai executa ce e mai jos

        RectTransform selectedEntry = listEntries[selectionIndex]; //obtinem elementul selectat
        listEntries.RemoveAt(selectionIndex); // stergem din lista referinta la obiectul de sters

        GameObject.Destroy(selectedEntry.gameObject); //stergem si din scena intrarea, definitiv

        numEntries--; // decrementam numarul de intrari cu 1

        //ca sa nu ramana spatiul liber in locul stersaturii...
        //...shiftam mai sus cu inaltimea unui rand (50unitati) toate elementele de la indexul sters pana la final
        for (int i = selectionIndex; i < numEntries; i++)
        {
            var entry = listEntries[i]; // intrarea de shiftat
            // actualizam pe fiecare intrare noul numar de ordine(cu 1 mai putin):
            entry.GetComponent<SelectableEntry>().entryIndex--;
            // finally, shiftam mai sus elementul
            entry.localPosition += new Vector3(0, 50, 0);
        }

        // setam limita superioara a selectionIndex
        selectionIndex = Mathf.Min(selectionIndex, numEntries - 1);
    }
}
