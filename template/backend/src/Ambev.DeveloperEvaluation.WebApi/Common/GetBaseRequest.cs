namespace Ambev.DeveloperEvaluation.WebApi.Common;

/// <summary>
/// Request model for getting a user by ID
/// </summary>
public class GetBaseRequest
{
    /// <summary>
    /// The unique identifier of the user to retrieve
    /// </summary>
    public Guid Id { get; set; }
}
