using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyText : MonoBehaviour
{
    public TMPro.TMP_Text textulNostru; // lista din scrollview
    TMPro.TMP_InputField inputFieldulNostru; // campul de text de unde adaugi la entries
    string[] entries; // arrayul cu intrari
    int numEntries = 0; // numarul de intrari din lista
    int selectionIndex = 0; // numarul de ordine al elementului selectat

    const string selectedColor   = "<color=#8ae8ed>"; //culoarea elementului selectat
    const string unselectedColor = "<color=#ffffff>"; //culoarea celorlalte elemente
    // Start is called before the first frame update
    void Start()
    {
        // referentiem inputfieldul din copii obiectului pe care script ne aflam (scriptul ModifyText de pe obiectul Canvas)
        inputFieldulNostru = GetComponentInChildren<TMPro.TMP_InputField>();
        entries = new string[15]; // initializam array-ul cu maxim 15 elemente(daca sunt mai multe, crapa)
    }

    public void AddEntry() // callback-ul bind-uit la butonul Add
    {
        entries[numEntries] = inputFieldulNostru.text; //adaugam la final de lista
        numEntries++; // trecem la urmatorul slot
        RefreshText(); // actualizam in pagina lista ca sa o vedem
    }

    private void RefreshText()
    {
        textulNostru.text = ""; // initializam cu stringul gol
        for (int i = 0; i < numEntries; i++) // adaugam elementele in obiectul viewable(textulNostru)
            textulNostru.text = (selectionIndex == i ? selectedColor : unselectedColor) +
                                textulNostru.text + "•" + entries[i] + "</color>\n";
    }

    public void MoveUp()
    {
        // decrementare index, daca se poate, iar daca nu, trecem la ultimul element(cicleaza)
        if (selectionIndex > 0)
            selectionIndex--;
        else
            selectionIndex = numEntries - 1;

        RefreshText(); // actualizam in pagina lista ca sa o vedem
    }
    public void MoveDown()
    {
        // incrementare index, daca se poate, iar daca nu, trecem la primul element(cicleaza)
        if (selectionIndex < numEntries - 1)
            selectionIndex++;
        else
            selectionIndex = 0;

        RefreshText(); // actualizam in pagina lista ca sa o vedem
    }

    public void DeleteSelectedIndex()
    {
        // se shifteaza elementul urmator peste elementul curent, incepand de la selectionIndex
        for (int i = selectionIndex; i < numEntries - 1; i++) 
            entries[i] = entries[i + 1];

        numEntries--; // dispare un element
        RefreshText(); // actualizam in pagina lista ca sa o vedem
    }
}
