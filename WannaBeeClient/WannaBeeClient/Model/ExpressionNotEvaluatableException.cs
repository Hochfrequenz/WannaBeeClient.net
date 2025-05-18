namespace WannaBeeClient.Model;

/// <summary>
/// raised when an expression is not evaluatable
/// </summary>
public class ExpressionNotEvaluatableException : ArgumentException
{
    public string Expression { get; private set; }

    public ExpressionNotEvaluatableException(string expression, string? message = null)
        : base(message)
    {
        Expression = expression;
    }
}
