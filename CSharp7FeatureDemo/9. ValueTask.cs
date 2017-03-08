using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharp7FeatureDemo
{
    [TestClass]
    public class ValueTaskExample
    {
        [TestMethod]
        public async Task ValueTasksAreLikeTasks()
        {
            var result = await ValueTaskAsync();

            async ValueTask<int> ValueTaskAsync()
            {
                await Task.Delay(100);
                return 4;
            }

            Assert.AreEqual(4, result);
        }

        public interface ISalaryProvider
        {
            ValueTask<decimal> GetSalary(string id);
        }

        public class LocalSalaryProvider : ISalaryProvider
        {
            public ValueTask<decimal> GetSalary(string id)
            {
                return new ValueTask<decimal>(1000m);
            }
        }

        [TestMethod]
        public async Task TheyLetYouCombineAsyncAndSync()
        {
            ISalaryProvider salaryProvider = new LocalSalaryProvider();
            var salary = await salaryProvider.GetSalary("boop");
        }
        

        public class DatabaseSalaryProvider : ISalaryProvider
        {
            public async ValueTask<decimal> GetSalary(string id)
            {
                return await RetrieveFromDatabse();

                Task<decimal> RetrieveFromDatabse() => Task.FromResult(4000m);
            }
        }
        
        [TestMethod]
        public async Task CachingExample()
        {
            var userName = await GetUserName(123);

            async ValueTask<string> GetUserName(int id)
            {
                var cache = new Dictionary<int, string>();

                if (cache.ContainsKey(id))
                {
                    return cache[id];
                }

                return await GetUserNameFromService(id);
            }

            async Task<string> GetUserNameFromService(int id)
            {
                await Task.Delay(100);
                return "TestUserName";
            }

            Assert.AreEqual("TestUserName", userName);
        }
    }
}
