using System.Collections.Generic;
using System.Text;
using System;

namespace Hangman.Objects
{
  public class Game
  {
    private string _secretWord;
    public string _currentString;
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

    public void SaveGuess(Guess guess)
    {
      _guesses.Add(guess);
    }
    public void checkGuess(Guess guess)
    {
      if (_secretWord.Contains(guess.GetGuessStr())  && !guess.GetWord())
      {
        guess.SetValid(true);

        for (int i = 0; i < _secretWord.Length; i++) {
          if (guess.GetGuessStr() == _secretWord[i].ToString()) {
            StringBuilder sb = new StringBuilder(_currentString);
            sb[i] = System.Convert.ToChar(guess.GetGuessStr());
            _currentString = sb.ToString();
          }
        }
      }

      if (guess.GetGuessStr() == _secretWord || _currentString == _secretWord) {
        guess.SetValid(true);
        _currentString = _secretWord;
        Console.WriteLine("Game Over. User Wins.");
        //they win.
      }

      if (!guess.GetValid())
      {
        //TODO: Refactor this to derive value directly from _guesses. Upon success, cease using failCounter? Maybe?
        _failCounter ++;
      }
      if (_failCounter >= 6) {
        Console.WriteLine("Game Over. User Loses.");
      }
    }
  }
}
