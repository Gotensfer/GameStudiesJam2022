using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Voice : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;

    private Dictionary<string, Action> wordToAction;
    // Start is called before the first frame update
    void Start()
    {
        wordToAction = new Dictionary<string, Action>();
        wordToAction.Add("Hercules", Azul);
        wordToAction.Add("Thor", Morado);

        keywordRecognizer = new KeywordRecognizer(wordToAction.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += WordRecognized;
        keywordRecognizer.Start();
    }

    private void WordRecognized(PhraseRecognizedEventArgs word)
    {
        print(word.text);
        wordToAction[word.text].Invoke();
    }

    private void Morado()
    {
        print(("a"));
        GetComponent<MeshRenderer>().material.color = Color.magenta;
    }

    private void Azul()
    {
        print("b");
        GetComponent<MeshRenderer>().material.color = Color.black;
    }
}
