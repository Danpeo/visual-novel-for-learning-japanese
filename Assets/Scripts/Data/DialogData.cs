using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Data
{
    [Serializable]
    public class DialogData 
    {
        [SerializeField] private List<Sentence> _sentences;
        
        public List<Sentence> Sentences => _sentences;
        
        [Serializable]
        public struct Sentence
        {
            [SerializeField][TextArea(3, 10)]private string _text;
            public string Text => _text;
        
            [SerializeField] private Image _background;
            public Image Background => _background;
        }

    }

   
}
