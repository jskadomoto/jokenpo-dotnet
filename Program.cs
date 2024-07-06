using System;

namespace JokenpoGame
{
  class Program
  {
    enum Option
    {
      Pedra,
      Papel,
      Tesoura
    }

    static void Main(string[] args)
    {
      Option[] options = { Option.Pedra, Option.Papel, Option.Tesoura };
      string optionsToString = string.Join(", ", options);
      Random random = new Random();

      Console.WriteLine($"Escolha uma das opções: {optionsToString}");
      string playerInput = Console.ReadLine().ToLower();

      Option? playerOption = ParseOption(playerInput, options);

      while (playerOption == null)
      {
        Console.WriteLine($"Escolha inválida. Escolha uma das opções: {optionsToString}");
        playerInput = Console.ReadLine().ToLower();
        playerOption = ParseOption(playerInput, options);
      }

      Option botOption = options[random.Next(options.Length)];

      Console.WriteLine($"Você escolheu: {playerOption}");
      Console.WriteLine($"O bot escolheu: {botOption}");

      DetermineWinner(playerOption.Value, botOption);
    }

    static Option? ParseOption(string input, Option[] options)
    {
      foreach (var option in options)
      {
        if (input == option.ToString().ToLower())
        {
          return option;
        }
      }
      return null;
    }

    static void DetermineWinner(Option player, Option bot)
    {
      if (player == bot)
      {
        Console.WriteLine("Empate!");
        return;
      }

      switch (player)
      {
        case Option.Pedra:
          Console.WriteLine(bot == Option.Tesoura ? "Você venceu!" : "Você perdeu!");
          break;
        case Option.Papel:
          Console.WriteLine(bot == Option.Pedra ? "Você venceu!" : "Você perdeu!");
          break;
        case Option.Tesoura:
          Console.WriteLine(bot == Option.Papel ? "Você venceu!" : "Você perdeu!");
          break;
      }
    }
  }
}
