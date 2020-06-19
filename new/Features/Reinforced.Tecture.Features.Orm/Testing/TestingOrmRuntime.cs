﻿using System;
using Reinforced.Tecture.Commands;
using Reinforced.Tecture.Features.Orm.Command.Add;
using Reinforced.Tecture.Features.Orm.Command.Delete;
using Reinforced.Tecture.Features.Orm.Command.Update;
using Reinforced.Tecture.Features.Orm.Testing.Runners;

namespace Reinforced.Tecture.Features.Orm.Testing
{
    class TestingOrmRuntime : OrmRuntimeBase, ITestingRuntime
    {
        internal readonly TestingOrmSource _testingDataSource;
        private readonly AddCommandRunner _add;
        private readonly DeleteCommandRunner _remove;
        private readonly UpdateCommandRunner _update;
        public TestingOrmRuntime(bool strict)
        {
            _testingDataSource = new TestingOrmSource(this, strict);
            _add = new AddCommandRunner(_testingDataSource);
            _remove = new DeleteCommandRunner(_testingDataSource);
            _update = new UpdateCommandRunner(_testingDataSource);
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public override void Dispose()
        {
            //no disposable components
        }

        private static readonly ISaver[] _empty = new ISaver[0];
        /// <summary>
        /// Override supplies savers set
        /// </summary>
        /// <returns>Savers</returns>
        public override ISaver[] GetSavers()
        {
            return _empty;
        }

        /// <summary>
        /// Gets whether runtime is in testing mode
        /// </summary>
        public override bool Testing
        {
            get { return true; }
        }

        protected override CommandRunner<Add> ProvideAddRunner(Add command)
        {
            return _add;
        }

        protected override CommandRunner<Delete> ProvideDeleteRunner(Delete command)
        {
            return _remove;
        }

        protected override CommandRunner<Update> ProvideUpdateRunner(Update command)
        {
            return _update;
        }

        protected override OrmSourceBase ProvideSource(Type sourceType)
        {
            return _testingDataSource;
        }
    }
}
