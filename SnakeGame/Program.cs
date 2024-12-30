// See https://aka.ms/new-console-template for more information

using AsciiGameEngine;
using AsciiGraphics;
using SnakeGame;

Console.WriteLine("Welcome to Snake Game!");
int xSize = 50;
int ySize = 20;
SnakeGameLogic logic =  SnakeGameLogicFactory.Create(new Coordinate2D(1,1), new Coordinate2DFactory(xSize, ySize));
AsciiGameInstance game = new AsciiGameInstance(xSize, ySize, logic);
game.Run();