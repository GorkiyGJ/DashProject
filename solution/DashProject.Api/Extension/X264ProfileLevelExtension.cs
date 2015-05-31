using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using DashProject.Api.Enum;

namespace DashProject.Api.Extension
{
    public static class X264ProfileLevelExtension
    {
        public static string GetProfile(this X264ProfileLevel level)
        {
            return ((System.Enum)level).ToString().Replace("l_", string.Empty).Replace('_','.');
        }
    }
}
