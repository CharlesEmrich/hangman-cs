using System.Collections.Generic;
using System;

namespace Hangman.Objects
{
  public class Game
  {
    private string _secretWord;
    private string _currentString;
    private int _failCounter;
    private List<Guess> _guesses = new List<Guess> {};
    private static Game _ourGame;


    public Game(string secretWord)
    {
      _secretWord = secretWord;
      _currentString = "";
      foreach (Char item in secretWord)
      {
        _currentString += "_";
      }
      _failCounter = 0;
      _ourGame = this;
    }

    public string GetCurrentString()
    {
      return _currentString;
    }
    public string GetSecretWord()
    {
      return _secretWord;
    }
    public int GetFailCounter()
    {
      return _failCounter;
    }
    public List<Guess> GetGuesses()
    {
      return _guesses;
    }
    public static Game GetGame()
    {
      return _ourGame;
    }

    public void checkGuess(Guess guess)
    {
      if (_secretWord.Contains(guess.GetGuessStr()))
      {
        guess.SetValid(true);
      }
      // if (guess.GetValid() && !guess.GetWord())
      // {
      //   foreach (Type in Collection) {
      //
      //   }
      // }

      // if ((guess.GetGuessStr() == _secretWord || _currentString.replace(" ","") == _secretWord) {
      //   //they win.
      // }

    }
  }
}
