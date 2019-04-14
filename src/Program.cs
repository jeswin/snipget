using System;
using System.Linq;
using xnippet.Commands;

namespace xnippet
{
  class Program
  {
    static void Main(string[] args)
    {
      if (args.Length == 0)
      {
        var help = new HelpCommand();
        help.Run(new string[] { });
      }
      else
      {
        var commandName = args[0].ToLower();
        var commandArgs = args.Skip(1);

        var command =
          commandName == "add" ? new AddCommand() :
          commandName == "get" ? new GetCommand() :
          commandName == "help" ? new HelpCommand() :
          commandName == "login" ? new LoginCommand() :
          commandName == "logout" ? new LogoutCommand() :
          commandName == "pub" ? new PubCommand() :
          commandName == "update" ? new UpdateCommand() :
          commandName == "whoami" ? new WhoAmICommand() :
          new HelpCommand() as ICommand;

        command.Run(commandArgs);
      }

    }
  }
}
