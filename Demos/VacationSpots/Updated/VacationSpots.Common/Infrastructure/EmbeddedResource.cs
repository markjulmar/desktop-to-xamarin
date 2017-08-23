using System;
using System.IO;
using System.Reflection;

namespace VacationSpots.Common.Infrastructure
{
    public static class EmbeddedResource
    {
        public static Stream GetStream(string name, Type resolvingType = null)
        {
            if (resolvingType == null)
                resolvingType = typeof(EmbeddedResource);

            Assembly asm = resolvingType.GetTypeInfo().Assembly;
            return asm.GetManifestResourceStream(name);
        }
    }
}