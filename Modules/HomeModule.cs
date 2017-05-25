
using System;
using Nancy;
using Hangman.Objects;
using System.Collections.Generic;

namespace Hangman
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        Game game = new Game("color");
        return View["index.cshtml", Game.GetGame()];
      };
      Post["/"] = _ => {
        Guess guess = new Guess(Request.Form["guess"]);
        Game.GetGame().SaveGuess(guess);
        Game.GetGame().CheckGuess(guess);

        return View["index.cshtml", Game.GetGame()];
      };
    }
  }
}
