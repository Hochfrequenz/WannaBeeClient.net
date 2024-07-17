using AhbichtClient.Model;
using FluentAssertions;
using Xunit;

namespace AhbichtClient.IntegrationTest;

/// <summary>
/// Tests that expressions can be evaluated
/// </summary>
public class EvaluatorTests : IClassFixture<ClientFixture>
{
    private readonly ClientFixture _client;

    private readonly IAhbichtAuthenticator _authenticator;

    public EvaluatorTests(ClientFixture clientFixture)
    {
        _client = clientFixture;
        _authenticator = clientFixture.Authenticator;
    }

    [Fact]
    public async Task Expressions_Can_Be_Evaluated()
    {
        var httpClientFactory = _client.HttpClientFactory;
        IContentEvaluator client = new AhbichtRestClient(httpClientFactory, _authenticator);
        var actual = await client.Evaluate("Muss ([2]O[3])[902][501]", new ContentEvaluationResult
        {
            Hints = new Dictionary<string, string?> { { "501", "foo" } },
            FormatConstraints = new Dictionary<string, EvaluatedFormatConstraint>
            {
                {"902", new EvaluatedFormatConstraint
                    {
                        FormatConstraintFulfilled = true,
                        ErrorMessage = null
                    }
                }
            },
            RequirementConstraints = new Dictionary<string, ConditionFulfilledValue>
            {
                {"2", ConditionFulfilledValue.Fulfilled},
                {"3", ConditionFulfilledValue.Unfulfilled},
            },
        });
        actual.Should().BeEquivalentTo(new AhbExpressionEvaluationResult
        {
            FormatConstraintEvaluationResult = new FormatConstraintEvaluationResult
            {
                FormatConstraintsFulfilled = true,
            },
            RequirementConstraintEvaluationResult = new RequirementConstraintEvaluationResult
            {
                FormatConstraintsExpression = "[902]",
                RequirementConstraintsFulfilled = true,
                RequirementIsConditional = true,
            }
        });
    }

    [Fact]
    public async Task Expressions_Cannot_Be_Evaluated()
    {
        var httpClientFactory = _client.HttpClientFactory;
        IContentEvaluator client = new AhbichtRestClient(httpClientFactory, _authenticator);
        var evaluatingAMalformedExpression = async () => await client.Evaluate("Muss [2]O[3])[902][501]", new ContentEvaluationResult // <-- contains a syntax error
        {
            Hints = new Dictionary<string, string?> { { "501", "foo" } },
            FormatConstraints = new Dictionary<string, EvaluatedFormatConstraint>
            {
                {"902", new EvaluatedFormatConstraint
                    {
                        FormatConstraintFulfilled = true,
                        ErrorMessage = null
                    }
                }
            },
            RequirementConstraints = new Dictionary<string, ConditionFulfilledValue>
            {
                {"2", ConditionFulfilledValue.Fulfilled},
                {"3", ConditionFulfilledValue.Unfulfilled},
            },
        });
        await evaluatingAMalformedExpression.Should().ThrowAsync<ExpressionNotEvaluatableException>().WithMessage("*process rule*");
    }
}
