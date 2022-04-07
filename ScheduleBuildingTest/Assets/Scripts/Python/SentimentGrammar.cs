using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Python.Runtime;
using System;

public class SentimentGrammar : MonoBehaviour
{

    dynamic nltk;

    // Start is called before the first frame update
    void Start()
    {
        Runtime.PythonDLL = Application.dataPath + "/StreamingAssets/python/python37.dll";
        PythonEngine.Initialize(mode: ShutdownMode.Reload);

        Debug.Log(GetSentiment("This class is great!!"));
    }

    public string GetSentiment(string userVent)
    {

        try
        {
            nltk = PyModule.Import("nltk");
        }
        catch (Exception e)
        {
            Debug.Log("NLTK ERROR:" + e);
            return "positive";
            
        }

        nltk.download("opinion_lexicon");
        nltk.download("word_tokenize");


        string[] tokens = nltk.word_tokenize(userVent);


        int negscore = 0;
        int posscore = 0;
        bool negated = false;
        foreach (string word in tokens)
        {
            if (nltk.corpus.opinion_lexicon.words().__contains__(word))
            {
                foreach (string[] sent in nltk.corpus.sentence_polarity.sents(categories: "neg"))
                {
                    if (Array.IndexOf(sent, word) >= 0)
                    {
                        if (negated)
                            posscore += 1;
                        else
                            negscore += 1;
                    }
                }

                foreach (string[] sent in nltk.corpus.sentence_polarity.sents(categories: "pos"))
                {
                    if (Array.IndexOf(sent, word) >= 0)
                    {
                        if (negated)
                            negscore += 1;
                        else
                            posscore += 1;
                    }
                }
            }

            if (word == "not")
                negated = true;
            if (word == "but")
            {
                if (negated)
                {
                    negated = false;
                }
            }
        }

        if (negscore > posscore)
        {
            Debug.Log("The sentence is negative (" + Math.Round((double)negscore / (negscore + posscore) * 100) + "% confidence)");
            return "negative";
        }

        else if (posscore > negscore)
        {
            Debug.Log("The sentence is positive (" + Math.Round((double)posscore / (negscore + posscore) * 100) + "% confidence)");
            return "positive";
        }
        else
        {
            return "neutral";
        }

    }

    public void OnApplicationQuit()
    {
        if (PythonEngine.IsInitialized)
        {
            print("ending python");
            PythonEngine.Shutdown(ShutdownMode.Reload);
        }
    }
}