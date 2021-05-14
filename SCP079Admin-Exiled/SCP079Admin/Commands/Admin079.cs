using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCP079Admin.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    public class Admin079 : ICommand
    {
        public string Command { get; } = "admin079";

        public string[] Aliases { get; } = new string[] { "a079" };

        public string Description { get; } = "Summons an untruthful MTF/CI squad";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            string action;

            if (!((CommandSender)sender).CheckPermission("a.079"))
            {
                response = "You do not have permission to use this command";
                return false;
            }

            if (arguments.Count != 2)
            {
                response = "Usage: \nadmin079 energy <amount> \nadmin079 lvl <Tier 1 = 0 - Tier 3 = 2> \nadmin079 maxenr <amount> \nadmin079 xp <amount>";
                return false;
            }

            foreach (Player Ply in Player.List)
            {
                if (Ply.Role != RoleType.Scp079)
                {
                    response = "You are not SCP-079 to use this command!";
                    return false;
                }
            }

            switch (arguments.At(0))
            {
                case "energy":
                    {
                        if (!int.TryParse(arguments.At(1), out int enr) || enr < 0)
                        {
                            response = $"Incorrect amount of energy";
                            return false;
                        }

                        foreach (Player Ply in Player.List)
                        {
                            Ply.ReferenceHub.scp079PlayerScript.NetworkcurMana = enr;
                        }
                        response = $"The amount of energy has been set";
                        return true;
                    }

                case "lvl":
                    {
                        if (!int.TryParse(arguments.At(1), out int lvl) || lvl < 0)
                        {
                            response = $"Incorrect amount of lvl";
                            return false;
                        }

                        if (lvl > 2)
                        {
                            response = $"The number is out of range, use a number between 0 and 2";
                            return false;
                        }

                        foreach (Player Ply in Player.List)
                        {
                            Ply.ReferenceHub.scp079PlayerScript.NetworkcurLvl = (byte)lvl;
                        }

                        response = $"The amount of lvl has been set";
                        return true;
                    }
                case "maxenr":
                    {
                        if (!int.TryParse(arguments.At(1), out int mana) || mana < 0)
                        {
                            response = $"Incorrect amount of max energy";
                            return false;
                        }

                        foreach (Player Ply in Player.List)
                        {
                            Ply.ReferenceHub.scp079PlayerScript.NetworkmaxMana = mana;
                        }

                        response = $"The maximum amount of energy is set";
                        return true;
                    }
                case "xp":
                    {
                        if (!int.TryParse(arguments.At(1), out int xp) || xp < 0)
                        {
                            response = $"Incorrect amount of Exp";
                            return false;
                        }

                        foreach (Player Ply in Player.List)
                        {
                            Ply.ReferenceHub.scp079PlayerScript.NetworkcurExp = xp;
                        }

                        response = $"The amount of exp is set";
                        return true;
                    }
                default:
                    {
                        response = "Incorrect second argument! \nCorrectly: \nadmin079 energy <amount> \nadmin079 lvl <Tier 1 = 0 - Tier 3 = 2> \nadmin079 maxenr <amount> \nadmin079 xp <amount>";
                        return false;
                    }
            }
        }
    }
}
