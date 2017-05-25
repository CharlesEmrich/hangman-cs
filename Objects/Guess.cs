using System.Collections.Generic;
using System;

namespace Hangman.Objects
{
  public class Guess
  {
    private string _guessStr; //"A" or "Dog"
    private bool _valid;
    private bool _word;

    public Guess(string guessStr)
    {
      _guessStr = guessStr;
      _valid = false;
      if (guessStr.Length == 1) {
        _word = false;
      } else {
        _word = true;
      }
      Game.GetGame().GetGuesses().Add(this);
    }
    public string GetGuessStr()
    {
      return _guessStr;
    }
    public void SetValid(bool newValid)
    {
      _valid = newValid;
    }
    public bool GetValid()
    {
      return _valid;
    }
    public bool GetWord()
    {
      return _word;
    }
  }
}
