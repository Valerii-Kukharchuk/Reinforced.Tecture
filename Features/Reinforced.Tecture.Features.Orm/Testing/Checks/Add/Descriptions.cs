﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Reinforced.Tecture.Testing.Generation;

namespace Reinforced.Tecture.Features.Orm.Testing.Checks.Add
{
    sealed class AddCheckDescription : CheckDescription<Commands.Add.Add>
    {
        public override MethodInfo Method =>
            UseMethod(() => AddChecks.Add<object>(null));

        protected override Type[] GetTypeArguments(Commands.Add.Add command)
        {
            return new Type[] { command.EntityType };
        }
    }

    public static class Descriptions
    {
        public static void Basic(this ChecksConfigurator<Commands.Add.Add> c) => c.Enlist(new AddCheckDescription());
    }
}
