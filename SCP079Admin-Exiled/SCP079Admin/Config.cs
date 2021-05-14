using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCP079Admin
{
    public class Config : IConfig
    {
        [Description("Indicates whether the plugin is enabled or not")]
        public bool IsEnabled { get; set; } = true;
    }
}
