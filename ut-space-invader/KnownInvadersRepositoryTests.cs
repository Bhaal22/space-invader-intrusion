using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using space_invader;

namespace ut_space_invader
{
    [TestClass]
    public class KnownInvadersRepositoryTests
    {
        [TestMethod]
        public void TestIterationOnRepositoryElements()
        {
            IRepository repository = new KnownInvadersRepository();

            int numberOfKnowInvaders = 0;

            while(repository.Next() != null)
            {
                numberOfKnowInvaders++;
            }

            Assert.AreEqual(2, numberOfKnowInvaders);
        }
    }
}
