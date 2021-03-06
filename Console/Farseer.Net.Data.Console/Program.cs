﻿using System.Threading.Tasks;
using FS;

namespace Farseer.Net.Data.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            FarseerBootstrapper.Create<StartupModule>().Initialize();

            ToList().GetAwaiter().GetResult();
        }

        private static async Task ToList()
        {
            var spAccountPos = await TestContext.Data.SpAccount.ToListAsync();
            var lstAsync = await TestContext.Data.SpAccount.ToListAsync().ConfigureAwait(false);
        }
    }
}
