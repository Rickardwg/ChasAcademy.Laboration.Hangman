using Hangman;

var game = new HangmanGame();
var view = new HangmanView();
var controller = new HangmanController(game, view);

controller.Play();