using System;
using Xunit;
using Moq;

namespace CreditCard.Tests
{
    public class CreditCardEvaluatorShould
    {
        private readonly CreditCardApplicationEvaluator creditCardApplicationEvaluator;

        public CreditCardEvaluatorShould()
        {
            Mock<IFrequentFlyerNumberValidator> mockValidator = new Mock<IFrequentFlyerNumberValidator>();
            mockValidator.Setup(x => x.IsValid("x")).Returns(true);

            creditCardApplicationEvaluator = new CreditCardApplicationEvaluator(mockValidator.Object);

        }
        [Fact]
        public void AcceptHighIncomeApplications()
        {
            var application = new CreditCardApplication { GrossAnnualIncome = 100_000 };
            CreditCardApplicationDecision decision = creditCardApplicationEvaluator.Evaluate(application);

            Assert.Equal(CreditCardApplicationDecision.AutoAccepted, decision);
        }

        [Fact]
        public void ReferYoungApplications()
        {
           var application = new CreditCardApplication{Age = 19};
            CreditCardApplicationDecision decision = creditCardApplicationEvaluator.Evaluate(application);

           Assert.Equal(CreditCardApplicationDecision.ReferredToHuman, decision);

      

        }
        [Fact]

        public void DeclineLowIncomeApplications()
        {
            var application = new CreditCardApplication { Age = 42, GrossAnnualIncome = 19_999, FrequentFlyerNumber = "x" };
            CreditCardApplicationDecision decision = creditCardApplicationEvaluator.Evaluate(application);

            Assert.Equal(CreditCardApplicationDecision.AutoDeclined, decision);
        }

    }
}
