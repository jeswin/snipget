using System;
using System.Collections.Generic;

namespace snipget.Commands {
  public class HelpCommand : ICommand {
    public void Run(IEnumerable<string> args) {
      Console.WriteLine("Help goes here...");
    }
  }
}