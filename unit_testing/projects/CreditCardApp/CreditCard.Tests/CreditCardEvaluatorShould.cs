using System;
using Xunit;

namespace CreditCard.Tests
{
    public class CreditCardEvaluatorShould
    {
        private readonly CreditCardApplicationEvaluator creditCardApplicationEvaluator;

        public CreditCardEvaluatorShould()
        {
            creditCardApplicationEvaluator = new CreditCardApplicationEvaluator(null);

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
            var application = new CreditCardApplication
            {
                Age = 19
            };
            CreditCardApplicationDecision decision = creditCardApplicationEvaluator.Evaluate(application);

            Assert.Equal(CreditCardApplicationDecision.ReferredToHuman, decision);

        }
    }
}
