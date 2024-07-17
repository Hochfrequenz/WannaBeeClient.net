using AhbichtClient.Model;

namespace AhbichtClient;

/// <summary>
/// Interface of all the things that can evaluate expressions
/// </summary>
/// <remarks>This will be useful if you want to mock the client elsewhere</remarks>
public interface IContentEvaluator
{
    /// <summary>
    /// given an ahb condition expression and information about which conditions is fulfilled, evaluate the expression as whole
    /// </summary>
    public Task<AhbExpressionEvaluationResult> Evaluate(string ahbExpression, ContentEvaluationResult contentEvaluationResult);
}