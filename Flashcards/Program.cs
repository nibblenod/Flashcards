using System.ComponentModel.DataAnnotations;
using Flashcards;
using static Flashcards.Enums;

DatabaseManager dbManager = new();
MainMenu mainMenu = new();

dbManager.createDB("FlashcardsProject");
dbManager.createTables();

mainMenu.PrintMenu();



