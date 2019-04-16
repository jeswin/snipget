using System;
using System.Collections.Generic;

namespace snipget.Commands {
  public interface ICommand {
    void Run(IEnumerable<string> args);
  }
}