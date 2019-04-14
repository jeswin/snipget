using System;
using System.Collections.Generic;

namespace xnippet.Commands {
  public interface ICommand {
    void Run(IEnumerable<string> args);
  }
}