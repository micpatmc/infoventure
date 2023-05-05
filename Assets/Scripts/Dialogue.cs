using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Dialogue
{
    // ---------------------------------------------------------------------
    // Summary:
    // A helper script for the dialogue system
    //
    // By: Michael Mcgarvey
    // ---------------------------------------------------------------------

    public string name; // The NPC name

    [TextArea(3, 10)]
    public string[] sentences; // How many sentences of text there are
}
