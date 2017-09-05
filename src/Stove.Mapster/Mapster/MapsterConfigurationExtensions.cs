﻿using System;
using System.Reflection;

using JetBrains.Annotations;

using Mapster;

namespace Stove.Mapster
{
    internal static class MapsterConfigurationExtensions
    {
        public static void CreateAutoAttributeMaps([NotNull] this TypeAdapterConfig configuration, [NotNull] Type type)
        {
            foreach (AutoMapAttributeBase autoMapAttribute in type.GetTypeInfo().GetCustomAttributes<AutoMapAttributeBase>())
            {
                autoMapAttribute.CreateMap(configuration, type);
            }
        }
    }
}
